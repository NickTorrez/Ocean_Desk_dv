using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Ocean_Desk_dv.Services.Authentication;

/// <summary>
/// Genera y verifica hashes de contraseñas utilizando PBKDF2-SHA256.
/// Formato almacenado:
/// PBKDF2-SHA256$iteraciones$salBase64$hashBase64
/// </summary>
public static class PasswordHasher
{
    private const string AlgorithmName = "PBKDF2-SHA256";

    /// <summary>
    /// Cantidad de iteraciones utilizada para generar nuevos hashes.
    /// Debe mantenerse sincronizada con la configuración acordada para Ocean Desk.
    /// </summary>
    public const int CurrentIterations = 210_000;

    private const int SaltSizeBytes = 16;
    private const int HashSizeBytes = 32;

    // Limita el trabajo de verificación si el valor almacenado estuviera manipulado.
    private const int MinimumSupportedIterations = 100_000;
    private const int MaximumSupportedIterations = 1_000_000;

    /// <summary>
    /// Genera un hash PBKDF2-SHA256 con una sal criptográficamente aleatoria.
    /// Devuelve el valor completo que debe almacenarse en User.PasswordHash.
    /// </summary>
    /// <param name="password">Contraseña en texto introducida por el usuario.</param>
    /// <returns>Cadena con algoritmo, iteraciones, sal y hash en Base64.</returns>
    public static string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException(
                "La contraseña no puede estar vacía.",
                nameof(password));
        }

        byte[] salt = RandomNumberGenerator.GetBytes(SaltSizeBytes);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] derivedHash = Array.Empty<byte>();

        try
        {
            derivedHash = Rfc2898DeriveBytes.Pbkdf2(
                passwordBytes,
                salt,
                CurrentIterations,
                HashAlgorithmName.SHA256,
                HashSizeBytes);

            return string.Join(
                "$",
                AlgorithmName,
                CurrentIterations.ToString(CultureInfo.InvariantCulture),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(derivedHash));
        }
        finally
        {
            CryptographicOperations.ZeroMemory(passwordBytes);
            CryptographicOperations.ZeroMemory(derivedHash);
        }
    }

    /// <summary>
    /// Verifica una contraseña frente al formato almacenado en User.PasswordHash.
    /// Devuelve false cuando la contraseña no coincide o el hash está mal formado.
    /// </summary>
    /// <param name="password">Contraseña introducida durante el inicio de sesión.</param>
    /// <param name="storedHash">Hash recuperado de SQL Server.</param>
    public static bool VerifyPassword(string? password, string? storedHash)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(storedHash))
            return false;

        string[] parts = storedHash.Split('$');
        if (parts.Length != 4 ||
            !string.Equals(parts[0], AlgorithmName, StringComparison.Ordinal))
        {
            return false;
        }

        if (!int.TryParse(
                parts[1],
                NumberStyles.None,
                CultureInfo.InvariantCulture,
                out int iterations) ||
            iterations < MinimumSupportedIterations ||
            iterations > MaximumSupportedIterations)
        {
            return false;
        }

        byte[] salt;
        byte[] expectedHash;

        try
        {
            salt = Convert.FromBase64String(parts[2]);
            expectedHash = Convert.FromBase64String(parts[3]);
        }
        catch (FormatException)
        {
            return false;
        }

        if (salt.Length != SaltSizeBytes || expectedHash.Length != HashSizeBytes)
        {
            CryptographicOperations.ZeroMemory(salt);
            CryptographicOperations.ZeroMemory(expectedHash);
            return false;
        }

        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] actualHash = Array.Empty<byte>();

        try
        {
            actualHash = Rfc2898DeriveBytes.Pbkdf2(
                passwordBytes,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                HashSizeBytes);

            return CryptographicOperations.FixedTimeEquals(
                actualHash,
                expectedHash);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(passwordBytes);
            CryptographicOperations.ZeroMemory(actualHash);
            CryptographicOperations.ZeroMemory(salt);
            CryptographicOperations.ZeroMemory(expectedHash);
        }
    }
}
