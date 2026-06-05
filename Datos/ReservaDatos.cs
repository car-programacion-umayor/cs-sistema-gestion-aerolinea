using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaGestionAerolinea.Datos
{
    /// <summary>
    /// Gestionar la persistencia transaccional, cálculos de tarifas y balanceo analítico de puntajes en el módulo de reservas.
    /// </summary>
    public class ReservaDatos
    {
        /// <summary>
        /// Recuperar los parámetros numéricos de tarificación y asignación de puntaje desde el catálogo de tipos de reserva.
        /// </summary>
        /// <param name="idTipo">Identificador del tipo de cabina o reserva.</param>
        /// <param name="vBase">Parámetro de salida para el valor base de la tarifa.</param>
        /// <param name="embarque">Parámetro de salida para las tasas de embarque aplicadas.</param>
        /// <param name="recargo">Parámetro de salida para el porcentaje de recargo comercial.</param>
        /// <param name="puntaje">Parámetro de salida para la base de puntos asignados.</param>
        /// <returns>Valor booleano que confirma la existencia de las reglas indexadas.</returns>
        public static bool ObtenerReglasTipo(int idTipo, out double vBase, out double embarque, out double recargo, out int puntaje)
        {
            vBase = 0; embarque = 0; recargo = 0; puntaje = 0;
            bool encontrado = false;

            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return false;
                string sql = "SELECT valor_base, gasto_embarque, recargo_porcentaje, puntaje FROM tipo_reserva WHERE id_tipo = @id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", idTipo);

                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        vBase = Convert.ToDouble(rd["valor_base"]);
                        embarque = Convert.ToDouble(rd["gasto_embarque"]);
                        recargo = Convert.ToDouble(rd["recargo_porcentaje"]);
                        puntaje = Convert.ToInt32(rd["puntaje"]);
                        encontrado = true;
                    }
                }
            }
            return encontrado;
        }

        /// <summary>
        /// Insertar un registro de reserva e incrementar de forma correlativa el puntaje acumulado del pasajero titular.
        /// </summary>
        /// <param name="codigo">Código único de la reserva.</param>
        /// <param name="rut">RUT del pasajero asociado.</param>
        /// <param name="numvlo">Número de vuelo seleccionado.</param>
        /// <param name="idTipo">Identificador del tipo de reserva.</param>
        /// <param name="valorTotal">Monto total de la transacción comercial.</param>
        /// <param name="puntos">Cantidad de puntos a abonar al cliente.</param>
        public static void InsertarReserva(string codigo, string rut, string numvlo, int idTipo, double valorTotal, int puntos)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return;

                string sqlIns = "INSERT INTO reserva (codigo, rut, numvlo, id_tipo_reserva, valor) VALUES (@cod, @rut, @num, @tipo, @val)";
                MySqlCommand cmdIns = new MySqlCommand(sqlIns, con);
                cmdIns.Parameters.AddWithValue("@cod", codigo);
                cmdIns.Parameters.AddWithValue("@rut", rut);
                cmdIns.Parameters.AddWithValue("@num", numvlo);
                cmdIns.Parameters.AddWithValue("@tipo", idTipo);
                cmdIns.Parameters.AddWithValue("@val", valorTotal);
                cmdIns.ExecuteNonQuery();

                string sqlUpd = "UPDATE pasajero SET puntaje = puntaje + @pts WHERE rut = @rut";
                MySqlCommand cmdUpd = new MySqlCommand(sqlUpd, con);
                cmdUpd.Parameters.AddWithValue("@pts", puntos);
                cmdUpd.Parameters.AddWithValue("@rut", rut);
                cmdUpd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Modificar los atributos de una reserva existente y ejecutar el recalculo o traspaso transaccional neta de puntos.
        /// </summary>
        /// <param name="codigo">Código de la reserva a modificar.</param>
        /// <param name="rutNuevo">RUT del nuevo pasajero asignado.</param>
        /// <param name="numvlo">Número del nuevo vuelo.</param>
        /// <param name="idTipoNuevo">Identificador del nuevo tipo de cabina.</param>
        /// <param name="valorTotal">Nuevo monto comercial calculado.</param>
        /// <param name="puntosNuevos">Nuevo puntaje correspondiente.</param>
        public static void ActualizarReserva(string codigo, string rutNuevo, string numvlo, int idTipoNuevo, double valorTotal, int puntosNuevos)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return;

                string rutOriginal = "";
                int puntosAntiguos = 0;

                // Extraer los datos iniciales de asignación y puntajes previos
                string sqlAntiguo = "SELECT r.rut, tr.puntaje FROM reserva r JOIN tipo_reserva tr ON r.id_tipo_reserva = tr.id_tipo WHERE r.codigo = @cod";
                MySqlCommand cmdAntiguo = new MySqlCommand(sqlAntiguo, con);
                cmdAntiguo.Parameters.AddWithValue("@cod", codigo);

                using (MySqlDataReader rd = cmdAntiguo.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        rutOriginal = rd["rut"].ToString();
                        puntosAntiguos = Convert.ToInt32(rd["puntaje"]);
                    }
                }

                // Actualizar los valores en la tabla principal de reservas
                string sqlUpdRes = "UPDATE reserva SET rut = @rut, numvlo = @num, id_tipo_reserva = @tipo, valor = @val WHERE codigo = @cod";
                MySqlCommand cmdUpdRes = new MySqlCommand(sqlUpdRes, con);
                cmdUpdRes.Parameters.AddWithValue("@cod", codigo);
                cmdUpdRes.Parameters.AddWithValue("@rut", rutNuevo);
                cmdUpdRes.Parameters.AddWithValue("@num", numvlo);
                cmdUpdRes.Parameters.AddWithValue("@tipo", idTipoNuevo);
                cmdUpdRes.Parameters.AddWithValue("@val", valorTotal);
                cmdUpdRes.ExecuteNonQuery();

                // Procesar el ajuste aritmético neto según la variación del titular de la reserva
                if (rutOriginal == rutNuevo)
                {
                    int diferencia = puntosNuevos - puntosAntiguos;
                    string sqlAjuste = "UPDATE pasajero SET puntaje = puntaje + @dif WHERE rut = @rut";
                    MySqlCommand cmdAjuste = new MySqlCommand(sqlAjuste, con);
                    cmdAjuste.Parameters.AddWithValue("@dif", diferencia);
                    cmdAjuste.Parameters.AddWithValue("@rut", rutNuevo);
                    cmdAjuste.ExecuteNonQuery();
                }
                else
                {
                    // Descontar la asignación anterior al pasajero original
                    string sqlRestar = "UPDATE pasajero SET puntaje = puntaje - @pts WHERE rut = @rut";
                    MySqlCommand cmdRestar = new MySqlCommand(sqlRestar, con);
                    cmdRestar.Parameters.AddWithValue("@pts", puntosAntiguos);
                    cmdRestar.Parameters.AddWithValue("@rut", rutOriginal);
                    cmdRestar.ExecuteNonQuery();

                    // Abonar el nuevo puntaje correspondiente al nuevo titular asignado
                    string sqlSumar = "UPDATE pasajero SET puntaje = puntaje + @pts WHERE rut = @rut";
                    MySqlCommand cmdSumar = new MySqlCommand(sqlSumar, con);
                    cmdSumar.Parameters.AddWithValue("@pts", puntosNuevos);
                    cmdSumar.Parameters.AddWithValue("@rut", rutNuevo);
                    cmdSumar.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Buscar y extraer un registro específico de reserva mediante su identificador alfanumérico.
        /// </summary>
        /// <param name="codigo">Código de barras o clave primaria de la reserva.</param>
        /// <returns>DataRow con las columnas mapeadas en la base de datos o null si es inexistente.</returns>
        public static DataRow BuscarReservaPorCodigo(string codigo)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return null;
                string sql = "SELECT codigo, rut, numvlo, id_tipo_reserva FROM reserva WHERE codigo = @cod";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@cod", codigo);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0) return dt.Rows[0];
            }
            return null;
        }

        /// <summary>
        /// Eliminar físicamente una reserva del sistema centralizado y deducir de forma estricta los puntos asociados al pasajero.
        /// </summary>
        /// <param name="codigo">Código de la reserva a remover del sistema.</param>
        public static void EliminarReserva(string codigo)
        {
            using (MySqlConnection con = Conexion.AbrirConexion())
            {
                if (con == null) return;

                string rutPasajero = "";
                int puntos = 0;

                // Recuperar la información del titular de la reserva y su impacto en puntajes para auditar el rebalanceo
                string sqlInfo = "SELECT r.rut, tr.puntaje FROM reserva r JOIN tipo_reserva tr ON r.id_tipo_reserva = tr.id_tipo WHERE r.codigo = @cod";
                MySqlCommand cmdInfo = new MySqlCommand(sqlInfo, con);
                cmdInfo.Parameters.AddWithValue("@cod", codigo);

                using (MySqlDataReader rd = cmdInfo.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        rutPasajero = rd["rut"].ToString();
                        puntos = Convert.ToInt32(rd["puntaje"]);
                    }
                }

                // Ejecutar la remoción física de la entidad reserva
                string sqlDel = "DELETE FROM reserva WHERE codigo = @cod";
                MySqlCommand cmdDel = new MySqlCommand(sqlDel, con);
                cmdDel.Parameters.AddWithValue("@cod", codigo);
                cmdDel.ExecuteNonQuery();

                // Revertir el abono de puntos al cliente afectado por la eliminación
                string sqlUpd = "UPDATE pasajero SET puntaje = puntaje - @pts WHERE rut = @rut";
                MySqlCommand cmdUpd = new MySqlCommand(sqlUpd, con);
                cmdUpd.Parameters.AddWithValue("@pts", puntos);
                cmdUpd.Parameters.AddWithValue("@rut", rutPasajero);
                cmdUpd.ExecuteNonQuery();
            }
        }
    }
}