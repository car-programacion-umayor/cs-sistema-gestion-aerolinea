using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaGestionAerolinea.Datos;

namespace SistemaGestionAerolinea.Vistas
{
    /// <summary>
    /// Control de usuario encargado del procesamiento de inserciones, modificaciones, consultas y eliminaciones del módulo de pasajeros.
    /// </summary>
    public partial class UC_Pasajeros : UserControl
    {
        private string rutPasajeroSeleccionado = "";

        public UC_Pasajeros()
        {
            InitializeComponent();
            CargarComboBusqueda();
            CargarTiposDesdeBD();
            LimpiarCampos();
        }

        /// <summary>
        /// Inicializar y poblar el catálogo de tipos de pasajero desde el motor de base de datos.
        /// </summary>
        private void CargarTiposDesdeBD()
        {
            try
            {
                using (MySqlConnection conexion = Datos.Conexion.AbrirConexion())
                {
                    if (conexion == null) return;

                    string sql = "SELECT id_tipo, nombre_tipo FROM tipo_pasajero ORDER BY nombre_tipo ASC";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexion);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    cmbTipo.DataSource = null;
                    cmbTipo.ValueMember = "id_tipo";
                    cmbTipo.DisplayMember = "nombre_tipo";
                    cmbTipo.DataSource = dt;
                    cmbTipo.SelectedIndex = -1;
                    cmbTipo.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar catálogo relacional de tipos: " + ex.Message, "Error de Datos");
            }
        }

