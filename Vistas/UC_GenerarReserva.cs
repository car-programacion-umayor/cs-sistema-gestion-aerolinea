using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaGestionAerolinea.Datos;

namespace SistemaGestionAerolinea.Vistas
{
    /// <summary>
    /// Control de usuario encargado del procesamiento transaccional, cálculo de tarifas y modificaciones del módulo de reservas.
    /// </summary>
    public partial class UC_GenerarReserva : UserControl
    {
        private bool modoEdicion = false;

        public UC_GenerarReserva()
        {
            InitializeComponent();
            CargarCatalogos();
            CargarComboBusqueda();
            LimpiarCampos();
        }

        /// <summary>
        /// Cargar los catálogos maestros de pasajeros, vuelos y tarifas desde la base de datos central.
        /// </summary>
        private void CargarCatalogos()
        {
            try
            {
                this.cmbTipoReserva.SelectedIndexChanged -= new System.EventHandler(this.cmbTipoReserva_SelectedIndexChanged);

                using (MySqlConnection con = Datos.Conexion.AbrirConexion())
                {
                    string sqlPas = "SELECT rut, CONCAT(apellido, ', ', nombre) as nombre_completo FROM pasajero";
                    MySqlDataAdapter daPas = new MySqlDataAdapter(sqlPas, con);
                    DataTable dtPas = new DataTable(); daPas.Fill(dtPas);
                    cmbPasajeros.DataSource = dtPas; cmbPasajeros.ValueMember = "rut"; cmbPasajeros.DisplayMember = "nombre_completo";
                    cmbPasajeros.SelectedIndex = -1;

                    string sqlVlo = "SELECT numvlo FROM vuelo";
                    MySqlDataAdapter daVlo = new MySqlDataAdapter(sqlVlo, con);
                    DataTable dtVlo = new DataTable(); daVlo.Fill(dtVlo);
                    cmbVuelos.DataSource = dtVlo; cmbVuelos.ValueMember = "numvlo"; cmbVuelos.DisplayMember = "numvlo";
                    cmbVuelos.SelectedIndex = -1;

                    string sqlTipo = "SELECT id_tipo, nombre_tipo FROM tipo_reserva";
                    MySqlDataAdapter daTipo = new MySqlDataAdapter(sqlTipo, con);
                    DataTable dtTipo = new DataTable(); daTipo.Fill(dtTipo);
                    cmbTipoReserva.DataSource = dtTipo; cmbTipoReserva.ValueMember = "id_tipo"; cmbTipoReserva.DisplayMember = "nombre_tipo";
                    cmbTipoReserva.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catálogos: " + ex.Message, "Error de Infraestructura");
            }
            // Asegurar la restauración de la suscripción al evento de cálculo tras la carga masiva
            finally
            {
                this.cmbTipoReserva.SelectedIndexChanged += new System.EventHandler(this.cmbTipoReserva_SelectedIndexChanged);
            }
        }

        /// <summary>
        /// Cargar el listado de códigos de reserva disponibles para indexar búsquedas directas.
        /// </summary>
        private void CargarComboBusqueda()
        {
            try
            {
                this.cmbBuscarReserva.SelectedIndexChanged -= new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);

                using (MySqlConnection con = Datos.Conexion.AbrirConexion())
                {
                    string sql = "SELECT codigo FROM reserva";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    cmbBuscarReserva.DataSource = dt; cmbBuscarReserva.ValueMember = "codigo"; cmbBuscarReserva.DisplayMember = "codigo";
                    cmbBuscarReserva.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                // Registrar la omisión intencional de la alerta visual para optimizar la experiencia de usuario
                System.Diagnostics.Debug.WriteLine("Error de carga en indexación: " + ex.Message);
            }
            finally
            {
                this.cmbBuscarReserva.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);
            }
        }

        private void txtCodigoReserva_TextChanged(object sender, EventArgs e)
        {
            // Validar y mantener el formato prefijado obligatorio de la clave alfanumérica
            if (!txtCodigoReserva.Text.StartsWith("RES-")) { txtCodigoReserva.Text = "RES-"; txtCodigoReserva.SelectionStart = txtCodigoReserva.Text.Length; }
        }

