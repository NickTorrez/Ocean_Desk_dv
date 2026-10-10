using Ocean_Desk_dv.UI.Catalogs;
using Ocean_Desk_dv.UI.Controls;
using Ocean_Desk_dv.View.Catalogs;
using System.Windows.Forms;


namespace Ocean_Desk_dv
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Application.Run(new FrmLogin());     // original, comentada
            //Application.Run(new FrmProductos());     // temporal para la prueba
            // Application.Run(new FrmLogin());   // original: no borrar
            var f = new FrmCompras();
            f.WindowState = FormWindowState.Maximized;   // solo para la prueba
            Application.Run(f);
        }
    }
    }
