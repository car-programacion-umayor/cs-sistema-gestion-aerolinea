namespace SistemaGestionAerolinea.Vistas
{
    partial class UC_Vuelos
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método requerido para admitir el Diseñador. No modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbBuscarVuelo = new System.Windows.Forms.ComboBox();
            this.gbRegistroVuelo = new System.Windows.Forms.GroupBox();
            this.btnLimpiarVuelo = new System.Windows.Forms.Button();
            this.txtCodigoVuelo = new System.Windows.Forms.TextBox();
            this.btnEliminarVuelo = new System.Windows.Forms.Button();
            this.lblCodigoVuelo = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.cmbDestino = new System.Windows.Forms.ComboBox();
            this.lblFechaSalida = new System.Windows.Forms.Label();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblDosPuntos = new System.Windows.Forms.Label();
            this.txtMinuto = new System.Windows.Forms.TextBox();
            this.btnGuardarVuelo = new System.Windows.Forms.Button();
            this.lblTituloGestionVuelo = new System.Windows.Forms.Label();
            this.lblSeleccionarVuelo = new System.Windows.Forms.Label();
            this.gbRegistroVuelo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBuscarVuelo
            // 
            this.cmbBuscarVuelo.FormattingEnabled = true;
            this.cmbBuscarVuelo.Location = new System.Drawing.Point(199, 101);
            this.cmbBuscarVuelo.Name = "cmbBuscarVuelo";
            this.cmbBuscarVuelo.Size = new System.Drawing.Size(170, 21);
            this.cmbBuscarVuelo.TabIndex = 0;
            this.cmbBuscarVuelo.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarVuelo_SelectedIndexChanged);
            // 
            // gbRegistroVuelo
            // 
            this.gbRegistroVuelo.Controls.Add(this.btnLimpiarVuelo);
            this.gbRegistroVuelo.Controls.Add(this.txtCodigoVuelo);
            this.gbRegistroVuelo.Controls.Add(this.btnEliminarVuelo);
            this.gbRegistroVuelo.Controls.Add(this.lblCodigoVuelo);
            this.gbRegistroVuelo.Controls.Add(this.lblDestino);
            this.gbRegistroVuelo.Controls.Add(this.cmbDestino);
            this.gbRegistroVuelo.Controls.Add(this.lblFechaSalida);
            this.gbRegistroVuelo.Controls.Add(this.dtpFechaSalida);
            this.gbRegistroVuelo.Controls.Add(this.lblHoraSalida);
            this.gbRegistroVuelo.Controls.Add(this.txtHora);
            this.gbRegistroVuelo.Controls.Add(this.lblDosPuntos);
            this.gbRegistroVuelo.Controls.Add(this.txtMinuto);
            this.gbRegistroVuelo.Controls.Add(this.btnGuardarVuelo);
            this.gbRegistroVuelo.Location = new System.Drawing.Point(152, 152);
            this.gbRegistroVuelo.Name = "gbRegistroVuelo";
            this.gbRegistroVuelo.Size = new System.Drawing.Size(313, 210);
            this.gbRegistroVuelo.TabIndex = 1;
            this.gbRegistroVuelo.TabStop = false;
            this.gbRegistroVuelo.Text = "Registro de Vuelo";
            // 
            // btnLimpiarVuelo
            // 
            this.btnLimpiarVuelo.Location = new System.Drawing.Point(157, 165);
            this.btnLimpiarVuelo.Name = "btnLimpiarVuelo";
            this.btnLimpiarVuelo.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarVuelo.TabIndex = 18;
            this.btnLimpiarVuelo.Text = "LIMPIAR";
            this.btnLimpiarVuelo.UseVisualStyleBackColor = true;
            this.btnLimpiarVuelo.Click += new System.EventHandler(this.btnLimpiarVuelo_Click);
            // 
            // txtCodigoVuelo
            // 
            this.txtCodigoVuelo.Location = new System.Drawing.Point(110, 25);
            this.txtCodigoVuelo.Name = "txtCodigoVuelo";
            this.txtCodigoVuelo.Size = new System.Drawing.Size(150, 20);
            this.txtCodigoVuelo.TabIndex = 15;
            this.txtCodigoVuelo.Text = "DMK-";
            this.txtCodigoVuelo.TextChanged += new System.EventHandler(this.txtCodigoVuelo_TextChanged);
            // 
            // btnEliminarVuelo
            // 
            this.btnEliminarVuelo.BackColor = System.Drawing.Color.White;
            this.btnEliminarVuelo.BackgroundImage = global::SistemaGestionAerolinea.Properties.Resources.bote_de_basura;
            this.btnEliminarVuelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarVuelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarVuelo.Location = new System.Drawing.Point(270, 15);
            this.btnEliminarVuelo.Name = "btnEliminarVuelo";
            this.btnEliminarVuelo.Size = new System.Drawing.Size(30, 31);
            this.btnEliminarVuelo.TabIndex = 11;
            this.btnEliminarVuelo.UseVisualStyleBackColor = false;
            this.btnEliminarVuelo.Click += new System.EventHandler(this.btnEliminarVuelo_Click);
            // 
            // lblCodigoVuelo
            // 
            this.lblCodigoVuelo.AutoSize = true;
            this.lblCodigoVuelo.Location = new System.Drawing.Point(7, 28);
            this.lblCodigoVuelo.Name = "lblCodigoVuelo";
            this.lblCodigoVuelo.Size = new System.Drawing.Size(92, 13);
            this.lblCodigoVuelo.TabIndex = 19;
            this.lblCodigoVuelo.Text = "Número de Vuelo:";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(7, 61);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(46, 13);
            this.lblDestino.TabIndex = 2;
            this.lblDestino.Text = "Destino:";
            // 
            // cmbDestino
            // 
            this.cmbDestino.FormattingEnabled = true;
            this.cmbDestino.Location = new System.Drawing.Point(110, 58);
            this.cmbDestino.Name = "cmbDestino";
            this.cmbDestino.Size = new System.Drawing.Size(150, 21);
            this.cmbDestino.TabIndex = 14;
            // 
            // lblFechaSalida
            // 
            this.lblFechaSalida.AutoSize = true;
            this.lblFechaSalida.Location = new System.Drawing.Point(7, 94);
            this.lblFechaSalida.Name = "lblFechaSalida";
            this.lblFechaSalida.Size = new System.Drawing.Size(72, 13);
            this.lblFechaSalida.TabIndex = 20;
            this.lblFechaSalida.Text = "Fecha Salida:";
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaSalida.Location = new System.Drawing.Point(110, 91);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(150, 20);
            this.dtpFechaSalida.TabIndex = 12;
            // 
            // lblHoraSalida
            // 
            this.lblHoraSalida.AutoSize = true;
            this.lblHoraSalida.Location = new System.Drawing.Point(7, 124);
            this.lblHoraSalida.Name = "lblHoraSalida";
            this.lblHoraSalida.Size = new System.Drawing.Size(65, 13);
            this.lblHoraSalida.TabIndex = 21;
            this.lblHoraSalida.Text = "Hora Salida:";
            // 
            // txtHora
            // 
            this.txtHora.Location = new System.Drawing.Point(110, 121);
            this.txtHora.MaxLength = 2;
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(30, 20);
            this.txtHora.TabIndex = 20;
            this.txtHora.Text = "12";
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDosPuntos
            // 
            this.lblDosPuntos.AutoSize = true;
            this.lblDosPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDosPuntos.Location = new System.Drawing.Point(144, 124);
            this.lblDosPuntos.Name = "lblDosPuntos";
            this.lblDosPuntos.Size = new System.Drawing.Size(11, 13);
            this.lblDosPuntos.TabIndex = 22;
            this.lblDosPuntos.Text = ":";
            // 
            // txtMinuto
            // 
            this.txtMinuto.Location = new System.Drawing.Point(159, 121);
            this.txtMinuto.MaxLength = 2;
            this.txtMinuto.Name = "txtMinuto";
            this.txtMinuto.Size = new System.Drawing.Size(30, 20);
            this.txtMinuto.TabIndex = 21;
            this.txtMinuto.Text = "00";
            this.txtMinuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGuardarVuelo
            // 
            this.btnGuardarVuelo.Location = new System.Drawing.Point(76, 165);
            this.btnGuardarVuelo.Name = "btnGuardarVuelo";
            this.btnGuardarVuelo.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarVuelo.TabIndex = 10;
            this.btnGuardarVuelo.Text = "GUARDAR";
            this.btnGuardarVuelo.UseVisualStyleBackColor = true;
            this.btnGuardarVuelo.Click += new System.EventHandler(this.btnGuardarVuelo_Click);
            // 
            // lblTituloGestionVuelo
            // 
            this.lblTituloGestionVuelo.AutoSize = true;
            this.lblTituloGestionVuelo.Location = new System.Drawing.Point(240, 34);
            this.lblTituloGestionVuelo.Name = "lblTituloGestionVuelo";
            this.lblTituloGestionVuelo.Size = new System.Drawing.Size(119, 13);
            this.lblTituloGestionVuelo.TabIndex = 2;
            this.lblTituloGestionVuelo.Text = "GESTIÓN DE VUELOS";
            // 
            // lblSeleccionarVuelo
            // 
            this.lblSeleccionarVuelo.AutoSize = true;
            this.lblSeleccionarVuelo.Location = new System.Drawing.Point(220, 69);
            this.lblSeleccionarVuelo.Name = "lblSeleccionarVuelo";
            this.lblSeleccionarVuelo.Size = new System.Drawing.Size(157, 13);
            this.lblSeleccionarVuelo.TabIndex = 3;
            this.lblSeleccionarVuelo.Text = "Seleccione un vuelo para editar";
            // 
            // UC_Vuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSeleccionarVuelo);
            this.Controls.Add(this.lblTituloGestionVuelo);
            this.Controls.Add(this.gbRegistroVuelo);
            this.Controls.Add(this.cmbBuscarVuelo);
            this.Name = "UC_Vuelos";
            this.Size = new System.Drawing.Size(635, 447);
            this.gbRegistroVuelo.ResumeLayout(false);
            this.gbRegistroVuelo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbBuscarVuelo;
        private System.Windows.Forms.GroupBox gbRegistroVuelo;
        private System.Windows.Forms.Label lblCodigoVuelo;
        private System.Windows.Forms.Label lblFechaSalida;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Button btnEliminarVuelo;
        private System.Windows.Forms.Button btnGuardarVuelo;
        private System.Windows.Forms.Label lblTituloGestionVuelo;
        private System.Windows.Forms.Label lblSeleccionarVuelo;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.TextBox txtCodigoVuelo;
        private System.Windows.Forms.Button btnLimpiarVuelo;
        private System.Windows.Forms.Label lblHoraSalida;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblDosPuntos;
        private System.Windows.Forms.TextBox txtMinuto;
    }
}