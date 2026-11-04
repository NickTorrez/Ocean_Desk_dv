using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services.Authentication;
using Ocean_Desk_dv.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Services.Offline
{
    /// <summary>
    /// Almacena credenciales offline protegidas por Windows DPAPI.
    /// Solo permite autenticar usuarios que iniciaron sesión correctamente
    /// en línea y cuya autorización local todavía está vigente.
    /// </summary>
    public sealed class OfflineAuthenticationStore
    {
        private static readonly object SyncRoot = new();

        private static readonly TimeSpan VigenciaOffline =
            TimeSpan.FromHours(12);

        private const int MaximoIntentosFallidos = 5;
        private const int MinutosBloqueo = 15;

        /// <summary>
        /// Guarda la credencial protegida después de una autenticación online.
        /// Nunca almacena la contraseña en texto plano.
        /// </summary>
        public void GuardarCredencialOffline(
            User usuario,
            UsuarioAutenticadoDto sesion)
        {
            ArgumentNullException.ThrowIfNull(usuario);
            ArgumentNullException.ThrowIfNull(sesion);

            if (usuario.UserId <= 0 ||
                usuario.MustChangePassword ||
                sesion.MustChangePassword ||
                string.IsNullOrWhiteSpace(usuario.PasswordHash))
            {
                return;
            }

            DateTime ahoraUtc = DateTime.UtcNow;

            var credencial = new OfflineCredentialSnapshot
            {
                UserId = usuario.UserId,
                Username = usuario.Username,
                PasswordHash = usuario.PasswordHash,
                NombreCompleto = sesion.NombreCompleto,
                RoleId = sesion.RoleId,
                RoleCode = sesion.RoleCode,
                RoleName = sesion.RoleName,
                Permisos = sesion.Permisos.ToList(),
                CreatedAtUtc = ahoraUtc,
                ExpiresAtUtc = ahoraUtc.Add(VigenciaOffline),
                FailedAttempts = 0,
                LockoutUntilUtc = null
            };

            lock (SyncRoot)
            {
                GuardarSnapshot(
                    ObtenerRuta(usuario.Username),
                    credencial);
            }
        }

        /// <summary>
        /// Comprueba las credenciales utilizando exclusivamente
        /// la última autorización online almacenada.
        /// </summary>
        public ResultadoAutenticacionDto AutenticarOffline(
            string username,
            string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrEmpty(password))
            {
                return ResultadoAutenticacionDto.Fallido(
                    "Ingrese su nombre de usuario y contraseña.");
            }

            lock (SyncRoot)
            {
                try
                {
                    string ruta = ObtenerRuta(username);

                    if (!File.Exists(ruta))
                    {
                        return ResultadoAutenticacionDto.Fallido(
                            "No existe una autorización offline para este usuario. " +
                            "Debe iniciar sesión en línea al menos una vez.");
                    }

                    OfflineCredentialSnapshot? credencial =
                        LeerSnapshot(ruta);

                    if (credencial is null ||
                        credencial.UserId <= 0 ||
                        string.IsNullOrWhiteSpace(credencial.PasswordHash) ||
                        credencial.Permisos is null ||
                        !string.Equals(
                            credencial.Username,
                            username.Trim(),
                            StringComparison.OrdinalIgnoreCase))
                    {
                        return ResultadoAutenticacionDto.Fallido(
                            "La autorización offline no es válida.");
                    }

                    DateTime ahoraUtc = DateTime.UtcNow;

                    // La autenticación offline no renueva la vigencia.
                    if (ahoraUtc >= credencial.ExpiresAtUtc)
                    {
                        File.Delete(ruta);

                        return ResultadoAutenticacionDto.Fallido(
                            "La autorización offline ha expirado. " +
                            "Necesita conectarse a SQL Server para renovar el acceso.");
                    }

                    if (credencial.LockoutUntilUtc.HasValue &&
                        credencial.LockoutUntilUtc.Value > ahoraUtc)
                    {
                        DateTime desbloqueoLocal =
                            DateTime.SpecifyKind(
                                credencial.LockoutUntilUtc.Value,
                                DateTimeKind.Utc).ToLocalTime();

                        return ResultadoAutenticacionDto.Bloqueado(
                            "La cuenta está bloqueada temporalmente en este equipo. " +
                            $"Intente nuevamente después de {desbloqueoLocal}.",
                            credencial.LockoutUntilUtc.Value);
                    }

                    // Si el bloqueo anterior ya terminó, reiniciar contador.
                    if (credencial.LockoutUntilUtc.HasValue)
                    {
                        credencial.FailedAttempts = 0;
                        credencial.LockoutUntilUtc = null;
                    }

                    if (!PasswordHasher.VerifyPassword(
                        password,
                        credencial.PasswordHash))
                    {
                        credencial.FailedAttempts++;

                        if (credencial.FailedAttempts >= MaximoIntentosFallidos)
                        {
                            credencial.LockoutUntilUtc =
                                ahoraUtc.AddMinutes(MinutosBloqueo);

                            GuardarSnapshot(ruta, credencial);

                            return ResultadoAutenticacionDto.Bloqueado(
                                "Se alcanzó el límite de intentos offline. " +
                                $"La cuenta permanecerá bloqueada durante {MinutosBloqueo} minutos.",
                                credencial.LockoutUntilUtc.Value);
                        }

                        GuardarSnapshot(ruta, credencial);

                        int restantes =
                            MaximoIntentosFallidos - credencial.FailedAttempts;

                        return ResultadoAutenticacionDto.Fallido(
                            "Usuario o contraseña incorrectos. " +
                            $"Intentos restantes: {restantes}.");
                    }

                    // Credenciales válidas.
                    credencial.FailedAttempts = 0;
                    credencial.LockoutUntilUtc = null;

                    GuardarSnapshot(ruta, credencial);

                    var usuarioAutenticado = new UsuarioAutenticadoDto
                    {
                        UserId = credencial.UserId,
                        Username = credencial.Username,
                        NombreCompleto = credencial.NombreCompleto,
                        RoleId = credencial.RoleId,
                        RoleCode = credencial.RoleCode,
                        RoleName = credencial.RoleName,
                        MustChangePassword = false,
                        EsSesionOffline = true,
                        Permisos = credencial.Permisos
                    };

                    return ResultadoAutenticacionDto.Correcto(
                        "Autenticación offline correcta. " +
                        "Se utilizarán los permisos de la última sesión online autorizada.",
                        usuarioAutenticado);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(
                        $"Error de autenticación offline: {ex}");

                    // Si los datos locales no pueden verificarse,
                    // no se concede acceso.
                    return ResultadoAutenticacionDto.Fallido(
                        "No fue posible validar la autorización offline. " +
                        "Conéctese a SQL Server e inténtelo nuevamente.");
                }
            }
        }

        private static string ObtenerRuta(string username)
        {
            string localAppData = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);

            if (string.IsNullOrWhiteSpace(localAppData))
            {
                throw new InvalidOperationException(
                    "No fue posible localizar la carpeta de datos del usuario.");
            }

            byte[] usernameBytes = Encoding.UTF8.GetBytes(
                username.Trim().ToUpperInvariant());

            string identificador = Convert.ToHexString(
                SHA256.HashData(usernameBytes));

            string directorio = Path.Combine(
                localAppData,
                "OceanDesk",
                "Security",
                "Offline");

            Directory.CreateDirectory(directorio);

            return Path.Combine(
                directorio,
                identificador + ".dat");
        }

        private static void GuardarSnapshot(
            string ruta,
            OfflineCredentialSnapshot credencial)
        {
            byte[] datos = JsonSerializer.SerializeToUtf8Bytes(credencial);
            byte[] protegidos = Array.Empty<byte>();

            string temporal = ruta + ".tmp";

            try
            {
                protegidos = WindowsDpapi.Protect(datos);

                File.WriteAllBytes(temporal, protegidos);

                File.Move(
                    temporal,
                    ruta,
                    overwrite: true);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(datos);

                if (protegidos.Length > 0)
                    CryptographicOperations.ZeroMemory(protegidos);

                if (File.Exists(temporal))
                    File.Delete(temporal);
            }
        }

        private static OfflineCredentialSnapshot? LeerSnapshot(
            string ruta)
        {
            byte[] protegidos = File.ReadAllBytes(ruta);
            byte[] datos = Array.Empty<byte>();

            try
            {
                datos = WindowsDpapi.Unprotect(protegidos);

                return JsonSerializer.Deserialize<OfflineCredentialSnapshot>(
                    datos);
            }
            finally
            {
                CryptographicOperations.ZeroMemory(protegidos);

                if (datos.Length > 0)
                    CryptographicOperations.ZeroMemory(datos);
            }
        }

        /// <summary>
        /// Protege los datos mediante DPAPI con alcance CurrentUser.
        /// </summary>
        private static class WindowsDpapi
        {
            private const int UiForbidden = 0x1;

            [StructLayout(LayoutKind.Sequential)]
            private struct DataBlob
            {
                public int cbData;
                public IntPtr pbData;
            }

            [DllImport(
                "crypt32.dll",
                SetLastError = true,
                CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CryptProtectData(
                ref DataBlob dataIn,
                string? description,
                IntPtr optionalEntropy,
                IntPtr reserved,
                IntPtr prompt,
                int flags,
                out DataBlob dataOut);

            [DllImport(
                "crypt32.dll",
                SetLastError = true,
                CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CryptUnprotectData(
                ref DataBlob dataIn,
                IntPtr description,
                IntPtr optionalEntropy,
                IntPtr reserved,
                IntPtr prompt,
                int flags,
                out DataBlob dataOut);

            [DllImport("kernel32.dll")]
            private static extern IntPtr LocalFree(IntPtr memory);

            public static byte[] Protect(byte[] input)
            {
                return Transform(input, true);
            }

            public static byte[] Unprotect(byte[] input)
            {
                return Transform(input, false);
            }

            private static byte[] Transform(
                byte[] input,
                bool protect)
            {
                if (input.Length == 0)
                    throw new ArgumentException(
                        "No se pueden proteger datos vacíos.");

                DataBlob inputBlob = new()
                {
                    cbData = input.Length,
                    pbData = Marshal.AllocHGlobal(input.Length)
                };

                DataBlob outputBlob = default;

                Marshal.Copy(
                    input,
                    0,
                    inputBlob.pbData,
                    input.Length);

                try
                {
                    bool success = protect
                        ? CryptProtectData(
                            ref inputBlob,
                            "Ocean Desk Offline Authentication",
                            IntPtr.Zero,
                            IntPtr.Zero,
                            IntPtr.Zero,
                            UiForbidden,
                            out outputBlob)
                        : CryptUnprotectData(
                            ref inputBlob,
                            IntPtr.Zero,
                            IntPtr.Zero,
                            IntPtr.Zero,
                            IntPtr.Zero,
                            UiForbidden,
                            out outputBlob);

                    if (!success)
                    {
                        throw new Win32Exception(
                            Marshal.GetLastWin32Error());
                    }

                    byte[] resultado =
                        new byte[outputBlob.cbData];

                    Marshal.Copy(
                        outputBlob.pbData,
                        resultado,
                        0,
                        outputBlob.cbData);

                    return resultado;
                }
                finally
                {
                    if (inputBlob.pbData != IntPtr.Zero)
                    {
                        Marshal.Copy(
                            new byte[inputBlob.cbData],
                            0,
                            inputBlob.pbData,
                            inputBlob.cbData);

                        Marshal.FreeHGlobal(inputBlob.pbData);
                    }

                    if (outputBlob.pbData != IntPtr.Zero)
                    {
                        Marshal.Copy(
                            new byte[outputBlob.cbData],
                            0,
                            outputBlob.pbData,
                            outputBlob.cbData);

                        LocalFree(outputBlob.pbData);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Datos mínimos necesarios para validar una sesión offline.
    /// El archivo que contiene este objeto siempre se cifra con DPAPI.
    /// </summary>
    internal sealed class OfflineCredentialSnapshot
    {
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string NombreCompleto { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public string RoleCode { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;

        public List<PermisoModuloAutenticacionDto> Permisos { get; set; } = new();

        public DateTime CreatedAtUtc { get; set; }

        public DateTime ExpiresAtUtc { get; set; }

        public int FailedAttempts { get; set; }

        public DateTime? LockoutUntilUtc { get; set; }
    }
}
