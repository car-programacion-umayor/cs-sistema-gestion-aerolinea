using SistemaGestionAerolinea.Control;
using SistemaGestionAerolinea.Datos;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SistemaGestionAerolinea.Vistas
{
    /// <summary>
    /// Formulario de autenticación encargado de validar las credenciales de acceso de los usuarios del sistema.
    /// </summary>
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtClave.UseSystemPasswordChar = true;

            // Establecer el botón de entrada por defecto al presionar la tecla Enter
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Remover los espacios en blanco en los extremos de la entrada de usuario
            string usuarioInput = txtUsuario.Text.Trim();
            string claveInput = txtClave.Text;

            if (string.IsNullOrEmpty(usuarioInput) || string.IsNullOrEmpty(claveInput))
            {
                MessageBox.Show("Por favor, ingrese sus credenciales para acceder al sistema.",
                                "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var con = Datos.Conexion.AbrirConexion())
                {
                    if (con != null)
                    {
                        // Generar el hash SHA256 de la contraseña ingresada para la comparación de seguridad
                        string claveCifrada = Control.Encrypt.GetSHA256(claveInput);

                        // Consultar la existencia del usuario con las credenciales validadas
                        string query = "SELECT id_usuario FROM usuario WHERE username = @user AND password_hash = @pass";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@user", usuarioInput);
                        cmd.Parameters.AddWithValue("@pass", claveCifrada);

                        var resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            MessageBox.Show($"Bienvenido(a) al sistema, {usuarioInput}.",
                                            "Acceso Concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FrmPrincipal principal = new FrmPrincipal();

                            // Restaurar la interfaz de login al detectar el cierre del formulario principal
                            principal.FormClosed += (s, args) => {
                                this.LimpiarCampos();
                                this.Show();
                            };

                            principal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Las credenciales ingresadas no coinciden con nuestros registros.",
                                            "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtClave.Clear();
                            txtClave.Focus();
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de comunicación con el servidor: " + ex.Message, "Error de Conectividad");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error interno del sistema: " + ex.Message, "Error de Ejecución");
            }
        }

        private void chkVerClave_CheckedChanged(object sender, EventArgs e)
        {
            // Alternar la visibilidad de los caracteres de la contraseña en la interfaz
            txtClave.UseSystemPasswordChar = !chkVerClave.Checked;
        }

        /// <summary>
        /// Restablecer los controles de entrada de texto a su estado inicial.
        /// </summary>
        public void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtClave.Clear();
            chkVerClave.Checked = false;
            txtUsuario.Focus();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Finalizar la ejecución absoluta del proceso al cerrar la ventana de autenticación
            Application.Exit();
        }
    }
}