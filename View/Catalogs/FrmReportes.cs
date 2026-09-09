using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.Interfaces;
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
        /// <summary>
        /// Inicializa una nueva instancia del formulario FrmReportes.
        /// </summary>
        public FrmReportes()
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

            ConfigurarGraficos();

            _presenter = new ReportesPresenter(this);
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
        public void MostrarStockBajoNoDisponible()
        {
            lblStockBajo.Text = "N/D";
            lblDetalleStock.Text = "Inventario pendiente de implementar";
        }

        /// <summary>
        /// Carga los datos reales de evolución de ventas en el gráfico.
        /// </summary>
        public void MostrarEvolucionVentas(List<EvolucionVentaReporte> datos)
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
            }

            AjustarEscalaGraficoVentas(datos);
        }

        /// <summary>
        /// Carga los cinco productos con mayor cantidad vendida.
        /// </summary>
        public void MostrarProductosMasVendidos(List<ProductoVendidoReporte> datos)
        {
            Series? serie = chartProductos.Series.FindByName("Productos");

            if (serie == null)
                return;

            serie.Points.Clear();

            foreach (ProductoVendidoReporte dato in datos)
            {
                serie.Points.AddXY(
                    dato.Producto,
                    Convert.ToDouble(dato.Cantidad));
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
            area.Position.X = 6;
            area.Position.Y = 5;
            area.Position.Width = 90;
            area.Position.Height = 82;

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
            area.Position.X = 6;
            area.Position.Y = 5;
            area.Position.Width = 90;
            area.Position.Height = 82;

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



    }
}
