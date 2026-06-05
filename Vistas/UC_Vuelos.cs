using System;
using System.Data;
using System.Windows.Forms;
using SistemaGestionAerolinea.Datos;

namespace SistemaGestionAerolinea.Vistas
{
    /// <summary>
    /// Control de usuario encargado del procesamiento de inserciones, modificaciones, consultas y bajas operativas del módulo de vuelos.
    /// </summary>
    public partial class UC_Vuelos : UserControl
    {
        private string vueloSeleccionado = "";

        public UC_Vuelos()
        {
            InitializeComponent();
            CargarComboBusqueda();
            CargarDestinosDesdeBD();
            LimpiarCampos();
        }

        /// <summary>
        /// Inicializar y poblar el catálogo de destinos geográficos desde el motor de base de datos.
        /// </summary>
        private void CargarDestinosDesdeBD()
        {
            try
            {
                DataTable dt = VueloDatos.ObtenerDestinos();

                cmbDestino.DataSource = null;
                cmbDestino.ValueMember = "id_destino";
                cmbDestino.DisplayMember = "nombre_destino";
                cmbDestino.DataSource = dt;
                cmbDestino.SelectedIndex = -1;
                cmbDestino.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar catálogo relacional de destinos: " + ex.Message, "Error de Datos");
            }
        }

        /// <summary>
        /// Cargar los códigos identificadores de vuelos para habilitar las funciones de búsqueda indexada.
        /// </summary>
        private void CargarComboBusqueda()
        {
            try
            {
                DataTable dt = VueloDatos.ObtenerCodigosVuelos();

                cmbBuscarVuelo.SelectedIndexChanged -= cmbBuscarVuelo_SelectedIndexChanged;
                cmbBuscarVuelo.DataSource = null;
                cmbBuscarVuelo.ValueMember = "numvlo";
                cmbBuscarVuelo.DisplayMember = "numvlo";
                cmbBuscarVuelo.DataSource = dt;
                cmbBuscarVuelo.SelectedIndex = -1;
                cmbBuscarVuelo.SelectedIndexChanged += cmbBuscarVuelo_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el buscador de vuelos: " + ex.Message, "Error de Datos");
            }
        }

        private void txtCodigoVuelo_TextChanged(object sender, EventArgs e)
        {
            // Validar y asegurar el prefijo alfanumérico obligatorio en la entrada de datos
            if (!txtCodigoVuelo.Text.StartsWith("DMK-", StringComparison.OrdinalIgnoreCase))
            {
                txtCodigoVuelo.Text = "DMK-";
                txtCodigoVuelo.SelectionStart = txtCodigoVuelo.Text.Length;
            }
        }

