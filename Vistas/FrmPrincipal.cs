using System;
using System.Windows.Forms;

namespace SistemaGestionAerolinea.Vistas
{
    /// <summary>
    /// Formulario contenedor principal encargado de la gestión de módulos corporativos y navegación.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            // Cargar de forma predeterminada el módulo operativo de pasajeros al iniciar el sistema
            CargarModuloPasajeros();
        }

        private void itemCerrarSesion_Click(object sender, EventArgs e)
        {
            // Verificar la intención de cierre para la sesión del usuario actual
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea finalizar la sesión operativa?",
                                                       "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Form login = Application.OpenForms["FrmLogin"];

                if (login != null)
                {
                    login.Show();
                    this.Close();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Realizar la transición dinámica de controles de usuario en el panel central de operaciones.
        /// </summary>
        /// <param name="modulo">Control de usuario a instanciar de forma exclusiva en el contenedor.</param>
        private void AbrirModulo(UserControl modulo)
        {
            // Liberar de forma explícita la memoria de instancias anteriores para mitigar fugas de recursos
            // CORRECCIÓN: Se utiliza el nombre completamente calificado para evitar colisiones con el namespace Control
            foreach (System.Windows.Forms.Control control in pnlPrincipal.Controls)
            {
                control.Dispose();
            }

            pnlPrincipal.Controls.Clear();
            modulo.Dock = DockStyle.Fill;
            pnlPrincipal.Controls.Add(modulo);
        }

        private void CargarModuloPasajeros()
        {
            AbrirModulo(new UC_Pasajeros());
        }

        private void itemPasajeros_Click(object sender, EventArgs e)
        {
            CargarModuloPasajeros();
        }

        private void itemVuelos_Click(object sender, EventArgs e)
        {
            // Instanciar el módulo de administración de vuelos comerciales
            AbrirModulo(new UC_Vuelos());
        }

        private void itemGenerarReserva_Click(object sender, EventArgs e)
        {
            // Instanciar el módulo transaccional para la generación de nuevas reservas
            AbrirModulo(new UC_GenerarReserva());
        }

        private void itemVerReservas_Click(object sender, EventArgs e)
        {
            // Instanciar el control analítico del listado maestro de reservas
            AbrirModulo(new UC_ListadoGeneral());
        }

        private void itemConsultarHistorial_Click(object sender, EventArgs e)
        {
            // Instanciar el control indexado de búsquedas avanzadas segmentadas
            AbrirModulo(new UC_Consultas());
        }

        /// <summary>
        /// Gestionar la terminación absoluta de procesos del sistema al cerrar la ventana principal.
        /// </summary>
        /// <param name="e">Argumentos asociados al evento de cierre del formulario.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Form login = Application.OpenForms["FrmLogin"];
                if (login == null || !login.Visible)
                {
                    Application.Exit();
                }
            }
        }
    }
}