using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaGestionAerolinea.Datos
{
    /// <summary>
    /// Gestionar las operaciones de persistencia relacional para la entidad de vuelos y sus catálogos dependientes.
    /// </summary>
    public static class VueloDatos
    {
        /// <summary>
        /// Recuperar el catálogo completo de destinos ordenados alfabéticamente.
        /// </summary>
        /// <returns>DataTable con los registros de los destinos disponibles.</returns>
        public static DataTable ObtenerDestinos()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT id_destino, nombre_destino FROM destinos ORDER BY nombre_destino ASC";

            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return dt;
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexion))
                {
                    adaptador.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// Recuperar los códigos identificadores de todos los vuelos registrados.
        /// </summary>
        /// <returns>DataTable con la lista de números de vuelo.</returns>
        public static DataTable ObtenerCodigosVuelos()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT numvlo FROM vuelo ORDER BY numvlo ASC";

            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return dt;
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexion))
                {
                    adaptador.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// Insertar un destino de forma preventiva u obtener su identificador si ya existe en el sistema.
        /// </summary>
        /// <param name="nombreDestino">Nombre del destino geográfico.</param>
        /// <returns>Entero que representa la llave primaria del destino.</returns>
        public static int RegistrarDestinoPreventivo(string nombreDestino)
        {
            string sql = "INSERT IGNORE INTO destinos (nombre_destino) VALUES (@nomDes); SELECT id_destino FROM destinos WHERE nombre_destino = @nomDes;";
            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return 0;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@nomDes", nombreDestino);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Verificar la existencia de un vuelo operativo mediante su número identificador.
        /// </summary>
        /// <param name="numeroVuelo">Número correlativo del vuelo.</param>
        /// <returns>Valor booleano que indica si el vuelo se encuentra registrado.</returns>
        public static bool ExisteVuelo(string numeroVuelo)
        {
            string sql = "SELECT COUNT(*) FROM vuelo WHERE numvlo = @num";
            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return false;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@num", numeroVuelo);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Registrar una nueva entidad vuelo dentro del sistema central de la aerolínea.
        /// </summary>
        /// <param name="numeroVuelo">Número de identificación del vuelo.</param>
        /// <param name="fecha">Fecha programada para el itinerario.</param>
        /// <param name="hora">Hora establecida para la salida.</param>
        /// <param name="idDestino">Identificador del destino asociado.</param>
        /// <returns>Valor booleano que confirma el éxito de la inserción física.</returns>
        public static bool RegistrarVuelo(string numeroVuelo, string fecha, string hora, int idDestino)
        {
            string sql = "INSERT INTO vuelo (numvlo, fecha, hora, id_destino) VALUES (@numParam, @fec, @hor, @idDestino)";
            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return false;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@numParam", numeroVuelo);
                    cmd.Parameters.AddWithValue("@fec", fecha);
                    cmd.Parameters.AddWithValue("@hor", hora);
                    cmd.Parameters.AddWithValue("@idDestino", idDestino);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Actualizar los atributos cronológicos o geográficos de un vuelo específico.
        /// </summary>
        /// <param name="numeroVuelo">Número del vuelo a modificar.</param>
        /// <param name="fecha">Nueva fecha.</param>
        /// <param name="hora">Nueva hora.</param>
        /// <param name="idDestino">Nueva llave foránea del destino.</param>
        /// <returns>Valor booleano que confirma la actualización del registro.</returns>
        public static bool ActualizarVuelo(string numeroVuelo, string fecha, string hora, int idDestino)
        {
            string sql = "UPDATE vuelo SET fecha=@fec, hora=@hor, id_destino=@idDestino WHERE numvlo=@numvlo";
            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return false;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@numvlo", numeroVuelo);
                    cmd.Parameters.AddWithValue("@fec", fecha);
                    cmd.Parameters.AddWithValue("@hor", hora);
                    cmd.Parameters.AddWithValue("@idDestino", idDestino);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Evaluar si un identificador de vuelo posee dependencias activas en la tabla de reservas comerciales.
        /// </summary>
        /// <param name="numeroVuelo">Número de vuelo a evaluar.</param>
        /// <returns>Valor booleano que indica la presencia de integridad referencial.</returns>
        public static bool TieneReservasAsociadas(string numeroVuelo)
        {
            string sql = "SELECT COUNT(*) FROM reserva WHERE numvlo = @num";
            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return false;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@num", numeroVuelo);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Eliminar físicamente un registro de vuelo de la base de datos centralizada.
        /// </summary>
        /// <param name="numeroVuelo">Número del vuelo a remover.</param>
        /// <returns>Valor booleano que confirma la ejecución de la baja de datos.</returns>
        public static bool EliminarVuelo(string numeroVuelo)
        {
            string sql = "DELETE FROM vuelo WHERE numvlo = @num";
            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return false;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@num", numeroVuelo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Buscar y extraer la información completa de un vuelo mediante su clave primaria alfanumérica.
        /// </summary>
        /// <param name="numeroVuelo">Número de vuelo a consultar.</param>
        /// <returns>DataRow con el registro recuperado o null si no se encuentran coincidencias.</returns>
        public static DataRow BuscarVueloPorCodigo(string numeroVuelo)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM vuelo WHERE numvlo = @num";
            using (MySqlConnection conexion = Conexion.AbrirConexion())
            {
                if (conexion == null) return null;
                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@num", numeroVuelo);
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                    {
                        adaptador.Fill(dt);
                    }
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}