        private void btnGuardarVuelo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoVuelo.Text) || txtCodigoVuelo.Text.Trim().Length <= 4 || string.IsNullOrWhiteSpace(cmbDestino.Text))
            {
                MessageBox.Show("Debe completar la información requerida del itinerario (Número de Vuelo y Destino).",
                                "Información Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string horaTipeada = txtHora.Text.Trim().PadLeft(2, '0');
            string minutoTipeado = txtMinuto.Text.Trim().PadLeft(2, '0');

            // Validar los límites aritméticos correspondientes a la estructura de tiempo de 24 horas
            if (!int.TryParse(horaTipeada, out int hh) || hh < 0 || hh > 23 ||
                !int.TryParse(minutoTipeado, out int mm) || mm < 0 || mm > 59)
            {
                MessageBox.Show("El formato de tiempo ingresado es inválido. La hora debe estar entre 00 y 23, y los minutos entre 00 y 59.",
                                "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtHora.Text = horaTipeada;
            txtMinuto.Text = minutoTipeado;

            try
            {
                int idDestinoFinal = 0;
                string textoDestino = cmbDestino.Text.Trim();

                if (cmbDestino.SelectedValue == null || cmbDestino.SelectedIndex == -1)
                {
                    idDestinoFinal = VueloDatos.RegistrarDestinoPreventivo(textoDestino);
                }
                else
                {
                    idDestinoFinal = Convert.ToInt32(cmbDestino.SelectedValue);
                }

                string fechaFormateada = dtpFechaSalida.Value.ToString("dd-MM-yyyy");
                string horaFormateada = $"{horaTipeada}:{minutoTipeado}";
                string numeroVueloFinal = txtCodigoVuelo.Text.Trim().ToUpper();
                bool operacionExitosa = false;

                // Discriminar entre la inserción de un nuevo registro o la modificación de uno existente
                if (!string.IsNullOrEmpty(vueloSeleccionado))
                {
                    operacionExitosa = VueloDatos.ActualizarVuelo(vueloSeleccionado, fechaFormateada, horaFormateada, idDestinoFinal);
                }
                else
                {
                    if (VueloDatos.ExisteVuelo(numeroVueloFinal))
                    {
                        MessageBox.Show("Ya existe un vuelo registrado con ese número identificador.",
                                        "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    operacionExitosa = VueloDatos.RegistrarVuelo(numeroVueloFinal, fechaFormateada, horaFormateada, idDestinoFinal);
                }

                if (operacionExitosa)
                {
                    string mensaje = !string.IsNullOrEmpty(vueloSeleccionado)
                        ? $"Los datos del vuelo {numeroVueloFinal} fueron actualizados con éxito."
                        : $"El vuelo {numeroVueloFinal} fue programado exitosamente.";

                    MessageBox.Show(mensaje, "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarComboBusqueda();
                    CargarDestinosDesdeBD();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la persistencia del itinerario: " + ex.Message, "Error de Ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarVuelo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(vueloSeleccionado))
            {
                MessageBox.Show("Seleccione un registro del buscador para proceder con la baja.", "Aviso");
                return;
            }

            string codigoBorrado = txtCodigoVuelo.Text.ToUpper();

            if (MessageBox.Show($"¿Confirma la eliminación permanente del vuelo {codigoBorrado}?\nEsta acción es irreversible.",
                                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Validar restricciones de integridad referencial antes de proceder con la baja física
                    if (VueloDatos.TieneReservasAsociadas(vueloSeleccionado))
                    {
                        MessageBox.Show("Restricción de integridad: No se puede eliminar el vuelo porque existen reservas comerciales vinculadas a este itinerario.",
                                        "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (VueloDatos.EliminarVuelo(vueloSeleccionado))
                    {
                        MessageBox.Show("Registro de vuelo eliminado del sistema de operaciones.", "Operación Finalizada");
                        CargarComboBusqueda();
                        CargarDestinosDesdeBD();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error durante el proceso de eliminación: " + ex.Message, "Error de Datos");
                }
            }
        }

        private void cmbBuscarVuelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscarVuelo.SelectedValue != null && cmbBuscarVuelo.SelectedIndex != -1)
            {
                try
                {
                    vueloSeleccionado = cmbBuscarVuelo.SelectedValue.ToString();
                    DataRow fila = VueloDatos.BuscarVueloPorCodigo(vueloSeleccionado);

                    if (fila != null)
                    {
                        txtCodigoVuelo.Text = fila["numvlo"].ToString();
                        cmbDestino.SelectedValue = fila["id_destino"];

                        string stringFecha = fila["fecha"].ToString();
                        string stringHora = fila["hora"].ToString();

                        // Procesar el análisis gramatical de la fecha bajo el formato de almacenamiento estricto
                        if (DateTime.TryParseExact(stringFecha, "dd-MM-yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out DateTime fechaMapeada))
                        {
                            dtpFechaSalida.Value = fechaMapeada;
                        }

                        // Procesar la segmentación de la cadena de texto de la hora para poblar la interfaz de usuario
                        if (!string.IsNullOrEmpty(stringHora) && stringHora.Contains(":"))
                        {
                            string[] partesHora = stringHora.Split(':');
                            if (partesHora.Length >= 2)
                            {
                                txtHora.Text = partesHora[0].PadLeft(2, '0');
                                txtMinuto.Text = partesHora[1].PadLeft(2, '0');
                            }
                        }
                        else
                        {
                            txtHora.Text = "12";
                            txtMinuto.Text = "00";
                        }

                        txtCodigoVuelo.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al recuperar el registro de vuelo: " + ex.Message, "Error de Datos");
                }
            }
        }

        /// <summary>
        /// Restablecer los campos de texto y controles de fecha a su estado inicial por defecto.
        /// </summary>
        public void LimpiarCampos()
        {
            txtCodigoVuelo.Text = "DMK-";
            cmbDestino.SelectedIndex = -1;
            cmbDestino.Text = "";
            dtpFechaSalida.Value = DateTime.Now;
            txtHora.Text = "12";
            txtMinuto.Text = "00";
            cmbBuscarVuelo.SelectedIndex = -1;
            vueloSeleccionado = "";
            txtCodigoVuelo.Enabled = true;
        }

        private void btnLimpiarVuelo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtCodigoVuelo.Focus();
            txtCodigoVuelo.SelectionStart = txtCodigoVuelo.Text.Length;
        }
    }
}