using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaGestionAerolinea.Datos
{
    /// <summary>
    /// Gestionar las operaciones de persistencia y consultas relacionales de la tabla de pasajeros.
    /// </summary>
    public class PasajeroDatos
    {
        /// <summary>
        /// Recuperar el catálogo maestro completo de pasajeros ordenados por apellido.
        /// </summary>
        /// <returns>DataTable con los registros de los pasajeros consolidados.</returns>
        public static DataTable ObtenerPasajeros()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT rut, CONCAT(apellido, ', ', nombre) AS nombre_completo FROM pasajero ORDER BY apellido ASC";

            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return dt;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Verificar la existencia de un pasajero específico en la base de datos mediante su RUT.
        /// </summary>
        /// <param name="rut">Identificador único del pasajero.</param>
        /// <returns>Valor booleano que indica si el registro existe.</returns>
        public static bool ExistePasajero(string rut)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return false;
                string sql = "SELECT COUNT(*) FROM pasajero WHERE rut = @rut";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Insertar un nuevo registro de pasajero en el sistema central.
        /// </summary>
        /// <param name="rut">RUT del pasajero.</param>
        /// <param name="nombre">Nombre del pasajero.</param>
        /// <param name="apellido">Apellido del pasajero.</param>
        /// <param name="idTipoPasajero">Llave foránea del tipo de pasajero asociado.</param>
        /// <param name="puntaje">Puntaje acumulado por el pasajero.</param>
        public static void InsertarPasajero(string rut, string nombre, string apellido, int idTipoPasajero, int puntaje)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return;
                string sql = "INSERT INTO pasajero (rut, nombre, apellido, id_tipo_pasajero, puntaje) VALUES (@rut, @nom, @ape, @tipo, @pts)";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@ape", apellido);
                    cmd.Parameters.AddWithValue("@tipo", idTipoPasajero);
                    cmd.Parameters.AddWithValue("@pts", puntaje);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualizar los atributos de un pasajero existente filtrado por su RUT.
        /// </summary>
        /// <param name="rut">RUT del pasajero a modificar.</param>
        /// <param name="nombre">Nuevo nombre.</param>
        /// <param name="apellido">Nuevo apellido.</param>
        /// <param name="idTipoPasajero">Nueva llave foránea del tipo de pasajero.</param>
        /// <param name="puntaje">Nuevo puntaje asignado.</param>
        public static void ActualizarPasajero(string rut, string nombre, string apellido, int idTipoPasajero, int puntaje)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return;
                string sql = "UPDATE pasajero SET nombre=@nom, apellido=@ape, id_tipo_pasajero=@tipo, puntaje=@pts WHERE rut=@rut";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@ape", apellido);
                    cmd.Parameters.AddWithValue("@tipo", idTipoPasajero);
                    cmd.Parameters.AddWithValue("@pts", puntaje);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Buscar y extraer la fila de datos de un pasajero mediante un cruce relacional con su categoría.
        /// </summary>
        /// <param name="rut">RUT del pasajero a consultar.</param>
        /// <returns>DataRow con las columnas recuperadas o null si no se encuentra coincidencia.</returns>
        public static DataRow BuscarPasajeroPorRut(string rut)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return null;
                string sql = "SELECT p.rut, p.nombre, p.apellido, p.puntaje, t.id_tipo FROM pasajero p " +
                             "INNER JOIN tipo_pasajero t ON p.id_tipo_pasajero = t.id_tipo WHERE p.rut = @rut";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0) return dt.Rows[0];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Evaluar si un pasajero posee registros vinculados en la tabla de reservas operativas.
        /// </summary>
        /// <param name="rut">RUT del pasajero a validar.</param>
        /// <returns>Valor booleano que indica la presencia de dependencias transaccionales.</returns>
        public static bool TieneReservasActivas(string rut)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return false;
                string sql = "SELECT COUNT(*) FROM reserva WHERE rut = @rut";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        /// <summary>
        /// Eliminar físicamente el registro de un pasajero de la base de datos centralizada.
        /// </summary>
        /// <param name="rut">RUT del registro a remover.</param>
        public static void EliminarPasajero(string rut)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return;
                string sql = "DELETE FROM pasajero WHERE rut = @rut";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}