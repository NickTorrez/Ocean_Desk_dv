using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services;
using Ocean_Desk_dv.Services.Interfaces_Services;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace Ocean_Desk_dv.UI.Catalogs
{
    /// <summary>
    /// Formulario que muestra los reportes de ventas y productos.
    /// </summary>
    public partial class FrmReportes : Form, IReportesView
    {
        private ReportesPresenter? _presenter;

        #region Constructor
        public FrmReportes() : this(OceanDeskRepositoryFactory.CrearReportesRepository())
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia del formulario FrmReportes.
        /// </summary>
        public FrmReportes(IReportesRepository repository)
        {
            InitializeComponent();

            cmbPeriodo.Items.Clear();
            cmbPeriodo.Items.AddRange(new object[]
            {
                "Hoy",
                "Últimos 7 días",
                "Este mes",
                "Este año",
                "Personalizado"
            });

            cmbPeriodo.SelectedItem = "Hoy";

            btnActualizar.Click += btnActualizar_Click;
            cmbPeriodo.SelectedIndexChanged += ComboBoxPeriodo_SelectedIndexChanged;
            FormClosed += FrmReportes_FormClosed;

            flpMovimientosRecientes.SizeChanged += FlpMovimientosRecientes_SizeChanged;

            ConfigurarGraficos();

            _presenter = new ReportesPresenter(this, repository);

            _presenter.Inicializar();
        }
        #endregion

        #region Implementación de IReportesView

        public string PeriodoSeleccionado
        {
            get => cmbPeriodo.SelectedItem?.ToString() ?? "Hoy";
            set
            {
                if (cmbPeriodo.Items.Contains(value))
                    cmbPeriodo.SelectedItem = value;
            }
        }

        public DateTime FechaDesde
        {
            get => dtpDesde.Value.Date;
            set => dtpDesde.Value = value.Date;
        }

        public DateTime FechaHasta
        {
            get => dtpHasta.Value.Date;
            set => dtpHasta.Value = value.Date;
        }

        public event EventHandler? PeriodoChanged;
        public event EventHandler? ActualizarClicked;

        /// <summary>
        /// Muestra la cantidad de ventas completadas del período seleccionado.
        /// </summary>
        public void MostrarVentas(int cantidadVentas, bool esHoy)
        {
            lblTituloVentas.Text = esHoy ? "Ventas del día" : "Ventas del período";
            lblVentasHoy.Text = cantidadVentas.ToString("N0");
            lblDetalleVentas.Text = esHoy
                ? "Ventas completadas hoy"
                : "Ventas completadas en el período";
        }

        /// <summary>
        /// Muestra el total monetario de ingresos.
        /// </summary>
        public void MostrarIngresos(decimal ingresos)
        {
            lblIngresos.Text = $"C$ {ingresos:N2}";
            lblDetalleIngresos.Text = "Total de ventas completadas";
        }

        /// <summary>
        /// Muestra la cantidad de productos activos registrados.
        /// </summary>
        public void MostrarProductosRegistrados(int cantidadProductos)
        {
            lblProductos.Text = cantidadProductos.ToString("N0");
            lblDetalleProductos.Text = "Productos activos registrados";
        }

        /// <summary>
        /// Indica que el indicador de stock todavía no puede calcularse
        /// con el modelo actual de la base de datos.
        /// </summary>
        public void MostrarStockBajo(
            int ingredientesBajoMinimo,
             int ingredientesAgotados)
        {
            lblStockBajo.Text =
                ingredientesBajoMinimo.ToString("N0");

            lblDetalleStock.Text =
                $"{ingredientesAgotados:N0} agotados · " +
                "stock positivo ≤ mínimo";

            lblStockBajo.ForeColor =
                ingredientesBajoMinimo > 0
                    ? Color.FromArgb(190, 66, 66)
                    : Color.FromArgb(22, 163, 74);
        }


        /// <summary>
        /// Actualiza los indicadores y la lista de actividad de inventario.
        /// Los contadores son operaciones registradas durante la jornada.
        /// </summary>
        public void MostrarActividadInventario(
            ReporteActividadInventarioDto actividad)
        {
            ArgumentNullException.ThrowIfNull(actividad);

            lblTituloActividad.Text =
                $"ACTIVIDAD DE INVENTARIO · HOY ({DateTime.Today:dd/MM/yyyy})";

            lblSalidasHoy.Text =
                actividad.CantidadSalidas.ToString("N0");

            lblPerdidasHoy.Text =
                actividad.CantidadPerdidas.ToString("N0");

            lblAjustesHoy.Text =
                actividad.CantidadAjustes.ToString("N0");

            lblDetalleSalidasHoy.Text = "Operaciones registradas";
            lblDetallePerdidasHoy.Text = "Operaciones registradas";
            lblDetalleAjustesHoy.Text = "Operaciones registradas";

            flpMovimientosRecientes.SuspendLayout();

            try
            {
                // Eliminar y liberar los controles de la actualización anterior.
                while (flpMovimientosRecientes.Controls.Count > 0)
                {
                    Control control = flpMovimientosRecientes.Controls[0];

                    flpMovimientosRecientes.Controls.RemoveAt(0);
                    control.Dispose();
                }

                if (actividad.MovimientosRecientes.Count == 0)
                {
                    var mensajeVacio = new Label
                    {
                        Text = "No hay movimientos registrados hoy.",
                        AutoSize = false,
                        Height = 38,
                        Width = ObtenerAnchoFilaActividad(),
                        Font = new Font(
                            "Century Gothic",
                            8F,
                            FontStyle.Regular),
                        ForeColor = Color.FromArgb(138, 154, 165),
                        TextAlign = ContentAlignment.MiddleLeft,
                        Margin = new Padding(2)
                    };

                    flpMovimientosRecientes.Controls.Add(mensajeVacio);
                }
                else
                {
                    foreach (
                        MovimientoInventarioResumenDto movimiento
                        in actividad.MovimientosRecientes)
                    {
                        flpMovimientosRecientes.Controls.Add(
                            CrearFilaMovimientoInventario(movimiento));
                    }
                }
            }
            finally
            {
                flpMovimientosRecientes.ResumeLayout(true);
            }

            AjustarAnchoFilasActividad();
        }

        /// <summary>
        /// Construye una fila visual para un movimiento reciente.
        /// No utiliza un DataGridView.
        /// </summary>
        private Control CrearFilaMovimientoInventario(
            MovimientoInventarioResumenDto movimiento)
        {
            var (textoTipo, colorTipo) =
                ObtenerPresentacionTipoMovimiento(
                    movimiento.TipoMovimiento);

            string nombreProducto =
                CatalogoTraducciones.TraducirIngrediente(
                    movimiento.CodigoProducto,
                    movimiento.Producto);

            string unidad =
                CatalogoTraducciones.TraducirUnidad(
                    null,
                    movimiento.Unidad);

            var fila = new TableLayoutPanel
            {
                AutoSize = false,
                Height = 34,
                Width = ObtenerAnchoFilaActividad(),
                ColumnCount = 3,
                RowCount = 1,
                Margin = new Padding(1, 1, 1, 3),
                Padding = new Padding(4, 1, 4, 1),
                BackColor = Color.FromArgb(248, 250, 252)
            };

            fila.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 70F));

            fila.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            fila.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 46F));

            fila.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            var lblTipo = new Label
            {
                Text = textoTipo,
                Dock = DockStyle.Fill,
                AutoSize = false,
                Font = new Font(
                    "Century Gothic",
                    7F,
                    FontStyle.Bold),
                ForeColor = colorTipo,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true,
                Margin = Padding.Empty
            };

            string detalleProducto =
                $"{movimiento.CodigoProducto} · {nombreProducto} · " +
                $"{movimiento.Cantidad:0.####} {unidad}";

            var lblProducto = new Label
            {
                Text = detalleProducto,
                Dock = DockStyle.Fill,
                AutoSize = false,
                Font = new Font(
                    "Century Gothic",
                    7.5F,
                    FontStyle.Regular),
                ForeColor = Color.FromArgb(18, 48, 71),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true,
                Margin = Padding.Empty
            };

            var lblHora = new Label
            {
                Text = movimiento.FechaHora.ToString("HH:mm"),
                Dock = DockStyle.Fill,
                AutoSize = false,
                Font = new Font(
                    "Century Gothic",
                    7.5F,
                    FontStyle.Regular),
                ForeColor = Color.FromArgb(107, 124, 135),
                TextAlign = ContentAlignment.MiddleRight,
                Margin = Padding.Empty
            };

            // Mostrar las observaciones completas al pasar el cursor.
            var toolTip = new ToolTip();

            string detalleCompleto = string.IsNullOrWhiteSpace(
                movimiento.Observaciones)
                ? detalleProducto
                : $"{detalleProducto}\nObservaciones: " +
                  movimiento.Observaciones;

            toolTip.SetToolTip(lblProducto, detalleCompleto);

            fila.Disposed += (_, _) => toolTip.Dispose();

            fila.Controls.Add(lblTipo, 0, 0);
            fila.Controls.Add(lblProducto, 1, 0);
            fila.Controls.Add(lblHora, 2, 0);

            return fila;
        }

        /// <summary>
        /// Devuelve el texto y el color de cada tipo de movimiento.
        /// Los valores recibidos son los códigos almacenados en la base de datos.
        /// </summary>
        private static (string Texto, Color Color)
            ObtenerPresentacionTipoMovimiento(string tipo)
        {
            return tipo switch
            {
                TiposMovimientoInventario.Entrada =>
                    ("ENTRADA", Color.FromArgb(22, 163, 74)),

                TiposMovimientoInventario.Salida =>
                    ("SALIDA", Color.FromArgb(8, 126, 164)),

                TiposMovimientoInventario.Perdida =>
                    ("PÉRDIDA", Color.FromArgb(190, 66, 66)),

                TiposMovimientoInventario.Ajuste =>
                    ("AJUSTE", Color.FromArgb(218, 154, 24)),

                TiposMovimientoInventario.Compra =>
                    ("COMPRA", Color.FromArgb(22, 163, 74)),

                TiposMovimientoInventario.Venta =>
                    ("VENTA", Color.FromArgb(59, 130, 246)),

                _ => ("MOVIMIENTO", Color.FromArgb(107, 124, 135))
            };
        }

        /// <summary>
        /// Calcula un ancho de fila que deja espacio para el scroll vertical.
        /// </summary>
        private int ObtenerAnchoFilaActividad()
        {
            return Math.Max(
                100,
                flpMovimientosRecientes.ClientSize.Width
                - SystemInformation.VerticalScrollBarWidth
                - 8);
        }

        private void AjustarAnchoFilasActividad()
        {
            if (flpMovimientosRecientes is null ||
                flpMovimientosRecientes.IsDisposed)
            {
                return;
            }

            int ancho = ObtenerAnchoFilaActividad();

            foreach (Control control in
                flpMovimientosRecientes.Controls)
            {
                if (control.Width != ancho)
                {
                    control.Width = ancho;
                }
            }
        }

        private void FlpMovimientosRecientes_SizeChanged(
            object? sender,
            EventArgs e)
        {
            AjustarAnchoFilasActividad();
        }


        /// <summary>
        /// Carga los datos reales de evolución de ventas en el gráfico.
        /// </summary>
        public void MostrarEvolucionVentas(
            List<EvolucionVentaReporte> datos)
        {
            Series? serie = chartVentas.Series.FindByName("Ventas");

            if (serie == null)
                return;

            serie.Points.Clear();

            foreach (EvolucionVentaReporte dato in datos)
            {
                serie.Points.AddXY(
                    dato.Fecha.ToString("dd/MM"),
                    Convert.ToDouble(dato.Total));

                serie.Points[serie.Points.Count - 1].ToolTip =
                    $"{dato.Fecha:dd/MM/yyyy}: C$ {dato.Total:N2}";
            }

            int dias = (FechaHasta.Date - FechaDesde.Date).Days + 1;

            if (dias > 0 && dias <= 366)
            {
                var totalesPorFecha = datos
                    .GroupBy(x => x.Fecha.Date)
                    .ToDictionary(
                        grupo => grupo.Key,
                        grupo => grupo.Sum(x => x.Total));

                for (
                    DateTime fecha = FechaDesde.Date;
                    fecha <= FechaHasta.Date;
                    fecha = fecha.AddDays(1))
                {
                    decimal total = totalesPorFecha.TryGetValue(
                        fecha,
                        out decimal importe)
                            ? importe
                            : 0m;

                    serie.Points.AddXY(
                        fecha.ToString("dd/MM"),
                        Convert.ToDouble(total));

                    serie.Points[serie.Points.Count - 1].ToolTip =
                        $"{fecha:dd/MM/yyyy}: C$ {total:N2}";
                }
            }
            else
            {
                foreach (EvolucionVentaReporte dato in datos)
                {
                    serie.Points.AddXY(
                        dato.Fecha.ToString("dd/MM"),
                        Convert.ToDouble(dato.Total));

                    serie.Points[serie.Points.Count - 1].ToolTip =
                        $"{dato.Fecha:dd/MM/yyyy}: C$ {dato.Total:N2}";
                }
            }

            ChartArea area = chartVentas.ChartAreas["Ventas"];

            area.AxisX.Interval = datos.Count > 18
                ? Math.Ceiling(datos.Count / 12d)
                : 1;

            area.AxisX.LabelStyle.Angle =
                datos.Count > 12 ? -35 : 0;

            AjustarEscalaGraficoVentas(datos);
        }

        /// <summary>
        /// Carga los cinco productos con mayor cantidad vendida.
        /// </summary>

        public void MostrarProductosMasVendidos(
            List<ProductoVendidoReporte> datos)
        {
            Series? serie =
                chartProductos.Series.FindByName("Productos");

            if (serie == null)
                return;

            serie.Points.Clear();

            // Mostrar la cantidad sobre cada barra.
            serie.IsValueShownAsLabel = true;
            serie.LabelFormat = "#,##0.##";
            serie.Font = new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold);

            foreach (ProductoVendidoReporte dato in datos)
            {
                serie.Points.AddXY(
                    dato.Producto,
                    Convert.ToDouble(dato.Cantidad));

                serie.Points[serie.Points.Count - 1].ToolTip =
                    $"{dato.Producto}: {dato.Cantidad:0.####}";
            }

            AjustarEscalaGraficoProductos(datos);
        }

        /// <summary>
        /// Muestra un mensaje mediante el componente reutilizable del sistema.
        /// </summary>
        public void MostrarMensaje(string mensaje, string titulo = "Reportes", bool esError = false)
        {
            MessageType tipo = esError ? MessageType.Error : MessageType.Information;
            FrmMessageBox.Show(mensaje, titulo, tipo);
        }
        #endregion

        #region Eventos del Formulario
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ComboBoxPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeriodoChanged?.Invoke(this, EventArgs.Empty);
        }

        private void FrmReportes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _presenter?.Dispose();
            _presenter = null;
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            // El Presenter realiza la carga inicial en el constructor.
        }
        #endregion

        #region Configuración de Gráficos
        /// <summary>
        /// Configura los gráficos de ventas y productos con estilos y formatos predeterminados.
        /// </summary>
        private void ConfigurarGraficos()
        {
            ConfigurarGraficoVentas();
            ConfigurarGraficoProductos();
        }

        /// <summary>
        /// Configura el gráfico de evolución de ventas con estilos y formatos predeterminados.
        /// </summary>
        private void ConfigurarGraficoVentas()
        {
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            chartVentas.Legends.Clear();

            ChartArea area = new ChartArea("Ventas")
            {
                BackColor = Color.White
            };

            chartVentas.ChartAreas.Add(area);

            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.FromArgb(215, 225, 230);
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(90, 105, 115);

            area.AxisY.Minimum = 0;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 235, 238);
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.LineColor = Color.FromArgb(215, 225, 230);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(100, 115, 125);
            area.AxisY.LabelStyle.Format = "C$ #,##0";

            area.Position.Auto = false;
            area.Position.X = 3;
            area.Position.Y = 3;
            area.Position.Width = 94;
            area.Position.Height = 88;

            Series ventas = new Series("Ventas")
            {
                ChartType = SeriesChartType.Line,
                IsXValueIndexed = true,
                Color = Color.FromArgb(8, 126, 164),
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                MarkerColor = Color.FromArgb(8, 126, 164),
                IsValueShownAsLabel = false
            };

            chartVentas.Series.Add(ventas);
            chartVentas.BackColor = Color.White;
            chartVentas.BorderlineWidth = 0;
        }

        /// <summary>
        /// Configura el gráfico de productos más vendidos con estilos y formatos predeterminados.
        /// </summary>
        private void ConfigurarGraficoProductos()
        {
            chartProductos.Series.Clear();
            chartProductos.ChartAreas.Clear();
            chartProductos.Legends.Clear();

            ChartArea area = new ChartArea("Productos")
            {
                BackColor = Color.White
            };

            chartProductos.ChartAreas.Add(area);

            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.FromArgb(215, 225, 230);
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(90, 105, 115);
            area.AxisX.LabelStyle.Angle = -35;

            area.AxisY.Minimum = 0;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 235, 238);
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            area.AxisY.LineColor = Color.FromArgb(215, 225, 230);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(100, 115, 125);

            area.Position.Auto = false;
            area.Position.X = 3;
            area.Position.Y = 3;
            area.Position.Width = 94;
            area.Position.Height = 88;

            Series productos = new Series("Productos")
            {
                ChartType = SeriesChartType.Column,
                IsXValueIndexed = true,
                Color = Color.FromArgb(27, 167, 209),
                BorderWidth = 0,
                IsValueShownAsLabel = false
            };

            productos["PointWidth"] = "0.65";

            chartProductos.Series.Add(productos);
            chartProductos.BackColor = Color.White;
            chartProductos.BorderlineWidth = 0;
        }



        #endregion

        #region Ajuste de Escalas de Gráficos
        /// <summary>
        /// Ajusta dinámicamente la escala vertical del gráfico de ventas.
        /// </summary>
        private void AjustarEscalaGraficoVentas(List<EvolucionVentaReporte> datos)
        {
            ChartArea area = chartVentas.ChartAreas["Ventas"];

            if (datos.Count == 0)
            {
                area.AxisY.Maximum = 1000;
                area.AxisY.Interval = 200;
                return;
            }

            double maximo = Convert.ToDouble(datos.Max(x => x.Total));
            double intervalo = CalcularIntervalo(maximo, 5);

            area.AxisY.Interval = intervalo;
            area.AxisY.Maximum = intervalo * 5;
        }

        /// <summary>
        /// Ajusta dinámicamente la escala vertical del gráfico de productos.
        /// </summary>
        private void AjustarEscalaGraficoProductos(List<ProductoVendidoReporte> datos)
        {
            ChartArea area = chartProductos.ChartAreas["Productos"];

            if (datos.Count == 0)
            {
                area.AxisY.Maximum = 10;
                area.AxisY.Interval = 2;
                return;
            }

            double maximo = Convert.ToDouble(datos.Max(x => x.Cantidad));
            double intervalo = CalcularIntervalo(maximo, 5);

            area.AxisY.Interval = intervalo;
            area.AxisY.Maximum = intervalo * 5;
        }

        /// <summary>
        /// Calcula un intervalo sencillo para mantener una escala legible.
        /// </summary>
        private static double CalcularIntervalo(double maximo, int divisiones)
        {
            if (maximo <= 0)
                return 1;

            double valor = Math.Ceiling(maximo / divisiones);

            if (valor <= 1)
                return 1;

            if (valor <= 5)
                return 5;

            if (valor <= 10)
                return 10;

            if (valor <= 25)
                return 25;

            if (valor <= 50)
                return 50;

            if (valor <= 100)
                return 100;

            return Math.Ceiling(valor / 100) * 100;
        }
        #endregion


        private void lblDetalleSalidasHoy_Click(object sender, EventArgs e)
        {

        }
    }
}
