using System;
using System.Data;
using System.Windows.Forms;
using SistemaGestionAerolinea.Datos;

namespace SistemaGestionAerolinea.Vistas
{
    /// <summary>
    /// Control de usuario encargado de las consultas indexadas y segmentadas por pasajero o vuelo.
    /// </summary>
    public partial class UC_Consultas : UserControl
    {
        public UC_Consultas()
        {
            InitializeComponent();
            ConfigurarEstiloGrillas();
            CargarFiltrosMaestros();
        }

        /// <summary>
        /// Configurar los parámetros estéticos y de comportamiento de las grillas de visualización.
        /// </summary>
        private void ConfigurarEstiloGrillas()
        {
            DataGridView[] grillas = { dgvDatosPasajero, dgvDatosVuelo };
            foreach (var g in grillas)
            {
                g.ReadOnly = true;
                g.AllowUserToAddRows = false;
                g.RowHeadersVisible = false;
                g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                g.BackgroundColor = System.Drawing.Color.White;
            }
        }

        /// <summary>
        /// Cargar los datos de los componentes de selección de filtros desde la capa de persistencia.
        /// </summary>
        private void CargarFiltrosMaestros()
        {
            try
            {
                // Recuperar y enlazar el catálogo de pasajeros al componente de selección correspondientes
                DataTable dtPasajeros = PasajeroDatos.ObtenerPasajeros();
                cmbConsultaPasajero.SelectedIndexChanged -= cmbConsultaPasajero_SelectedIndexChanged;
                cmbConsultaPasajero.DataSource = dtPasajeros;
                cmbConsultaPasajero.ValueMember = "rut";
                cmbConsultaPasajero.DisplayMember = "nombre_completo";
                cmbConsultaPasajero.SelectedIndex = -1;
                cmbConsultaPasajero.SelectedIndexChanged += cmbConsultaPasajero_SelectedIndexChanged;

                // Recuperar y enlazar el catálogo de vuelos al componente de selección correspondientes
                DataTable dtVuelos = VueloDatos.ObtenerCodigosVuelos();
                cmbConsultaVuelo.SelectedIndexChanged -= cmbConsultaVuelo_SelectedIndexChanged;
                cmbConsultaVuelo.DataSource = dtVuelos;
                cmbConsultaVuelo.ValueMember = "numvlo";
                cmbConsultaVuelo.DisplayMember = "numvlo";
                cmbConsultaVuelo.SelectedIndex = -1;
                cmbConsultaVuelo.SelectedIndexChanged += cmbConsultaVuelo_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar filtros indexados: " + ex.Message, "Error de Datos");
            }
        }

        private void cmbConsultaPasajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConsultaPasajero.SelectedValue == null || cmbConsultaPasajero.SelectedIndex == -1) return;

            try
            {
                string rut = cmbConsultaPasajero.SelectedValue.ToString();
                DataTable dt = ReporteDatos.ObtenerReservasPorPasajero(rut);

                dgvDatosPasajero.DataSource = null;
                dgvDatosPasajero.DataSource = dt;

                if (dgvDatosPasajero.Columns.Count > 0)
                {
                    dgvDatosPasajero.Columns["CodigoReserva"].HeaderText = "Código Reserva";
                    dgvDatosPasajero.Columns["VueloNumero"].HeaderText = "N° Vuelo";
                    dgvDatosPasajero.Columns["Destino"].HeaderText = "Destino";
                    dgvDatosPasajero.Columns["FechaSalida"].HeaderText = "Fecha Vuelo";
                    dgvDatosPasajero.Columns["HoraSalida"].HeaderText = "Hora Salida";
                    dgvDatosPasajero.Columns["ClaseTipo"].HeaderText = "Cabina / Tarifa";
                    dgvDatosPasajero.Columns["ValorTotal"].HeaderText = "Total Abonado";

                    dgvDatosPasajero.Columns["ValorTotal"].DefaultCellStyle.Format = "$#,0";
                    dgvDatosPasajero.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al consultar por pasajero: " + ex.Message, "Error de Consulta");
            }
        }

        private void cmbConsultaVuelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConsultaVuelo.SelectedValue == null || cmbConsultaVuelo.SelectedIndex == -1) return;

            try
            {
                string numvlo = cmbConsultaVuelo.SelectedValue.ToString();
                DataTable dt = ReporteDatos.ObtenerPasajerosPorVuelo(numvlo);

                dgvDatosVuelo.DataSource = null;
                dgvDatosVuelo.DataSource = dt;

                if (dgvDatosVuelo.Columns.Count > 0)
                {
                    dgvDatosVuelo.Columns["CodigoReserva"].HeaderText = "Código Reserva";
                    dgvDatosVuelo.Columns["PasajeroRut"].HeaderText = "RUT Pasajero";
                    dgvDatosVuelo.Columns["PasajeroNombre"].HeaderText = "Nombre Completo";
                    dgvDatosVuelo.Columns["ClaseTipo"].HeaderText = "Tipo Tarifa";
                    dgvDatosVuelo.Columns["ValorTotal"].HeaderText = "Monto Pasaje";

                    dgvDatosVuelo.Columns["ValorTotal"].DefaultCellStyle.Format = "$#,0";
                    dgvDatosVuelo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al consultar por vuelo: " + ex.Message, "Error de Consulta");
            }
        }
    }
}