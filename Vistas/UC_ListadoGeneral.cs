using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaGestionAerolinea.Datos;

namespace SistemaGestionAerolinea.Vistas
{
    /// <summary>
    /// Control de usuario encargado de renderizar el listado maestro consolidado de todas las reservas del sistema.
    /// </summary>
    public partial class UC_ListadoGeneral : UserControl
    {
        public UC_ListadoGeneral()
        {
            InitializeComponent();
            CargarListadoMaestro();
        }

        /// <summary>
        /// Recuperar los registros históricos desde la capa de persistencia y poblar la grilla de la interfaz de usuario.
        /// </summary>
        private void CargarListadoMaestro()
        {
            try
            {
                // Invocar de forma desacoplada la consulta relacional unificada en la capa de datos
                DataTable dt = ReporteDatos.ObtenerHistorialMaestro();

                dgvListadoGeneral.DataSource = null;
                dgvListadoGeneral.DataSource = dt;

                FormatearColumnas();

                int total = dt.Rows.Count;
                lblTotalRegistros.Text = $"Reservas comerciales integradas en el sistema central: {total}";
                lblTotalRegistros.ForeColor = (total > 0) ? Color.DarkBlue : Color.DarkRed;

                dgvListadoGeneral.ReadOnly = true;
                dgvListadoGeneral.AllowUserToAddRows = false;
                dgvListadoGeneral.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListadoGeneral.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar el archivo maestro de reservas: " + ex.Message, "Error de Datos");
            }
        }

        /// <summary>
        /// Establecer las cabeceras personalizadas y formatos numéricos de las columnas de la grilla de datos.
        /// </summary>
        private void FormatearColumnas()
        {
            if (dgvListadoGeneral.Columns.Count > 0)
            {
                dgvListadoGeneral.Columns["CodigoReserva"].HeaderText = "Código Reserva";
                dgvListadoGeneral.Columns["PasajeroRut"].HeaderText = "RUT Pasajero";
                dgvListadoGeneral.Columns["PasajeroNombre"].HeaderText = "Nombre Completo";
                dgvListadoGeneral.Columns["VueloNumero"].HeaderText = "N° Vuelo";
                dgvListadoGeneral.Columns["Destino"].HeaderText = "Destino";
                dgvListadoGeneral.Columns["FechaSalida"].HeaderText = "Fecha Salida";
                dgvListadoGeneral.Columns["HoraSalida"].HeaderText = "Hora Salida";
                dgvListadoGeneral.Columns["ClaseTipo"].HeaderText = "Clase / Cabina";
                dgvListadoGeneral.Columns["ValorTotal"].HeaderText = "Total Abonado";

                dgvListadoGeneral.Columns["ValorTotal"].DefaultCellStyle.Format = "$#,0";
                dgvListadoGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}