        /// <summary>
        /// Cargar los identificadores de los pasajeros para habilitar las funciones de búsqueda indexada.
        /// </summary>
        private void CargarComboBusqueda()
        {
            try
            {
                using (MySqlConnection conexion = Datos.Conexion.AbrirConexion())
                {
                    if (conexion != null)
                    {
                        string sql = "SELECT rut FROM pasajero ORDER BY rut ASC";
                        MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conexion);
                        DataTable dt = new DataTable();
                        adaptador.Fill(dt);

                        cmbBuscarPasajero.SelectedIndexChanged -= cmbBuscarPasajero_SelectedIndexChanged;
                        cmbBuscarPasajero.DataSource = null;
                        cmbBuscarPasajero.ValueMember = "rut";
                        cmbBuscarPasajero.DisplayMember = "rut";
                        cmbBuscarPasajero.DataSource = dt;
                        cmbBuscarPasajero.SelectedIndex = -1;
                        cmbBuscarPasajero.SelectedIndexChanged += cmbBuscarPasajero_SelectedIndexChanged;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al cargar catálogo de búsqueda de pasajeros: " + ex.Message, "Error de Datos");
            }
        }

        /// <summary>
        /// Validar la estructura sintáctica del RUT mediante expresiones regulares.
        /// </summary>
        /// <param name="rut">Cadena de texto con el RUT a evaluar.</param>
        /// <returns>Valor booleano que indica la validez del formato.</returns>
        private bool ValidarRutPrueba(string rut)
        {
            rut = rut.Trim().ToUpper().Replace(".", "");
            if (System.Text.RegularExpressions.Regex.IsMatch(rut, @"^\d{7,8}-[\dK]$")) return true;
            if (System.Text.RegularExpressions.Regex.IsMatch(rut, @"^\d{7,8}[\dK]$")) return true;
            return false;
        }

        /// <summary>
        /// Normalizar la presentación del RUT agregando el guion demarcador del dígito verificador.
        /// </summary>
        /// <param name="rut">Cadena de texto del RUT sin formato.</param>
        /// <returns>Cadena de texto formateada.</returns>
        private string FormatearRutPrueba(string rut)
        {
            rut = rut.Trim().ToUpper().Replace(".", "").Replace("-", "");
            if (rut.Length < 2) return rut;

            string cuerpo = rut.Substring(0, rut.Length - 1);
            string dv = rut.Substring(rut.Length - 1, 1);
            return cuerpo + "-" + dv;
        }

        private void btnGuardarPasajero_Click(object sender, EventArgs e)
        {
            txtRut.Text = FormatearRutPrueba(txtRut.Text);

            if (!ValidarRutPrueba(txtRut.Text))
            {
                MessageBox.Show("El RUT ingresado no tiene un formato válido.", "RUT inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRut.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRut.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(cmbTipo.Text))
            {
                MessageBox.Show("Debe completar los campos obligatorios para guardar el registro.", "Información Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPuntaje.Text.Trim(), out int puntajeValidado))
            {
                puntajeValidado = 0;
            }

            try
            {
                int idTipoFinal = 0;
                string textoTipo = cmbTipo.Text.Trim();

                // Procesar la inserción e indexación de nuevas categorías no registradas previamente
                if (cmbTipo.SelectedValue == null || cmbTipo.SelectedIndex == -1)
                {
                    using (MySqlConnection con = Datos.Conexion.AbrirConexion())
                    {
                        string sqlInsertTipo = "INSERT IGNORE INTO tipo_pasajero (nombre_tipo) VALUES (@nomTipo); SELECT id_tipo FROM tipo_pasajero WHERE nombre_tipo = @nomTipo;";
                        using (MySqlCommand cmdTipoNew = new MySqlCommand(sqlInsertTipo, con))
                        {
                            cmdTipoNew.Parameters.AddWithValue("@nomTipo", textoTipo);
                            idTipoFinal = Convert.ToInt32(cmdTipoNew.ExecuteScalar());
                        }
                    }
                }
                else
                {
                    idTipoFinal = Convert.ToInt32(cmbTipo.SelectedValue);
                }

                string nombreCompleto = $"{txtApellido.Text}, {txtNombre.Text}";

                // Discriminar entre la inserción de un nuevo registro o la modificación de uno existente
                if (!string.IsNullOrEmpty(rutPasajeroSeleccionado))
                {
                    PasajeroDatos.ActualizarPasajero(rutPasajeroSeleccionado, txtNombre.Text.Trim(), txtApellido.Text.Trim(), idTipoFinal, puntajeValidado);
                    MessageBox.Show($"Los datos de el/la pasajero(a) [{nombreCompleto}] se han modificado exitosamente en el sistema maestro.", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string rutNuevo = txtRut.Text.Trim().ToUpper();
                    if (PasajeroDatos.ExistePasajero(rutNuevo))
                    {
                        MessageBox.Show("Ya existe un pasajero registrado con ese RUT.", "RUT duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    PasajeroDatos.InsertarPasajero(rutNuevo, txtNombre.Text.Trim(), txtApellido.Text.Trim(), idTipoFinal, puntajeValidado);
                    MessageBox.Show($"El/La pasajero(a) [{nombreCompleto}] con RUT [{rutNuevo}] ha sido ingresado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarCampos();
                CargarComboBusqueda();
                CargarTiposDesdeBD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el procesamiento de datos: " + ex.Message, "Error de Ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBuscarPasajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscarPasajero.SelectedValue != null && cmbBuscarPasajero.SelectedIndex != -1)
            {
                try
                {
                    rutPasajeroSeleccionado = cmbBuscarPasajero.SelectedValue.ToString();
                    DataRow fila = PasajeroDatos.BuscarPasajeroPorRut(rutPasajeroSeleccionado);

                    if (fila != null)
                    {
                        txtRut.Text = fila["rut"].ToString();
                        txtNombre.Text = fila["nombre"].ToString();
                        txtApellido.Text = fila["apellido"].ToString();
                        cmbTipo.SelectedValue = fila["id_tipo"];
                        txtPuntaje.Text = fila["puntaje"].ToString();

                        txtRut.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al recuperar el registro seleccionado: " + ex.Message, "Error de Datos");
                }
            }
        }

        private void btnBuscarRut_Click(object sender, EventArgs e)
        {
            txtRut.Text = FormatearRutPrueba(txtRut.Text);
            string rutBusqueda = txtRut.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(rutBusqueda)) return;

            try
            {
                DataRow fila = PasajeroDatos.BuscarPasajeroPorRut(rutBusqueda);

                if (fila != null)
                {
                    rutPasajeroSeleccionado = fila["rut"].ToString();
                    txtRut.Text = fila["rut"].ToString();
                    txtNombre.Text = fila["nombre"].ToString();
                    txtApellido.Text = fila["apellido"].ToString();
                    cmbTipo.SelectedValue = fila["id_tipo"];
                    txtPuntaje.Text = fila["puntaje"].ToString();

                    txtRut.Enabled = false;
                }
                else
                {
                    rutPasajeroSeleccionado = "";
                    txtNombre.Clear();
                    txtApellido.Clear();
                    cmbTipo.SelectedIndex = -1;
                    cmbTipo.Text = "";
                    txtPuntaje.Clear();

                    txtRut.Text = rutBusqueda;
                    txtRut.Enabled = true;
                    txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el pasajero: " + ex.Message, "Error de Datos");
            }
        }

        private void btnEliminarPasajero_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutPasajeroSeleccionado)) return;

            string nombrePasajero = $"{txtApellido.Text}, {txtNombre.Text}";

            if (MessageBox.Show($"¿Desea eliminar de forma permanente al pasajero [{nombrePasajero}] de los registros?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Validar restricciones de integridad referencial antes de proceder con la baja física
                    if (PasajeroDatos.TieneReservasActivas(rutPasajeroSeleccionado))
                    {
                        MessageBox.Show("No es posible eliminar al pasajero debido a que posee reservas activas vinculadas en el sistema de vuelos.", "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    PasajeroDatos.EliminarPasajero(rutPasajeroSeleccionado);
                    MessageBox.Show($"El/La pasajero(a) [{nombrePasajero}] ha sido removido exitosamente de la base de datos maestra.", "Operación Procesada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                    CargarComboBusqueda();
                    CargarTiposDesdeBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durante el proceso de eliminación: " + ex.Message, "Error de Datos");
                }
            }
        }

        /// <summary>
        /// Restablecer todos los campos de texto y controles de selección a su estado inicial por defecto.
        /// </summary>
        public void LimpiarCampos()
        {
            txtRut.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cmbTipo.SelectedIndex = -1;
            cmbTipo.Text = "";

            txtPuntaje.Text = "0";
            txtPuntaje.ReadOnly = true;

            cmbBuscarPasajero.SelectedIndex = -1;
            rutPasajeroSeleccionado = "";
            txtRut.Enabled = true;
        }

        private void btnLimpiarPasajero_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtRut.Focus();
        }
    }
}