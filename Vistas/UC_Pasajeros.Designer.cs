namespace SistemaGestionAerolinea.Vistas
{
    partial class UC_Pasajeros
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
            this.gbRegistroPasajero = new System.Windows.Forms.GroupBox();
            this.btnLimpiarPasajero = new System.Windows.Forms.Button();
            this.btnBuscarRut = new System.Windows.Forms.Button();
            this.btnEliminarPasajero = new System.Windows.Forms.Button();
            this.lblRut = new System.Windows.Forms.Label();
            this.txtRut = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblPuntaje = new System.Windows.Forms.Label();
            this.txtPuntaje = new System.Windows.Forms.TextBox();
            this.btnGuardarPasajero = new System.Windows.Forms.Button();
            this.lblTituloGestionPasajero = new System.Windows.Forms.Label();
            this.lblSeleccionarPasajero = new System.Windows.Forms.Label();
            this.cmbBuscarPasajero = new System.Windows.Forms.ComboBox();
            this.gbRegistroPasajero.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRegistroPasajero
            // 
            this.gbRegistroPasajero.Controls.Add(this.btnLimpiarPasajero);
            this.gbRegistroPasajero.Controls.Add(this.btnBuscarRut);
            this.gbRegistroPasajero.Controls.Add(this.btnEliminarPasajero);
            this.gbRegistroPasajero.Controls.Add(this.lblRut);
            this.gbRegistroPasajero.Controls.Add(this.txtRut);
            this.gbRegistroPasajero.Controls.Add(this.lblNombre);
            this.gbRegistroPasajero.Controls.Add(this.txtNombre);
            this.gbRegistroPasajero.Controls.Add(this.lblApellido);
            this.gbRegistroPasajero.Controls.Add(this.txtApellido);
            this.gbRegistroPasajero.Controls.Add(this.lblTipo);
            this.gbRegistroPasajero.Controls.Add(this.cmbTipo);
            this.gbRegistroPasajero.Controls.Add(this.lblPuntaje);
            this.gbRegistroPasajero.Controls.Add(this.txtPuntaje);
            this.gbRegistroPasajero.Controls.Add(this.btnGuardarPasajero);
            this.gbRegistroPasajero.Location = new System.Drawing.Point(134, 163);
            this.gbRegistroPasajero.Name = "gbRegistroPasajero";
            this.gbRegistroPasajero.Size = new System.Drawing.Size(317, 254);
            this.gbRegistroPasajero.TabIndex = 2;
            this.gbRegistroPasajero.TabStop = false;
            this.gbRegistroPasajero.Text = "Registro de Pasajero";
            // 
            // btnLimpiarPasajero
            // 
            this.btnLimpiarPasajero.Location = new System.Drawing.Point(132, 211);
            this.btnLimpiarPasajero.Name = "btnLimpiarPasajero";
            this.btnLimpiarPasajero.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarPasajero.TabIndex = 15;
            this.btnLimpiarPasajero.Text = "LIMPIAR";
            this.btnLimpiarPasajero.UseVisualStyleBackColor = true;
            this.btnLimpiarPasajero.Click += new System.EventHandler(this.btnLimpiarPasajero_Click);
            // 
            // btnBuscarRut
            // 
            this.btnBuscarRut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscarRut.BackgroundImage = global::SistemaGestionAerolinea.Properties.Resources.lupa;
            this.btnBuscarRut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarRut.Location = new System.Drawing.Point(212, 16);
            this.btnBuscarRut.Name = "btnBuscarRut";
            this.btnBuscarRut.Size = new System.Drawing.Size(25, 25);
            this.btnBuscarRut.TabIndex = 14;
            this.btnBuscarRut.UseVisualStyleBackColor = false;
            this.btnBuscarRut.Click += new System.EventHandler(this.btnBuscarRut_Click);
            // 
            // btnEliminarPasajero
            // 
            this.btnEliminarPasajero.BackColor = System.Drawing.Color.White;
            this.btnEliminarPasajero.BackgroundImage = global::SistemaGestionAerolinea.Properties.Resources.bote_de_basura;
            this.btnEliminarPasajero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminarPasajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPasajero.Location = new System.Drawing.Point(271, 211);
            this.btnEliminarPasajero.Name = "btnEliminarPasajero";
            this.btnEliminarPasajero.Size = new System.Drawing.Size(30, 31);
            this.btnEliminarPasajero.TabIndex = 11;
            this.btnEliminarPasajero.UseVisualStyleBackColor = false;
            this.btnEliminarPasajero.Click += new System.EventHandler(this.btnEliminarPasajero_Click);
            // 
            // lblRut
            // 
            this.lblRut.AutoSize = true;
            this.lblRut.Location = new System.Drawing.Point(7, 28);
            this.lblRut.Name = "lblRut";
            this.lblRut.Size = new System.Drawing.Size(33, 13);
            this.lblRut.TabIndex = 0;
            this.lblRut.Text = "RUT:";
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(85, 19);
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(121, 20);
            this.txtRut.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 51);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(85, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(10, 81);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(85, 73);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 20);
            this.txtApellido.TabIndex = 6;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(7, 110);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(75, 13);
            this.lblTipo.TabIndex = 12;
            this.lblTipo.Text = "Tipo Pasajero:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(85, 103);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(120, 21);
            this.cmbTipo.TabIndex = 13;
            // 
            // lblPuntaje
            // 
            this.lblPuntaje.AutoSize = true;
            this.lblPuntaje.Location = new System.Drawing.Point(6, 138);
            this.lblPuntaje.Name = "lblPuntaje";
            this.lblPuntaje.Size = new System.Drawing.Size(81, 13);
            this.lblPuntaje.TabIndex = 3;
            this.lblPuntaje.Text = "Puntaje (Millas):";
            // 
            // txtPuntaje
            // 
            this.txtPuntaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuntaje.Location = new System.Drawing.Point(85, 135);
            this.txtPuntaje.Name = "txtPuntaje";
            this.txtPuntaje.Size = new System.Drawing.Size(121, 21);
            this.txtPuntaje.TabIndex = 7;
            // 
            // btnGuardarPasajero
            // 
            this.btnGuardarPasajero.Location = new System.Drawing.Point(51, 211);
            this.btnGuardarPasajero.Name = "btnGuardarPasajero";
            this.btnGuardarPasajero.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPasajero.TabIndex = 10;
            this.btnGuardarPasajero.Text = "GUARDAR";
            this.btnGuardarPasajero.UseVisualStyleBackColor = true;
            this.btnGuardarPasajero.Click += new System.EventHandler(this.btnGuardarPasajero_Click);
            // 
            // lblTituloGestionPasajero
            // 
            this.lblTituloGestionPasajero.AutoSize = true;
            this.lblTituloGestionPasajero.Location = new System.Drawing.Point(193, 49);
            this.lblTituloGestionPasajero.Name = "lblTituloGestionPasajero";
            this.lblTituloGestionPasajero.Size = new System.Drawing.Size(139, 13);
            this.lblTituloGestionPasajero.TabIndex = 3;
            this.lblTituloGestionPasajero.Text = "GESTIÓN DE PASAJEROS";
            // 
            // lblSeleccionarPasajero
            // 
            this.lblSeleccionarPasajero.AutoSize = true;
            this.lblSeleccionarPasajero.Location = new System.Drawing.Point(182, 82);
            this.lblSeleccionarPasajero.Name = "lblSeleccionarPasajero";
            this.lblSeleccionarPasajero.Size = new System.Drawing.Size(171, 13);
            this.lblSeleccionarPasajero.TabIndex = 4;
            this.lblSeleccionarPasajero.Text = "Seleccione un pasajero para editar";
            // 
            // cmbBuscarPasajero
            // 
            this.cmbBuscarPasajero.FormattingEnabled = true;
            this.cmbBuscarPasajero.Location = new System.Drawing.Point(185, 114);
            this.cmbBuscarPasajero.Name = "cmbBuscarPasajero";
            this.cmbBuscarPasajero.Size = new System.Drawing.Size(170, 21);
            this.cmbBuscarPasajero.TabIndex = 5;
            this.cmbBuscarPasajero.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarPasajero_SelectedIndexChanged);
            // 
            // UC_Pasajeros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTituloGestionPasajero);
            this.Controls.Add(this.lblSeleccionarPasajero);
            this.Controls.Add(this.cmbBuscarPasajero);
            this.Controls.Add(this.gbRegistroPasajero);
            this.Name = "UC_Pasajeros";
            this.Size = new System.Drawing.Size(618, 439);
            this.gbRegistroPasajero.ResumeLayout(false);
            this.gbRegistroPasajero.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRegistroPasajero;
        private System.Windows.Forms.Button btnEliminarPasajero;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblPuntaje;
        private System.Windows.Forms.TextBox txtPuntaje;
        private System.Windows.Forms.Button btnGuardarPasajero;
        private System.Windows.Forms.Label lblTituloGestionPasajero;
        private System.Windows.Forms.Label lblSeleccionarPasajero;
        private System.Windows.Forms.ComboBox cmbBuscarPasajero;
        private System.Windows.Forms.Button btnBuscarRut;
        private System.Windows.Forms.Button btnLimpiarPasajero;
    }
}