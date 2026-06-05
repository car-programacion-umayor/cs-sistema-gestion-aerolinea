namespace SistemaGestionAerolinea.Vistas
{
    partial class UC_GenerarReserva
    {
        /// <summary> 
        /// Variable del diseñador requerida para la gestión de componentes.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos de infraestructura que se estén utilizando.
        /// </summary>
        /// <param name="disposing">Valor booleano que indica si los recursos administrados deben ser desechados.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método requerido para admitir el Diseñador. No modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCostoTexto = new System.Windows.Forms.Label();
            this.lblPuntosTexto = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cmbBuscarReserva = new System.Windows.Forms.ComboBox();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigoReserva = new System.Windows.Forms.TextBox();
            this.lblPasajero = new System.Windows.Forms.Label();
            this.cmbPasajeros = new System.Windows.Forms.ComboBox();
            this.lblVuelo = new System.Windows.Forms.Label();
            this.cmbVuelos = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipoReserva = new System.Windows.Forms.ComboBox();
            this.lblCostoValor = new System.Windows.Forms.Label();
            this.lblPuntosValor = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCostoTexto
            // 
            this.lblCostoTexto.Location = new System.Drawing.Point(20, 155);
            this.lblCostoTexto.Name = "lblCostoTexto";
            this.lblCostoTexto.Size = new System.Drawing.Size(100, 23);
            this.lblCostoTexto.TabIndex = 11;
            this.lblCostoTexto.Text = "Costo Pasaje:";
            // 
            // lblPuntosTexto
            // 
            this.lblPuntosTexto.Location = new System.Drawing.Point(20, 178);
            this.lblPuntosTexto.Name = "lblPuntosTexto";
            this.lblPuntosTexto.Size = new System.Drawing.Size(100, 23);
            this.lblPuntosTexto.TabIndex = 12;
            this.lblPuntosTexto.Text = "Puntos Gana:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTitulo.Location = new System.Drawing.Point(50, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(134, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "GESTIÓN DE RESERVAS";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(50, 60);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(175, 13);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Seleccione una reserva para editar:";
            // 
            // cmbBuscarReserva
            // 
            this.cmbBuscarReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscarReserva.Location = new System.Drawing.Point(50, 80);
            this.cmbBuscarReserva.Name = "cmbBuscarReserva";
            this.cmbBuscarReserva.Size = new System.Drawing.Size(250, 21);
            this.cmbBuscarReserva.TabIndex = 2;
            this.cmbBuscarReserva.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarReserva_SelectedIndexChanged);
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.lblCodigo);
            this.gbDatos.Controls.Add(this.txtCodigoReserva);
            this.gbDatos.Controls.Add(this.lblPasajero);
            this.gbDatos.Controls.Add(this.cmbPasajeros);
            this.gbDatos.Controls.Add(this.lblVuelo);
            this.gbDatos.Controls.Add(this.cmbVuelos);
            this.gbDatos.Controls.Add(this.lblTipo);
            this.gbDatos.Controls.Add(this.cmbTipoReserva);
            this.gbDatos.Controls.Add(this.lblCostoTexto);
            this.gbDatos.Controls.Add(this.lblCostoValor);
            this.gbDatos.Controls.Add(this.lblPuntosTexto);
            this.gbDatos.Controls.Add(this.lblPuntosValor);
            this.gbDatos.Controls.Add(this.btnGuardar);
            this.gbDatos.Controls.Add(this.btnLimpiar);
            this.gbDatos.Controls.Add(this.btnEliminar);
            this.gbDatos.Location = new System.Drawing.Point(50, 120);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(500, 250);
            this.gbDatos.TabIndex = 3;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos de Reserva";
            // 
            // lblCodigo
            // 
            this.lblCodigo.Location = new System.Drawing.Point(20, 30);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(100, 23);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigoReserva
            // 
            this.txtCodigoReserva.Location = new System.Drawing.Point(120, 27);
            this.txtCodigoReserva.Name = "txtCodigoReserva";
            this.txtCodigoReserva.Size = new System.Drawing.Size(150, 20);
            this.txtCodigoReserva.TabIndex = 1;
            this.txtCodigoReserva.TextChanged += new System.EventHandler(this.txtCodigoReserva_TextChanged);
            // 
            // lblPasajero
            // 
            this.lblPasajero.Location = new System.Drawing.Point(20, 60);
            this.lblPasajero.Name = "lblPasajero";
            this.lblPasajero.Size = new System.Drawing.Size(100, 23);
            this.lblPasajero.TabIndex = 2;
            this.lblPasajero.Text = "Pasajero:";
            // 
            // cmbPasajeros
            // 
            this.cmbPasajeros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPasajeros.Location = new System.Drawing.Point(120, 57);
            this.cmbPasajeros.Name = "cmbPasajeros";
            this.cmbPasajeros.Size = new System.Drawing.Size(300, 21);
            this.cmbPasajeros.TabIndex = 3;
            // 
            // lblVuelo
            // 
            this.lblVuelo.Location = new System.Drawing.Point(20, 90);
            this.lblVuelo.Name = "lblVuelo";
            this.lblVuelo.Size = new System.Drawing.Size(100, 23);
            this.lblVuelo.TabIndex = 4;
            this.lblVuelo.Text = "Vuelo:";
            // 
            // cmbVuelos
            // 
            this.cmbVuelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVuelos.Location = new System.Drawing.Point(120, 87);
            this.cmbVuelos.Name = "cmbVuelos";
            this.cmbVuelos.Size = new System.Drawing.Size(300, 21);
            this.cmbVuelos.TabIndex = 5;
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(20, 120);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 23);
            this.lblTipo.TabIndex = 6;
            this.lblTipo.Text = "Tipo:";
            // 
            // cmbTipoReserva
            // 
            this.cmbTipoReserva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoReserva.Location = new System.Drawing.Point(120, 117);
            this.cmbTipoReserva.Name = "cmbTipoReserva";
            this.cmbTipoReserva.Size = new System.Drawing.Size(200, 21);
            this.cmbTipoReserva.TabIndex = 7;
            this.cmbTipoReserva.SelectedIndexChanged += new System.EventHandler(this.cmbTipoReserva_SelectedIndexChanged);
            // 
            // lblCostoValor
            // 
            this.lblCostoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCostoValor.Location = new System.Drawing.Point(120, 153);
            this.lblCostoValor.Name = "lblCostoValor";
            this.lblCostoValor.Size = new System.Drawing.Size(150, 23);
            this.lblCostoValor.TabIndex = 13;
            this.lblCostoValor.Text = "$0";
            // 
            // lblPuntosValor
            // 
            this.lblPuntosValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblPuntosValor.Location = new System.Drawing.Point(120, 176);
            this.lblPuntosValor.Name = "lblPuntosValor";
            this.lblPuntosValor.Size = new System.Drawing.Size(150, 23);
            this.lblPuntosValor.TabIndex = 14;
            this.lblPuntosValor.Text = "0 pts";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(20, 210);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.Click += new System.EventHandler(this.btnRegistrarReserva_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(110, 210);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Location = new System.Drawing.Point(436, 199);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(37, 34);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // UC_GenerarReserva
            // 
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.cmbBuscarReserva);
            this.Controls.Add(this.gbDatos);
            this.Name = "UC_GenerarReserva";
            this.Size = new System.Drawing.Size(600, 400);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox cmbBuscarReserva;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigoReserva;
        private System.Windows.Forms.Label lblPasajero;
        private System.Windows.Forms.ComboBox cmbPasajeros;
        private System.Windows.Forms.Label lblVuelo;
        private System.Windows.Forms.ComboBox cmbVuelos;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipoReserva;
        private System.Windows.Forms.Label lblCostoValor;
        private System.Windows.Forms.Label lblPuntosValor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblCostoTexto;
        private System.Windows.Forms.Label lblPuntosTexto;
    }
}