        private void cmbTipoReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoReserva.SelectedIndex == -1 || cmbTipoReserva.SelectedValue == null)
            {
                lblCostoValor.Text = "$0";
                lblPuntosValor.Text = "0 pts";
                return;
            }

            try
            {
                int idTipo;
                if (cmbTipoReserva.SelectedValue is DataRowView)
                {
                    idTipo = Convert.ToInt32(((DataRowView)cmbTipoReserva.SelectedValue)["id_tipo"]);
                }
                else
                {
                    idTipo = Convert.ToInt32(cmbTipoReserva.SelectedValue);
                }

                double vBase, embarque, recargo;
                int puntos;

                // Invocar las reglas comerciales desde la capa de persistencia para el cálculo dinámico
                if (ReservaDatos.ObtenerReglasTipo(idTipo, out vBase, out embarque, out recargo, out puntos))
                {
                    double valorTotal = (vBase + embarque) + (vBase * recargo);
                    lblCostoValor.Text = $"${valorTotal}";
                    lblPuntosValor.Text = $"{puntos} pts";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Fallo aritmético en cotización: " + ex.Message);
            }
        }

        private void btnRegistrarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                int idTipoSelected = Convert.ToInt32(cmbTipoReserva.SelectedValue);
                double vBase, embarque, recargo;
                int puntos;

