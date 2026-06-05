using Google.Protobuf.Collections;
using System;
using System.Windows.Forms;

namespace SistemaGestionAerolinea
{
    /// <summary>
    /// Clase de entrada que inicializa el ciclo de vida de la aplicación.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la ejecución del sistema.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Inicialización del formulario de acceso principal
                Application.Run(new Vistas.FrmLogin());
            }
            catch (Exception ex)
            {
                // Gestión de excepciones para errores en la inicialización
                MessageBox.Show("Se ha producido un error durante el inicio del sistema: " + ex.Message,
                                "Inconsistencia de Datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}