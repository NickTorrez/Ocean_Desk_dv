using Ocean_Desk_dv;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.Services;
using Ocean_Desk_dv.UI.Catalogs;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Catalogs;
using Ocean_Desk_dv.View.Services;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.View.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI
{
    public partial class FrmMainMenu : Form
    {
        #region Variables 
        // Se creo el objeto Login para instanciar enviar la referencia del formulario de login al formulario principal
        private FrmLogin login;
        private readonly int _usuarioId;
        private bool _permitirCerrarFormulario;
        private bool _cierreEnProceso;

        // Ejecuta una revisión de vencimientos cada 45 minutos.
        private readonly System.Windows.Forms.Timer _tmrAlertasVencimiento =
            new System.Windows.Forms.Timer
            {
                Interval = 45 * 60 * 1000
            };

        private bool _revisandoAlertasVencimiento;

        // Formulario actualmente alojado en el panel de contenido.
        private Form? _formularioActivo;

        // Colores para los botones del menú
        private Color colorNormal = Color.Transparent;
        private Color colorHover = Color.FromArgb(20, 52, 90);
        private Color colorActivo = Color.FromArgb(30, 70, 115);
        private Button botonActivo = null;

        private Color colorBarraActivo = Color.FromArgb(0, 190, 220); // Color de la barra lateral para el botón activo
        private Panel indicadorActivo; // Panel para indicar el botón activo

        #endregion

        #region Constructor y Inicialización
        public FrmMainMenu(FrmLogin login) : this(login, 1) { }
        public FrmMainMenu(FrmLogin login, int usuarioId)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            if (usuarioId <= 0)
                throw new ArgumentOutOfRangeException(nameof(usuarioId));

            InitializeComponent();
            this.login = login;
            _usuarioId = usuarioId;

            this.FormClosing += FrmMainMenu_FormClosing;

            _tmrAlertasVencimiento.Tick += TmrAlertasVencimiento_Tick;

            Shown += FrmMainMenu_Shown;

            FormClosed += (_, _) =>
            {
                _tmrAlertasVencimiento.Stop();
                _tmrAlertasVencimiento.Dispose();
            };

            // Inicializar el panel indicador para el botón activo
            indicadorActivo = new Panel();

            indicadorActivo.Width = 4;
            indicadorActivo.Height = btnReportes.Height;
            indicadorActivo.BackColor = colorBarraActivo;
            indicadorActivo.Visible = false;

            pnlMenu.Controls.Add(indicadorActivo);
            indicadorActivo.BringToFront();

            //Iniciar Timer
            tmrReloj.Start();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

            lblSeccion.Text = "Inicio";
            lblSubtitulo.Text = "Seleccione un módulo para comenzar";
        }

        /// <summary>
        /// Aloja un formulario hijo en el panel de contenido.
        /// Antes de abrir otro módulo, libera la vista anterior.
        /// </summary>
        /// <param name="formulario">Formulario que se mostrará en el panel.</param>
        private void AbrirFormularioEnPanel(Form formulario)
        {
            if (formulario is null)
                throw new ArgumentNullException(nameof(formulario));

            // Evita volver a alojar la misma instancia.
            if (ReferenceEquals(_formularioActivo, formulario))
                return;

            // Libera la vista anterior antes de abrir la nueva.
            CerrarFormularioActivo();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            _formularioActivo = formulario;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(formulario);

            formulario.BringToFront();
            formulario.Show();
        }

        /// <summary>
        /// Cierra y libera el formulario actualmente alojado en el panel.
        /// </summary>
        private void CerrarFormularioActivo()
        {
            Form? anterior = _formularioActivo;

            // Restablece primero la referencia para evitar conservar
            // una instancia que ya se está cerrando.
            _formularioActivo = null;

            if (anterior is null)
            {
                pnlContent.Controls.Clear();
                return;
            }

            pnlContent.Controls.Remove(anterior);

            // Primero cerrar y luego garantizar la liberación de recursos.
            if (!anterior.IsDisposed)
            {
                anterior.Close();

                if (!anterior.IsDisposed)
                    anterior.Dispose();
            }

            pnlContent.Controls.Clear();
        }

        /// <summary>
        /// Valida si se permite cerrar la aplicación y libera el módulo activo.
        /// </summary>
        private void FrmMainMenu_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Conserva la validación de caja, salvo que el cierre
            // ya haya sido autorizado explícitamente.
            if (!_permitirCerrarFormulario && !ValidarCajaParaSalir())
            {
                e.Cancel = true;
                return;
            }

            // El cierre está permitido: libera la vista activa,
            // su Presenter y sus recursos asociados.
            CerrarFormularioActivo();
        }
        #endregion

        #region Validación de Apertura/Cierre de Caja
        private bool TieneCajaAbierta()
        {
            try
            {
                using var context = new OceanDeskDbContext();

                return context.CashRegisters.Any(c =>
                    c.OpeningUserId == _usuarioId &&
                    c.Status == "Open");
            }
            catch (Exception ex)
            {
                FrmMessageBox.Show(
                    $"No fue posible verificar el estado de la caja.\n\n{ex.Message}",
                    "Verificación de caja",
                    MessageType.Error);

                return false;
            }
        }

        private bool ValidarCajaParaPuntoVenta()
        {
            if (TieneCajaAbierta())
                return true;

            FrmMessageBox.Show(
                "Debe realizar la apertura de caja antes de ingresar al Punto de Venta.",
                "Caja requerida",
                MessageType.Warning);

            return false;
        }

        private bool ValidarCajaParaSalir()
        {
            if (!TieneCajaAbierta())
                return true;

            FrmMessageBox.Show(
                "No puede salir del sistema mientras tenga una caja abierta.\n\n" +
                "Realice primero el cierre de caja y luego vuelva a intentarlo.",
                "Cierre de caja requerido",
                MessageType.Warning);

            return false;
        }
        #endregion

        #region Metodos de eventos
        /// <summary>
        /// Maneja el evento MouseEnter de los botones del menú, cambiando su color de fondo al color de hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null && boton != botonActivo)
            {
                boton.BackColor = colorHover;
            }
        }

        /// <summary>
        /// Maneja el evento MouseLeave de los botones del menú, restaurando su color de fondo al color normal si no es el botón activo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton_MouseLeave(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null && boton != botonActivo)
            {
                boton.BackColor = colorNormal;
            }
        }

        /// <summary>
        /// Maneja el evento Click de los botones del menú, seleccionando el botón y cambiando su color de fondo al color activo.
        /// </summary>
        /// <param name="boton"></param>
        private void SeleccionarBoton(Button boton)
        {
            // Restablecer el botón anteriormente seleccionado
            if (botonActivo != null)
            {
                botonActivo.BackColor = colorNormal;
            }

            // Seleccionar el nuevo botón
            botonActivo = boton;
            botonActivo.BackColor = colorActivo;

            // Posicionar la barra en el botón seleccionado
            indicadorActivo.Height = boton.Height;
            indicadorActivo.Top = boton.Top;
            indicadorActivo.Left = 0;

            indicadorActivo.Visible = true;
            indicadorActivo.BringToFront();
        }

        private void WindowButton_MouseEnter(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null)
            {
                boton.BackColor = Color.FromArgb(235, 242, 247);
            }
        }

        private void WindowButton_MouseLeave(object sender, EventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null)
            {
                boton.BackColor = Color.Transparent;
            }
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(220, 70, 70);
            btnClose.ForeColor = Color.White;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(18, 48, 71);
        }

        #endregion

        #region Botones y Controles
        /// <summary>
        /// Maneja el evento Click del botón de cerrar sesión, limpiando los campos del formulario de login, ocultando el formulario principal y mostrando el formulario de login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (!ValidarCajaParaSalir())
                return;

            // Detener las alertas antes de ocultar este menú.
            _tmrAlertasVencimiento.Stop();

            // Libera la vista actual antes de regresar al inicio de sesión.
            CerrarFormularioActivo();

            login.LimpiarCampos(); // Llamar al método LimpiarCampos() del formulario de login para limpiar los campos de usuario y contraseña

            this.Hide();

            login.Show();
        }

        /// <summary>
        /// Maneja el evento Click de los botones del menú, llamando al método SeleccionarBoton() para cambiar el color de fondo del botón seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnUsuarios);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnClientes);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnProductos);

            lblSeccion.Text = "Gestión de Productos";
            lblSubtitulo.Text = "Adición de platicas y control de recetas";

            // Crear la vista, el repositorio y el Presenter desde el punto de composición.
            // El formulario no construye directamente el contexto ni consulta la base de datos.
            FrmProductos productos = new FrmProductos();
            ProductosPresenter presenter = new ProductosPresenter(
                productos,
                OceanDeskRepositoryFactory.CrearProductosRepository());

            productos.VincularPresenter(presenter);
            AbrirFormularioEnPanel(productos);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnInventario);

            lblSeccion.Text = "Control de Inventario";
            lblSubtitulo.Text = "Existencia y movimientos de materia prima";

            // Crear la vista y sus dependencias.
            FrmInventario inventario = new FrmInventario();

            InventarioPresenter presenter = new InventarioPresenter(
                inventario,
                OceanDeskRepositoryFactory.CrearInventarioRepository());

            // Inicializa las categorías, existencias y movimientos.
            inventario.VincularPresenter(presenter);

            // Abrir en el panel principal sin modificar el diseño del menú.
            AbrirFormularioEnPanel(inventario);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCompras);

            lblSeccion.Text = "Gestión de Compras";
            lblSubtitulo.Text = "Control y seguimiento de compras a proveedores";
            // Crear la vista, el repositorio y el Presenter
            // desde el punto de composición.
            FrmCompras compras = new FrmCompras();

            ComprasPresenter presenter = new ComprasPresenter(
                compras,
                OceanDeskRepositoryFactory.CrearComprasRepository());

            // Asociar el Presenter e inicializar los datos.
            compras.VincularPresenter(presenter);
            AbrirFormularioEnPanel(compras);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (!ValidarCajaParaPuntoVenta())
                return;

            SeleccionarBoton(btnVentas);

            lblSeccion.Text = "Punto de Venta";
            lblSubtitulo.Text = "Control y Toma de Ordenes";

            FrmPuntoVenta ventas = new FrmPuntoVenta(_usuarioId);
            AbrirFormularioEnPanel(ventas);
        }
        
        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnFacturacion);

            lblSeccion.Text = "Facturación";
            lblSubtitulo.Text = "Gestión y Consultas de Comprobantes";

            FrmFacturacion facturacion = new FrmFacturacion(_usuarioId);
            AbrirFormularioEnPanel(facturacion);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnProveedores);

            lblSeccion.Text = "Gestión de Proveedores";
            lblSubtitulo.Text = "Administración y seguimiento de proveedores";

            FrmProveedores proveedores = new FrmProveedores();
            ProveedoresPresenter presenter = new ProveedoresPresenter(
                proveedores,
                OceanDeskRepositoryFactory.CrearProveedoresRepository());

            proveedores.VincularPresenter(presenter);
            AbrirFormularioEnPanel(proveedores);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnEmpleados);
        }

        private void btnMesas_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnMesas);

            lblSeccion.Text = "Gestión de Mesas";
            lblSubtitulo.Text = "Disponibilidad y asignación de mesas";

            // 1. Crear la vista.
            FrmMesasReservas mesas = new FrmMesasReservas();

            // 2. Crear el Presenter con el repositorio correspondiente.
            MesasReservasPresenter presenter = new MesasReservasPresenter(
                mesas,
                OceanDeskRepositoryFactory.CrearMesasReservasRepository());

            // 3. Vincular el Presenter e inicializar el módulo.
            mesas.VincularPresenter(presenter);

            // 4. Mostrar la vista en el panel principal.
            AbrirFormularioEnPanel(mesas);
        }

        private void btnCocina_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCocina);

            lblSeccion.Text = "Control de Pedidos";
            lblSubtitulo.Text = "Gestión y seguimiento de pedidos en cocina";

            FrmCocinaPedidos cocina = new FrmCocinaPedidos();
            AbrirFormularioEnPanel(cocina);
        }

        private void btnBitacoras_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnBitacoras);
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            // Actualiza la hora y la fecha cada segundo
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt"); // Formato 12 horas con AM/PM
            lblFecha.Text = DateTime.Now.ToLongDateString(); // Ejemplo: "lunes, 24 de mayo de 2026"
        }

        /// <summary>
        /// Realiza la primera revisión cuando el menú principal ya se mostró.
        /// Después inicia las revisiones periódicas.
        /// </summary>
        private void FrmMainMenu_Shown(object? sender, EventArgs e)
        {
            RevisarAlertasVencimiento();

            if (Visible && !IsDisposed && !_cierreEnProceso)
                _tmrAlertasVencimiento.Start();
        }

        /// <summary>
        /// Ejecuta la revisión periódica y reinicia el intervalo al terminar.
        /// </summary>
        private void TmrAlertasVencimiento_Tick(
            object? sender,
            EventArgs e)
        {
            _tmrAlertasVencimiento.Stop();

            try
            {
                RevisarAlertasVencimiento();
            }
            finally
            {
                if (Visible && !IsDisposed && !_cierreEnProceso)
                    _tmrAlertasVencimiento.Start();
            }
        }

        /// <summary>
        /// Clasifica los lotes que requieren atención y muestra un único mensaje
        /// con las secciones correspondientes.
        /// </summary>
        private void RevisarAlertasVencimiento()
        {
            if (_revisandoAlertasVencimiento ||
                IsDisposed ||
                !Visible ||
                _cierreEnProceso)
            {
                return;
            }

            _revisandoAlertasVencimiento = true;

            try
            {
                using var repositorio =
                    OceanDeskRepositoryFactory.CrearInventarioRepository();

                IReadOnlyList<AlertaVencimientoInventarioDto> alertas =
                    repositorio.ObtenerAlertasVencimiento();

                if (alertas.Count == 0)
                    return;

                DateOnly hoy = DateOnly.FromDateTime(DateTime.Today);
                DateOnly manana = hoy.AddDays(1);

                var vencenManana = alertas
                    .Where(a => a.ExpirationDate == manana)
                    .ToList();

                var vencenHoy = alertas
                    .Where(a => a.ExpirationDate == hoy)
                    .ToList();

                var vencidos = alertas
                    .Where(a => a.ExpirationDate < hoy)
                    .ToList();

                var mensaje = new StringBuilder();

                void AgregarSeccion(
                    string titulo,
                    IEnumerable<AlertaVencimientoInventarioDto> lotes)
                {
                    var lista = lotes.ToList();

                    if (lista.Count == 0)
                        return;

                    mensaje.AppendLine(titulo);

                    foreach (var lote in lista)
                    {
                        string codigoLote =
                             string.IsNullOrWhiteSpace(lote.LotCode) ||
                             lote.LotCode.StartsWith(
                                 "AUTO-",
                                 StringComparison.OrdinalIgnoreCase)
                                     ? "Sin código"
                                     : lote.LotCode.Trim();

                        string nombreIngrediente =
                            CatalogoTraducciones.TraducirIngrediente(
                                lote.ProductCode,
                                lote.ProductName);

                        string unidad =
                            CatalogoTraducciones.TraducirUnidad(
                                null,
                                lote.UnitName);

                        mensaje.AppendLine(
                            $"{lote.ProductCode} - {nombreIngrediente}");

                        mensaje.AppendLine(
                            $"  Lote: {codigoLote}");

                        mensaje.AppendLine(
                            $"  Fecha de vencimiento: " +
                            $"{lote.ExpirationDate:dd/MM/yyyy}");

                        mensaje.AppendLine(
                            $"  Existencias del lote: " +
                            $"{lote.RemainingQuantity:0.####} {unidad}");

                        mensaje.AppendLine();
                    }
                }

                AgregarSeccion(
                    "PRÓXIMOS A VENCER (VENCEN MAÑANA)",
                    vencenManana);

                AgregarSeccion(
                    "VENCEN HOY",
                    vencenHoy);

                AgregarSeccion(
                    "PRODUCTOS VENCIDOS CON EXISTENCIAS",
                    vencidos);

                if (mensaje.Length == 0)
                    return;

                mensaje.AppendLine(
                    "Este aviso se volverá a revisar cada 45 minutos.");

                mensaje.AppendLine(
                    "Los lotes dejarán de aparecer cuando ya no tengan " +
                    "existencias registradas.");

                FrmMessageBox.Show(
                 mensaje.ToString(),
                 "Alertas de vencimiento de inventario",
                 MessageType.Warning,
                 this);
            }
            catch (Exception ex)
            {
                // Un fallo en la revisión no debe cerrar ni interrumpir
                // el funcionamiento del menú principal.
                System.Diagnostics.Debug.WriteLine(
                    $"No se pudieron revisar los vencimientos: {ex}");
            }
            finally
            {
                _revisandoAlertasVencimiento = false;
            }
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnCaja);

            lblSeccion.Text = "Manejo de Caja";
            lblSubtitulo.Text =
                "Entrada, salida y cierre diario de dinero";

            // 1. Crear la vista.
            FrmCaja caja = new FrmCaja(_usuarioId);

            // 2. Crear el Presenter y entregarle el repositorio.
            CajaPresenter presenter = new CajaPresenter(
                caja,
                OceanDeskRepositoryFactory.CrearCajaRepository());

            // 3. Vincular el Presenter e inicializar el módulo.
            caja.VincularPresenter(presenter);

            // 4. Mostrar la vista en el panel principal.
            AbrirFormularioEnPanel(caja);
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnPromociones);
        }

        private void btnFidelizacion_Click(object sender, EventArgs e)
        {
            SeleccionarBoton(btnFidelizacion);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.Text = "❐";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.Text = "□";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Evita ejecutar el proceso de cierre más de una vez.
            if (_cierreEnProceso)
                return;

            // No cerrar si la caja continúa abierta o no pudo verificarse.
            if (!ValidarCajaParaSalir())
                return;

            // Detener las alertas antes de ocultar este menú.
            _tmrAlertasVencimiento.Stop();

            _cierreEnProceso = true;
            _permitirCerrarFormulario = true;

            // 1. Cierra el menú.
            // Su evento FormClosing libera el módulo activo y su Presenter.
            this.Close();

            // 2. Cierra el formulario de carga, que permanece oculto.
            FrmLoading? formularioCarga = Application.OpenForms
                .OfType<FrmLoading>()
                .FirstOrDefault();

            if (formularioCarga != null && !formularioCarga.IsDisposed)
                formularioCarga.Close();

            // 3. Cierra el formulario principal del ciclo de mensajes.
            if (login != null && !login.IsDisposed)
                login.Close();
        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            SeleccionarBoton(btnReportes);

            lblSeccion.Text = "Reportes";
            lblSubtitulo.Text = "Indicadores y comportamiento general";

            FrmReportes reportes = new FrmReportes(OceanDeskRepositoryFactory.CrearReportesRepository());

            AbrirFormularioEnPanel(reportes);
        }
        #endregion

    }
}