                if (!ReservaDatos.ObtenerReglasTipo(idTipoSelected, out vBase, out embarque, out recargo, out puntos))
                {
                    MessageBox.Show("No se pudieron obtener las reglas de cálculo.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Extraer el mensaje legal de condición asociado a la categoría de cabina elegida
                string mensajeCondicion = "";
                using (MySqlConnection con = Datos.Conexion.AbrirConexion())
                {
                    string sqlMsg = "SELECT condicion_mensaje FROM tipo_reserva WHERE id_tipo = @id";
                    MySqlCommand cmdMsg = new MySqlCommand(sqlMsg, con);
                    cmdMsg.Parameters.AddWithValue("@id", idTipoSelected);
                    mensajeCondicion = cmdMsg.ExecuteScalar()?.ToString();
                }

                double valorTotal = (vBase + embarque) + (vBase * recargo);
                string codigo = txtCodigoReserva.Text.ToUpper();
                string rut = cmbPasajeros.SelectedValue.ToString();
                string numvlo = cmbVuelos.SelectedValue.ToString();

                // Discriminar el flujo operativo según el estado transaccional del componente
                if (modoEdicion)
                {
                    ReservaDatos.ActualizarReserva(codigo, rut, numvlo, idTipoSelected, valorTotal, puntos);
                    MessageBox.Show($"Reserva modificada exitosamente.\n\nCondición aplicada: {mensajeCondicion}\nNuevo Total: ${valorTotal}\nAjuste de puntos completado.", "Control de Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ReservaDatos.InsertarReserva(codigo, rut, numvlo, idTipoSelected, valorTotal, puntos);
                    MessageBox.Show($"Reserva exitosa.\nTotal: ${valorTotal}\nPuntos sumados: {puntos}", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.cmbBuscarReserva.SelectedIndexChanged -= new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);

                CargarComboBusqueda();
                LimpiarCampos();

                this.cmbBuscarReserva.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);
            }
            catch (Exception ex) { MessageBox.Show("Error operacional: " + ex.Message, "Fallo de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cmbBuscarReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscarReserva.SelectedIndex == -1 || cmbBuscarReserva.SelectedValue == null) return;

            try
            {
                // Mapear los atributos físicos recuperados desde la infraestructura hacia los controles GUI
                DataRow fila = ReservaDatos.BuscarReservaPorCodigo(cmbBuscarReserva.SelectedValue.ToString());
                if (fila != null)
                {
                    int idTipoOriginal = Convert.ToInt32(fila["id_tipo_reserva"]);

                    this.cmbTipoReserva.SelectedIndexChanged -= new System.EventHandler(this.cmbTipoReserva_SelectedIndexChanged);

                    txtCodigoReserva.Text = fila["codigo"].ToString();
                    cmbPasajeros.SelectedValue = fila["rut"].ToString();
                    cmbVuelos.SelectedValue = fila["numvlo"].ToString();
                    cmbTipoReserva.SelectedValue = idTipoOriginal;

                    double vBase, embarque, recargo;
                    int puntos;
                    if (ReservaDatos.ObtenerReglasTipo(idTipoOriginal, out vBase, out embarque, out recargo, out puntos))
                    {
                        double valorTotal = (vBase + embarque) + (vBase * recargo);
                        lblCostoValor.Text = $"${valorTotal}";
                        lblPuntosValor.Text = $"{puntos} pts";
                    }

                    // Imponer restricciones de negocio estrictas para la clase económica según las pautas corporativas
                    if (idTipoOriginal == 1)
                    {
                        MessageBox.Show("Esta reserva es de clase Económica y NO SUJETA A CAMBIOS. No se puede editar.", "Restricción de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        txtCodigoReserva.Enabled = false;
                        cmbPasajeros.Enabled = false;
                        cmbVuelos.Enabled = false;
                        cmbTipoReserva.Enabled = false;
                        btnGuardar.Enabled = false;

                        btnEliminar.Enabled = true;
                        modoEdicion = false;
                    }
                    else
                    {
                        ActivarControlesEdicion(true);
                        modoEdicion = true;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al recuperar datos: " + ex.Message, "Error de Datos"); }
            finally
            {
                this.cmbTipoReserva.SelectedIndexChanged += new System.EventHandler(this.cmbTipoReserva_SelectedIndexChanged);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoReserva.Text) || txtCodigoReserva.Text == "RES-")
            {
                MessageBox.Show("Seleccione una reserva activa para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Desea eliminar la reserva seleccionada?\nSe descontarán los puntos asignados al pasajero.", "Aviso de Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    this.cmbBuscarReserva.SelectedIndexChanged -= new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);

                    ReservaDatos.EliminarReserva(txtCodigoReserva.Text.ToUpper());
                    MessageBox.Show("Reserva removida del sistema.", "Operación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarComboBusqueda();
                    LimpiarCampos();

                    this.cmbBuscarReserva.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);
                }
                catch (Exception ex) { MessageBox.Show("Fallo al eliminar: " + ex.Message, "Error de Persistencia"); }
            }
        }

        /// <summary>
        /// Alterar el estado de habilitación de los componentes de entrada durante los ciclos de edición.
        /// </summary>
        /// <param name="activar">Valor booleano de conmutación.</param>
        private void ActivarControlesEdicion(bool activar)
        {
            txtCodigoReserva.Enabled = activar;
            cmbPasajeros.Enabled = activar;
            cmbVuelos.Enabled = activar;
            cmbTipoReserva.Enabled = activar;
            btnGuardar.Enabled = activar;
            gbDatos.Enabled = true;
        }

        /// <summary>
        /// Restablecer los contextos de enlace y limpiar los campos de texto a su estado inicial.
        /// </summary>
        public void LimpiarCampos()
        {
            this.cmbBuscarReserva.SelectedIndexChanged -= new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);
            this.cmbTipoReserva.SelectedIndexChanged -= new System.EventHandler(this.cmbTipoReserva_SelectedIndexChanged);

            cmbPasajeros.BindingContext = new BindingContext();
            cmbVuelos.BindingContext = new BindingContext();
            cmbTipoReserva.BindingContext = new BindingContext();
            cmbBuscarReserva.BindingContext = new BindingContext();

            txtCodigoReserva.Text = "RES-";
            cmbPasajeros.SelectedIndex = -1;
            cmbVuelos.SelectedIndex = -1;
            cmbTipoReserva.SelectedIndex = -1;
            cmbBuscarReserva.SelectedIndex = -1;

            lblCostoValor.Text = "$0";
            lblPuntosValor.Text = "0 pts";

            ActivarControlesEdicion(true);
            btnEliminar.Enabled = true;
            modoEdicion = false;

            this.cmbBuscarReserva.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);
            this.cmbTipoReserva.SelectedIndexChanged += new System.EventHandler(this.cmbTipoReserva_SelectedIndexChanged);
        }
    }
}