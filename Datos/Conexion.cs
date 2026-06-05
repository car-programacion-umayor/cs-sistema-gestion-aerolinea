using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaGestionAerolinea.Datos
{
    /// <summary>
    /// Gestionar la conectividad centralizada con el motor de base de datos MySQL.
    /// </summary>
    public class Conexion
    {
        // Parámetros de configuración para la cadena de conexión del servidor local
        private static string cadena = "Server=localhost; Database=domestikaerolineadb; Uid=root; Pwd=;";

        /// <summary>
        /// Establecer y abrir una conexión activa con el servidor de base de datos.
        /// </summary>
        /// <returns>Instancia de MySqlConnection abierta o null si ocurre una excepción de infraestructura.</returns>
        public static MySqlConnection AbrirConexion()
        {
            MySqlConnection conectar = new MySqlConnection(cadena);
            try
            {
                // Verificar el estado actual de la conexión antes de invocar la apertura
                if (conectar.State != ConnectionState.Open)
                {
                    conectar.Open();
                }
                return conectar;
            }
            catch (MySqlException ex)
            {
                // Controlar errores específicos de conectividad mediante códigos nativos del motor MySQL
                string mensajeError = "Error de conectividad: ";

                switch (ex.Number)
                {
                    case 0:
                        mensajeError += "No es posible establecer comunicación con el servidor. Verificar servicios de red.";
                        break;
                    case 1045:
                        mensajeError += "Credenciales de acceso a la base de datos no válidas.";
                        break;
                    default:
                        mensajeError += ex.Message;
                        break;
                }

                MessageBox.Show(mensajeError, "Fallo de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el acceso a la infraestructura de datos: " + ex.Message, "Error del Sistema");
                return null;
            }
        }
    }
}