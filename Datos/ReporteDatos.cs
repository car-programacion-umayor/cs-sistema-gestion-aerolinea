using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaGestionAerolinea.Datos
{
    /// <summary>
    /// Capa de infraestructura encargada de procesar el cruce relacional y los filtros del historial de reservas.
    /// </summary>
    public static class ReporteDatos
    {
        /// <summary>
        /// Recupera el historial consolidado completo de todas las reservas del sistema para el listado general.
        /// </summary>
        /// <returns>DataTable con el registro histórico de reservas unificado.</returns>
        public static DataTable ObtenerHistorialMaestro()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT 
                            r.codigo AS CodigoReserva,
                            r.rut AS PasajeroRut,
                            CONCAT(p.apellido, ', ', p.nombre) AS PasajeroNombre,
                            r.numvlo AS VueloNumero,
                            d.nombre_destino AS Destino,
                            v.fecha AS FechaSalida,
                            v.hora AS HoraSalida,
                            tr.nombre_tipo AS ClaseTipo,
                            r.valor AS ValorTotal
                           FROM reserva r
                           INNER JOIN pasajero p ON r.rut = p.rut
                           INNER JOIN vuelo v ON r.numvlo = v.numvlo
                           INNER JOIN destinos d ON v.id_destino = d.id_destino
                           INNER JOIN tipo_reserva tr ON r.id_tipo_reserva = tr.id_tipo
                           ORDER BY r.codigo ASC";

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
        /// Filtra el historial de reservas asociado de manera estricta al RUT de un pasajero.
        /// </summary>
        /// <param name="rutPasajero">RUT del pasajero para indexar la consulta.</param>
        /// <returns>DataTable con los itinerarios específicos del cliente.</returns>
        public static DataTable ObtenerReservasPorPasajero(string rutPasajero)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT 
                            r.codigo AS CodigoReserva,
                            r.numvlo AS VueloNumero,
                            d.nombre_destino AS Destino,
                            v.fecha AS FechaSalida,
                            v.hora AS HoraSalida,
                            tr.nombre_tipo AS ClaseTipo,
                            r.valor AS ValorTotal
                           FROM reserva r
                           INNER JOIN vuelo v ON r.numvlo = v.numvlo
                           INNER JOIN destinos d ON v.id_destino = d.id_destino
                           INNER JOIN tipo_reserva tr ON r.id_tipo_reserva = tr.id_tipo
                           WHERE r.rut = @rut
                           ORDER BY v.fecha DESC";

            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return dt;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rutPasajero);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Obtener el manifiesto de pasajeros asignados relacionalmente a un identificador de vuelo.
        /// </summary>
        /// <param name="numeroVuelo">Código identificador del vuelo.</param>
        /// <returns>DataTable con la lista de abordaje confirmada.</returns>
        public static DataTable ObtenerPasajerosPorVuelo(string numeroVuelo)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT 
                            r.codigo AS CodigoReserva,
                            r.rut AS PasajeroRut,
                            CONCAT(p.apellido, ', ', p.nombre) AS PasajeroNombre,
                            tr.nombre_tipo AS ClaseTipo,
                            r.valor AS ValorTotal
                           FROM reserva r
                           INNER JOIN pasajero p ON r.rut = p.rut
                           INNER JOIN tipo_reserva tr ON r.id_tipo_reserva = tr.id_tipo
                           WHERE r.numvlo = @numvlo
                           ORDER BY p.apellido ASC";

            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return dt;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@numvlo", numeroVuelo);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}