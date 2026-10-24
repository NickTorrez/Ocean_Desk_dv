using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Ocean_Desk_dv.View.Localization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.View.MessageBox
{
    /// <summary>
    /// Formulario modal para registrar operaciones manuales de inventario.
    /// No accede directamente a la base de datos.
    /// </summary>
    public partial class FrmMovimientoInventario : Form
    {
        private const decimal StockMaximo = 99999999.9999m;
        private const int DiasAdvertenciaVencimiento = 7;

        private readonly string _tipoMovimiento;
        private readonly ExistenciaInventarioDto _producto;

        /// <summary>
        /// Solicitud confirmada que recibirá la vista y posteriormente
        /// el Presenter. Permanece null si el usuario cancela.
        /// </summary>
        public SolicitudMovimientoInventarioDto? Resultado { get; private set; }

        /// <summary>
        /// Prefijos autorizados para los códigos de productos de Ocean Desk.
        /// Deben coincidir con los definidos en FrmProductos.
        /// </summary>
        private static readonly HashSet<string> PrefijosProductoPermitidos =
           new(StringComparer.OrdinalIgnoreCase)
            {
                "PRD", // Productos genéricos o terminados.
                "CEV", // Ceviches.
                "BEB", // Bebidas.
                "ENT", // Entradas y acompañamientos.
                "MAR", // Mariscos.
                "PES", // Pescados.
                "CAR", // Carnes y proteínas terrestres.
                "ENS", // Ensaladas.
                "POS", // Postres.
                "SOP", // Sopas y caldos.
                "COM", // Combos y promociones.
                "SAL", // Salsas y aderezos.
                "INS", // Insumos generales.
                "CON", // Condimentos y especias.6*+/d

                "PAN", // Panadería.
                "LAC", // Lácteos.
                "ING" // Ingredientes identificados para el control de inventario
            };

        /// <summary>
        /// Construye el diálogo con el producto seleccionado en la tabla
        /// de existencias.
        /// </summary>
        /// <param name="tipoMovimiento">
        /// Tipo definido en TiposMovimientoInventario.
        /// </param>
        /// <param name="producto">
        /// Ingrediente seleccionado por el usuario.
        /// </param>
        public FrmMovimientoInventario(string tipoMovimiento,
            ExistenciaInventarioDto producto)
        {
            InitializeComponent();

            _producto = producto ??
                throw new ArgumentNullException(nameof(producto));

            _tipoMovimiento = NormalizarTipoMovimiento(tipoMovimiento);

            ConfigurarFormulario();
            ConfigurarControles();
            MostrarDatosProducto();
            ConfigurarOperacion();
            ConectarEventos();
        }

        /// <summary>
        /// Configura las propiedades generales del formulario.
        /// </summary>
        private void ConfigurarFormulario()
        {
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            MaximizeBox = false;
            MinimizeBox = false;

            BackColor = Color.White;

            // Evita que el botón Confirmar cierre el formulario
            // automáticamente antes de completar las validaciones.
            btnConfirmar.DialogResult = DialogResult.None;
            btnCancelar.DialogResult = DialogResult.Cancel;

            AcceptButton = btnConfirmar;
            CancelButton = btnCancelar;
        }

        /// <summary>
        /// Configura cantidades y fechas con valores seguros.
        /// </summary>
        private void ConfigurarControles()
        {
            nudCantidad.DecimalPlaces = 4;
            nudCantidad.Maximum = StockMaximo;
            nudCantidad.ThousandsSeparator = true;
            nudCantidad.Increment = 0.1m;

            // Un ajuste representa el stock final deseado y admite cero.
            // Las demás operaciones necesitan una cantidad positiva.
            nudCantidad.Minimum =
                _tipoMovimiento == TiposMovimientoInventario.Ajuste
                    ? 0m
                    : 0.0001m;

            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.ShowCheckBox = true;
            dtpVencimiento.MinDate = DateTime.Today;
            dtpVencimiento.Value = DateTime.Today;
            dtpVencimiento.Checked = false;

            nudStockMinimo.DecimalPlaces = 4;
            nudStockMinimo.Minimum = 0m;
            nudStockMinimo.Maximum = StockMaximo;
            nudStockMinimo.Increment = 0.1m;
            nudStockMinimo.ThousandsSeparator = true;

            nudStockMinimo.Value = Math.Max(
                nudStockMinimo.Minimum,
                Math.Min(
                    nudStockMinimo.Maximum,
                    _producto.MinimumStock));

            txtObservaciones.MaxLength = 500;
            txtObservaciones.Multiline = true;
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
        }

        /// <summary>
        /// Muestra el producto y el saldo actual sin permitir cambiarlo
        /// desde este diálogo.
        /// </summary>
        private void MostrarDatosProducto()
        {
            string nombreIngrediente = CatalogoTraducciones.TraducirIngrediente(
            _producto.ProductCode,
            _producto.ProductName);

            string nombreUnidad =
                CatalogoTraducciones.TraducirUnidad(
                    null,
                    _producto.UnitName);

            lblProducto.Text = $"{_producto.ProductCode} - {nombreIngrediente}";

            lblUnidad.Text = $"Unidad: {CatalogoTraducciones.TraducirUnidad(
                null,
                _producto.UnitName)}";

            lblResumenStock.Text =
                $"Stock actual: {_producto.CurrentStock:0.####} " +
                $"{nombreUnidad} | " +
                $"Stock mínimo: {_producto.MinimumStock:0.####} " +
                $"{nombreUnidad}";

            Text = ObtenerTituloOperacion();
            lblTitulo.Text = ObtenerTituloOperacion();

            lblSubtitulo.Text = "Verifique los datos antes de confirmar la operación.";
        }

        /// <summary>
        /// Configura los textos y valores iniciales según la operación solicitada.
        /// </summary>
        private void ConfigurarOperacion()
        {
            switch (_tipoMovimiento)
            {
                case TiposMovimientoInventario.Salida:
                    lblCantidad.Text = "Cantidad a salir";
                    btnConfirmar.Text = "REGISTRAR SALIDA";
                    nudCantidad.Value = 1m;
                    break;

                case TiposMovimientoInventario.Ajuste:
                    lblCantidad.Text = "Stock final deseado";
                    btnConfirmar.Text = "GUARDAR AJUSTE";

                    nudCantidad.Value = Math.Max(
                        nudCantidad.Minimum,
                        Math.Min(
                            nudCantidad.Maximum,
                            _producto.CurrentStock));
                    break;

                case TiposMovimientoInventario.Perdida:
                    lblCantidad.Text = "Cantidad perdida";
                    btnConfirmar.Text = "REGISTRAR PÉRDIDA";
                    nudCantidad.Value = 1m;
                    break;

                default:
                    throw new InvalidOperationException(
                        "El tipo de movimiento no está permitido.");
            }

            // pnlDatosLote es el encabezado, no el panel de los campos de lote.
            pnlDatosLote.Visible = true;

            ActualizarDisponibilidadCamposLote();
        }

        /// <summary>
        /// Conecta los botones del diálogo.
        /// Estos eventos se conectan en código para evitar suscripciones dobles.
        /// </summary>
        private void ConectarEventos()
        {
            btnConfirmar.Click += (_, _) => ConfirmarMovimiento();

            nudCantidad.ValueChanged += (_, _) =>
                ActualizarDisponibilidadCamposLote();

            // No hace falta conectar Click para Cancelar:
            // DialogResult.Cancel y CancelButton gestionan su cierre.
        }

        /// <summary>
        /// El stock mínimo aparece en todas las operaciones.
        /// Solo se permite editarlo en un ajuste.
        /// El vencimiento aplica cuando el ajuste incrementa el stock.
        /// </summary>
        private void ActualizarDisponibilidadCamposLote()
        {
            bool esAjuste =
                _tipoMovimiento == TiposMovimientoInventario.Ajuste;

            bool requiereVencimiento =
                esAjuste &&
                nudCantidad.Value > _producto.CurrentStock;

            // Mantener visible el stock mínimo.
            pnlLabelCodigo.Visible = true;
            pnlInputStockMin.Visible = true;

            lblStockMinimo.Text = "Stock mínimo";
            nudStockMinimo.Enabled = esAjuste;

            // La fecha solo se utiliza cuando se incorporan existencias.
            pnlLabelVenicmiento.Visible = requiereVencimiento;
            pnlInputVencimiento.Visible = requiereVencimiento;

            lblVencimiento.Enabled = requiereVencimiento;
            dtpVencimiento.Enabled = requiereVencimiento;

            if (!requiereVencimiento)
                dtpVencimiento.Checked = false;
        }

        /// <summary>
        /// Muestra u oculta los campos de lote y vencimiento,
        /// utilizando únicamente las cuatro filas existentes.
        /// </summary>
        private void ConfigurarVisibilidadDatosLote(bool mostrar)
        {
            tlpInputInfo.SuspendLayout();

            try
            {
                // Las filas 2 y 3 contienen los datos del lote.
                pnlLabelCodigo.Visible = mostrar;
                pnlLabelVenicmiento.Visible = mostrar;

                pnlInputStockMin.Visible = mostrar;
                pnlInputVencimiento.Visible = mostrar;

                if (mostrar)
                {
                    // Restaurar las proporciones definidas en el diseñador.
                    tlpInputInfo.RowStyles[2].SizeType =
                        SizeType.Percent;

                    tlpInputInfo.RowStyles[2].Height =
                        13.333333F;

                    tlpInputInfo.RowStyles[3].SizeType =
                        SizeType.Percent;

                    tlpInputInfo.RowStyles[3].Height =
                        20F;
                }
                else
                {
                    // Colapsar las filas 2 y 3 cuando no aplican.
                    tlpInputInfo.RowStyles[2].SizeType =
                        SizeType.Absolute;

                    tlpInputInfo.RowStyles[2].Height = 0F;

                    tlpInputInfo.RowStyles[3].SizeType =
                        SizeType.Absolute;

                    tlpInputInfo.RowStyles[3].Height = 0F;
                }
            }
            finally
            {
                tlpInputInfo.ResumeLayout(true);
                tlpInputInfo.PerformLayout();
            }
        }
        /// <summary>
        /// Valida la captura y devuelve la solicitud confirmada.
        /// </summary>
        private void ConfirmarMovimiento()
        {
            if (!ValidarCantidad())
                return;

            if (!ValidarObservaciones())
                return;

            bool incrementaStock =
            _tipoMovimiento == TiposMovimientoInventario.Ajuste &&
            nudCantidad.Value > _producto.CurrentStock;

            DateOnly? vencimiento = null;

            if (incrementaStock &&
                !ValidarVencimiento(out vencimiento))
            {
                return;
            }

            bool mismoStock = nudCantidad.Value == _producto.CurrentStock;

            bool mismoMinimo =
                nudStockMinimo.Value == _producto.MinimumStock;

            if (_tipoMovimiento == TiposMovimientoInventario.Ajuste &&
                mismoStock &&
                mismoMinimo)
            {
                MostrarMensaje(
                    "El stock y el stock mínimo coinciden con los valores actuales. " +
                    "No hay cambios que guardar.",
                    "Ajuste innecesario",
                    MessageType.Warning);

                return;
            }

            if (!ConfirmarOperacion(vencimiento))
                return;

            // El diálogo devuelve los datos; el Presenter y el repositorio
            // serán responsables de registrar el movimiento.
            Resultado = new SolicitudMovimientoInventarioDto
            {
                ProductId = _producto.ProductId,
                MovementType = _tipoMovimiento,
                Quantity = nudCantidad.Value,
                LotCode = null,
                MinimumStock =
                _tipoMovimiento == TiposMovimientoInventario.Ajuste
                    ? nudStockMinimo.Value
                    : null,
                ExpirationDate = vencimiento,
                Notes = string.IsNullOrWhiteSpace(txtObservaciones.Text)
                    ? null
                    : txtObservaciones.Text.Trim()
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Comprueba que la cantidad tenga un valor válido para la operación.
        /// </summary>
        private bool ValidarCantidad()
        {
            bool esAjuste =
                _tipoMovimiento == TiposMovimientoInventario.Ajuste;

            if (esAjuste)
            {
                if (nudCantidad.Value < 0m)
                {
                    MostrarMensaje(
                        "El stock final no puede ser negativo.",
                        "Cantidad inválida",
                        MessageType.Warning);

                    nudCantidad.Focus();
                    return false;
                }

                return true;
            }

            if (nudCantidad.Value <= 0m)
            {
                MostrarMensaje(
                    "La cantidad debe ser mayor que cero.",
                    "Cantidad inválida",
                    MessageType.Warning);

                nudCantidad.Focus();
                return false;
            }

            if (nudCantidad.Value > _producto.CurrentStock &&
                (
                    _tipoMovimiento == TiposMovimientoInventario.Salida ||
                    _tipoMovimiento == TiposMovimientoInventario.Perdida
                ))
            {
                MostrarMensaje(
                    $"La cantidad solicitada supera el stock actual " +
                    $"({_producto.CurrentStock:0.####} {_producto.UnitName}).",
                    "Stock insuficiente",
                    MessageType.Warning);

                nudCantidad.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Comprueba los motivos obligatorios para ajustes y pérdidas.
        /// </summary>
        private bool ValidarObservaciones()
        {
            string notas = txtObservaciones.Text.Trim();

            bool requiereMotivo =
                _tipoMovimiento == TiposMovimientoInventario.Ajuste ||
                _tipoMovimiento == TiposMovimientoInventario.Perdida;

            if (requiereMotivo && string.IsNullOrWhiteSpace(notas))
            {
                MostrarMensaje(
                    "Debe indicar el motivo de la operación.",
                    "Motivo requerido",
                    MessageType.Warning);

                txtObservaciones.Focus();
                return false;
            }

            bool esAjusteAscendente =
                _tipoMovimiento == TiposMovimientoInventario.Ajuste &&
                nudCantidad.Value > _producto.CurrentStock;

            int limiteCaracteres = esAjusteAscendente ? 250 : 500;

            if (notas.Length > limiteCaracteres)
            {
                MostrarMensaje(
                    esAjusteAscendente
                        ? "Al aumentar el stock, las observaciones del lote " +
                          "no pueden superar los 250 caracteres."
                        : "Las observaciones no pueden superar los 500 caracteres.",
                    "Observaciones inválidas",
                    MessageType.Warning);

                txtObservaciones.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida la fecha de vencimiento cuando el usuario decide especificarla.
        /// </summary>
        private bool ValidarVencimiento(out DateOnly? vencimiento)
        {
            vencimiento = null;

            // Los insumos que no requieren vencimiento pueden dejarlo sin marcar.
            if (!dtpVencimiento.Checked)
                return true;

            DateTime fechaSeleccionada = dtpVencimiento.Value.Date;
            DateTime hoy = DateTime.Today;

            // Defensa adicional: aunque el selector limite las fechas,
            // verificamos el valor antes de construir la solicitud.
            if (fechaSeleccionada < hoy)
            {
                MostrarMensaje(
                    "No se puede registrar un lote cuya fecha de vencimiento ya pasó.",
                    "Fecha de vencimiento inválida",
                    MessageType.Warning);

                dtpVencimiento.Focus();
                return false;
            }

            vencimiento = DateOnly.FromDateTime(fechaSeleccionada);
            return true;
        }

        /// <summary>
        /// Solicita confirmación con el MessageBox estandarizado.
        /// Si el vencimiento es próximo, incluye una advertencia adicional.
        /// </summary>
        private bool ConfirmarOperacion(DateOnly? vencimiento)
        {
            string nombreIngrediente =
                CatalogoTraducciones.TraducirIngrediente(
                    _producto.ProductCode,
                    _producto.ProductName);

            string nombreUnidad =
                CatalogoTraducciones.TraducirUnidad(
                    null,
                    _producto.UnitName);

            bool esAjusteAscendente =
                _tipoMovimiento == TiposMovimientoInventario.Ajuste
                && nudCantidad.Value > _producto.CurrentStock;

            string detalle;

            if (_tipoMovimiento == TiposMovimientoInventario.Ajuste)
            {
                detalle =
                    $"Stock actual: {_producto.CurrentStock:0.####} " +
                    $"{nombreUnidad}.\n" +
                    $"Stock final deseado: {nudCantidad.Value:0.####} " +
                    $"{nombreUnidad}.";

                if (esAjusteAscendente)
                {
                    decimal incremento =
                        nudCantidad.Value - _producto.CurrentStock;

                    detalle +=
                        $"\nCantidad que se agregará: {incremento:0.####} " +
                        $"{nombreUnidad}.";
                }

                detalle +=
                    $"\nStock mínimo configurado: " +
                    $"{nudStockMinimo.Value:0.####} {nombreUnidad}.";
            }
            else
            {
                detalle =
                    $"Cantidad: {nudCantidad.Value:0.####} " +
                    $"{nombreUnidad}.";
            }

            string mensaje =
                $"¿Desea confirmar la operación " +
                $"'{ObtenerTituloOperacion()}' para {nombreIngrediente}?\n\n" +
                detalle;

            if (esAjusteAscendente && vencimiento.HasValue)
            {
                mensaje +=
                    $"\n\nLOTE Y VENCIMIENTO\n" +
                    $"La fecha {vencimiento.Value:dd/MM/yyyy} se aplicará " +
                    "al lote que recibe el incremento. Los lotes anteriores " +
                    "conservan sus fechas de vencimiento.";

                if (esAjusteAscendente)
                {
                    mensaje +=
                        "\nEl incremento se registrará en un lote independiente " +
                        "sin necesidad de introducir un código de lote manual.";
                }

                if (_producto.ExpirationDate.HasValue)
                {
                    mensaje +=
                        $"\nEl vencimiento más próximo que ya tiene el inventario " +
                        $"es {_producto.ExpirationDate.Value:dd/MM/yyyy}.";
                }

                mensaje +=
                    "\nLa tabla de existencias muestra el vencimiento más próximo " +
                    "entre los lotes que aún tienen saldo.";

            }

            if (vencimiento.HasValue)
            {
                DateOnly hoy =
                    DateOnly.FromDateTime(DateTime.Today);

                int diasRestantes =
                    vencimiento.Value.DayNumber - hoy.DayNumber;

                if (diasRestantes >= 0 &&
                    diasRestantes <= DiasAdvertenciaVencimiento)
                {
                    string plazo = diasRestantes switch
                    {
                        0 => "vence hoy",
                        1 => "vence mañana",
                        _ => $"vence dentro de {diasRestantes} días"
                    };

                    mensaje +=
                        $"\n\nADVERTENCIA DE VENCIMIENTO\n" +
                        $"El lote {plazo} " +
                        $"({vencimiento.Value:dd/MM/yyyy}). " +
                        "Verifique que la fecha sea correcta.";
                }
            }

            DialogResult respuesta =
                global::Ocean_Desk_dv.UI.MessageBox.FrmMessageBox.Show(
                    mensaje,
                    "Confirmar movimiento de inventario",
                    MessageType.Confirmation);

            return respuesta == DialogResult.Yes;
        }
        /// <summary>
        /// Normaliza y valida el tipo de movimiento recibido.
        /// </summary>
        private static string NormalizarTipoMovimiento(string tipo)
        {
            string valor = tipo?.Trim() ?? string.Empty;

            if (valor == TiposMovimientoInventario.Salida ||
                valor == TiposMovimientoInventario.Ajuste ||
                valor == TiposMovimientoInventario.Perdida)
            {
                return valor;
            }

            throw new ArgumentException(
                "Este formulario solo admite salida, ajuste o pérdida.",
                nameof(tipo));
        }

        /// <summary>
        /// Obtiene el título correspondiente a la operación.
        /// </summary>
        private string ObtenerTituloOperacion()
        {
            return _tipoMovimiento switch
            {
                TiposMovimientoInventario.Salida => "Registrar salida",
                TiposMovimientoInventario.Ajuste => "Ajustar inventario",
                TiposMovimientoInventario.Perdida => "Registrar pérdida o daño",
                _ => "Movimiento de inventario"
            };
        }
        /// <summary>
        /// Muestra un mensaje a través del cuadro personalizado de Ocean Desk.
        /// </summary>
        private static void MostrarMensaje(
            string mensaje,
            string titulo,
            MessageType tipo)
        {
            global::Ocean_Desk_dv.UI.MessageBox.FrmMessageBox.Show(
                mensaje,
                titulo,
                tipo);
        }

    }
}
