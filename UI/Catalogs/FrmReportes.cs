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
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            //CargarDatosPrueba();
            ConfigurarGraficos();
        }

        #region Contrucción de Gráficos
        private void ConfigurarGraficos()
        {
            ConfigurarGraficoVentas();
            ConfigurarGraficoProductos();
        }

        private void ConfigurarGraficoVentas()
        {
            // Limpiar cualquier configuración anterior
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            chartVentas.Legends.Clear();

            // Crear área del gráfico
            ChartArea area = new ChartArea("Ventas");

            chartVentas.ChartAreas.Add(area);

            // Fondo
            area.BackColor = Color.White;

            // -------------------------------------------------
            // EJE X - Días
            // -------------------------------------------------
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.FromArgb(215, 225, 230);

            area.AxisX.LabelStyle.Font =
                new Font("Segoe UI", 8);

            area.AxisX.LabelStyle.ForeColor =
                Color.FromArgb(90, 105, 115);

            // -------------------------------------------------
            // EJE Y - Ventas
            // -------------------------------------------------
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 10000;
            area.AxisY.Interval = 2000;

            area.AxisY.MajorGrid.Enabled = true;

            area.AxisY.MajorGrid.LineColor =
                Color.FromArgb(230, 235, 238);

            area.AxisY.MajorGrid.LineDashStyle =
                ChartDashStyle.Dot;

            area.AxisY.LineColor =
                Color.FromArgb(215, 225, 230);

            area.AxisY.LabelStyle.Font =
                new Font("Segoe UI", 8);

            area.AxisY.LabelStyle.ForeColor =
                Color.FromArgb(100, 115, 125);

            // Formato monetario
            area.AxisY.LabelStyle.Format = "$#,##0";

            // -------------------------------------------------
            // ÁREA ÚTIL DEL GRÁFICO
            // -------------------------------------------------
            area.Position.Auto = false;
            area.Position.X = 6;
            area.Position.Y = 5;
            area.Position.Width = 90;
            area.Position.Height = 82;

            // -------------------------------------------------
            // CREAR SERIE
            // -------------------------------------------------
            Series ventas = new Series("Ventas");

            ventas.ChartType = SeriesChartType.Line;

            // Cada día representa una categoría independiente
            ventas.IsXValueIndexed = true;

            // Estilo de línea Ocean Desk
            ventas.Color =
                Color.FromArgb(8, 126, 164);

            ventas.BorderWidth = 3;

            // Puntos
            ventas.MarkerStyle = MarkerStyle.Circle;
            ventas.MarkerSize = 6;

            ventas.MarkerColor =
                Color.FromArgb(8, 126, 164);

            // No mostrar valores sobre los puntos
            ventas.IsValueShownAsLabel = false;

            // -------------------------------------------------
            // DATOS DE PRUEBA
            // -------------------------------------------------
            ventas.Points.AddXY("Lun", 4200);
            ventas.Points.AddXY("Mar", 5100);
            ventas.Points.AddXY("Mié", 4800);
            ventas.Points.AddXY("Jue", 6200);
            ventas.Points.AddXY("Vie", 7100);
            ventas.Points.AddXY("Sáb", 8900);
            ventas.Points.AddXY("Dom", 7600);

            // Agregar serie al gráfico
            chartVentas.Series.Add(ventas);

            // Apariencia general
            chartVentas.BackColor = Color.White;
            chartVentas.BorderlineWidth = 0;
        }

        private void ConfigurarGraficoProductos()
        {
            // Limpiar cualquier configuración previa
            chartProductos.Series.Clear();
            chartProductos.ChartAreas.Clear();
            chartProductos.Legends.Clear();

            // Crear área del gráfico
            ChartArea area = new ChartArea("Productos");

            chartProductos.ChartAreas.Add(area);

            // Fondo
            area.BackColor = Color.White;

            // -------------------------------------------------
            // EJE X - Nombres de los productos
            // -------------------------------------------------
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.LineColor = Color.FromArgb(215, 225, 230);

            area.AxisX.LabelStyle.Font =
                new Font("Segoe UI", 8);

            area.AxisX.LabelStyle.ForeColor =
                Color.FromArgb(90, 105, 115);

            // Rotar ligeramente las etiquetas
            area.AxisX.LabelStyle.Angle = -35;

            // -------------------------------------------------
            // EJE Y - Cantidad vendida
            // -------------------------------------------------
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 50;
            area.AxisY.Interval = 10;

            area.AxisY.MajorGrid.Enabled = true;

            area.AxisY.MajorGrid.LineColor =
                Color.FromArgb(230, 235, 238);

            area.AxisY.MajorGrid.LineDashStyle =
                ChartDashStyle.Dot;

            area.AxisY.LineColor =
                Color.FromArgb(215, 225, 230);

            area.AxisY.LabelStyle.Font =
                new Font("Segoe UI", 8);

            area.AxisY.LabelStyle.ForeColor =
                Color.FromArgb(100, 115, 125);

            // -------------------------------------------------
            // Área útil del gráfico
            // -------------------------------------------------
            area.Position.Auto = false;
            area.Position.X = 6;
            area.Position.Y = 5;
            area.Position.Width = 90;
            area.Position.Height = 82;

            // -------------------------------------------------
            // Crear serie
            // -------------------------------------------------
            Series productos = new Series("Productos");

            productos.ChartType = SeriesChartType.Column;

            // Cada producto será una categoría independiente
            productos.IsXValueIndexed = true;

            // Color Ocean Desk
            productos.Color =
                Color.FromArgb(27, 167, 209);

            productos.BorderWidth = 0;

            // No mostrar valores dentro de las barras
            productos.IsValueShownAsLabel = false;

            // Separación entre columnas
            productos["PointWidth"] = "0.65";

            // -------------------------------------------------
            // DATOS DE PRUEBA
            // -------------------------------------------------
            productos.Points.AddXY("Mixto", 48);
            productos.Points.AddXY("Camarón", 39);
            productos.Points.AddXY("Pescado", 32);
            productos.Points.AddXY("Ajillo", 27);
            productos.Points.AddXY("Pescado Ceviche", 21);

            chartProductos.Series.Add(productos);

            // Apariencia general
            chartProductos.BackColor = Color.White;
            chartProductos.BorderlineWidth = 0;
        }
        #endregion

        #region Datos de Simulación Charts
       
        /*private void CargarDatosPrueba()
        {
            // =========================
            // GRÁFICO DE VENTAS
            // =========================

            chartVentas.Series.Clear();

            Series serieVentas = new Series("Ventas");
            serieVentas.ChartType = SeriesChartType.Line;
            serieVentas.BorderWidth = 3;
            serieVentas.MarkerStyle = MarkerStyle.Circle;
            serieVentas.MarkerSize = 7;

            serieVentas.Points.AddXY("Lun", 4200);
            serieVentas.Points.AddXY("Mar", 5100);
            serieVentas.Points.AddXY("Mié", 4800);
            serieVentas.Points.AddXY("Jue", 6200);
            serieVentas.Points.AddXY("Vie", 7100);
            serieVentas.Points.AddXY("Sáb", 8900);
            serieVentas.Points.AddXY("Dom", 7600);

            chartVentas.Series.Add(serieVentas);


            // =========================
            // GRÁFICO DE PRODUCTOS
            // =========================

            chartProductos.Series.Clear();

            Series serieProductos = new Series("Productos");
            serieProductos.ChartType = SeriesChartType.Bar;
            serieProductos.IsValueShownAsLabel = true;

            serieProductos.Points.AddXY("Ceviche Mixto", 48);
            serieProductos.Points.AddXY("Ceviche de Camarón", 39);
            serieProductos.Points.AddXY("Pescado Frito", 32);
            serieProductos.Points.AddXY("Camarones al Ajillo", 27);
            serieProductos.Points.AddXY("Ceviche de Pescado", 21);

            chartProductos.Series.Add(serieProductos);
        }*/
        #endregion
     
        
    }
}
