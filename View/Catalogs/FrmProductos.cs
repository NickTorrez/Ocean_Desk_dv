using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.View.Catalogs
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
            Color grisTexto = ColorTranslator.FromHtml("#6F7780");
            foreach (Label lbl in new[] { lblCodigo, lblNombre, lblCategoria,
                              lblDescripcion, lblPrecio, lblUnidad, lblStockMinimo })
            {
                lbl.ForeColor = grisTexto;
            }
            AplicarEstiloGrid(dgvProductos);
            // AplicarEstiloGrid(dgvReceta);

        }


        private void AplicarEstiloGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(230, 234, 238);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(8, 31, 63);
            dgv.DefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(8, 31, 63);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Regular);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(8, 31, 63);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
        }
        private void tlpBarraSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || !(e.Value is bool)) return;
            bool valor = (bool)e.Value;
            string col = dgvProductos.Columns[e.ColumnIndex].Name;

            if (col == "colDisponible")
            {
                e.Value = valor ? "Sí" : "No";
                e.FormattingApplied = true;
            }
            else if (col == "colActivo")
            {
                e.Value = valor ? "Activo" : "Inactivo";
                e.CellStyle.ForeColor = valor
                    ? Color.FromArgb(42, 122, 82)
                    : Color.FromArgb(163, 61, 61);
                e.FormattingApplied = true;
            }
        }
    }
    }

