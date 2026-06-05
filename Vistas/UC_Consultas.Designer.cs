namespace SistemaGestionAerolinea.Vistas
{
    partial class UC_Consultas
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
            this.tpPrincipal = new System.Windows.Forms.TabControl();
            this.tpPasajero = new System.Windows.Forms.TabPage();
            this.lblSeleccionarPasajero = new System.Windows.Forms.Label();
            this.cmbConsultaPasajero = new System.Windows.Forms.ComboBox();
            this.dgvDatosPasajero = new System.Windows.Forms.DataGridView();
            this.tpVuelo = new System.Windows.Forms.TabPage();
            this.lblSeleccionarVuelo = new System.Windows.Forms.Label();
            this.cmbConsultaVuelo = new System.Windows.Forms.ComboBox();
            this.dgvDatosVuelo = new System.Windows.Forms.DataGridView();
            this.tpPrincipal.SuspendLayout();
            this.tpPasajero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPasajero)).BeginInit();
            this.tpVuelo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosVuelo)).BeginInit();
            this.SuspendLayout();
            // 
            // tpPrincipal
            // 
            this.tpPrincipal.Controls.Add(this.tpPasajero);
            this.tpPrincipal.Controls.Add(this.tpVuelo);
            this.tpPrincipal.Location = new System.Drawing.Point(20, 20);
            this.tpPrincipal.Name = "tpPrincipal";
            this.tpPrincipal.SelectedIndex = 0;
            this.tpPrincipal.Size = new System.Drawing.Size(800, 480);
            this.tpPrincipal.TabIndex = 0;
            // 
            // tpPasajero
            // 
            this.tpPasajero.Controls.Add(this.lblSeleccionarPasajero);
            this.tpPasajero.Controls.Add(this.cmbConsultaPasajero);
            this.tpPasajero.Controls.Add(this.dgvDatosPasajero);
            this.tpPasajero.Location = new System.Drawing.Point(4, 22);
            this.tpPasajero.Name = "tpPasajero";
            this.tpPasajero.Padding = new System.Windows.Forms.Padding(3);
            this.tpPasajero.Size = new System.Drawing.Size(792, 454);
            this.tpPasajero.TabIndex = 0;
            this.tpPasajero.Text = "Por Pasajero";
            this.tpPasajero.UseVisualStyleBackColor = true;
            // 
            // lblSeleccionarPasajero
            // 
            this.lblSeleccionarPasajero.AutoSize = true;
            this.lblSeleccionarPasajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSeleccionarPasajero.Location = new System.Drawing.Point(30, 25);
            this.lblSeleccionarPasajero.Name = "lblSeleccionarPasajero";
            this.lblSeleccionarPasajero.Size = new System.Drawing.Size(140, 15);
            this.lblSeleccionarPasajero.TabIndex = 0;
            this.lblSeleccionarPasajero.Text = "Seleccione un Pasajero:";
            // 
            // cmbConsultaPasajero
            // 
            this.cmbConsultaPasajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsultaPasajero.FormattingEnabled = true;
            this.cmbConsultaPasajero.Location = new System.Drawing.Point(200, 22);
            this.cmbConsultaPasajero.Name = "cmbConsultaPasajero";
            this.cmbConsultaPasajero.Size = new System.Drawing.Size(300, 21);
            this.cmbConsultaPasajero.TabIndex = 1;
            // 
            // dgvDatosPasajero
            // 
            this.dgvDatosPasajero.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatosPasajero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosPasajero.Location = new System.Drawing.Point(30, 65);
            this.dgvDatosPasajero.Name = "dgvDatosPasajero";
            this.dgvDatosPasajero.Size = new System.Drawing.Size(730, 360);
            this.dgvDatosPasajero.TabIndex = 2;
            // 
            // tpVuelo
            // 
            this.tpVuelo.Controls.Add(this.lblSeleccionarVuelo);
            this.tpVuelo.Controls.Add(this.cmbConsultaVuelo);
            this.tpVuelo.Controls.Add(this.dgvDatosVuelo);
            this.tpVuelo.Location = new System.Drawing.Point(4, 22);
            this.tpVuelo.Name = "tpVuelo";
            this.tpVuelo.Padding = new System.Windows.Forms.Padding(3);
            this.tpVuelo.Size = new System.Drawing.Size(792, 454);
            this.tpVuelo.TabIndex = 1;
            this.tpVuelo.Text = "Por Vuelo";
            this.tpVuelo.UseVisualStyleBackColor = true;
            // 
            // lblSeleccionarVuelo
            // 
            this.lblSeleccionarVuelo.AutoSize = true;
            this.lblSeleccionarVuelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSeleccionarVuelo.Location = new System.Drawing.Point(30, 25);
            this.lblSeleccionarVuelo.Name = "lblSeleccionarVuelo";
            this.lblSeleccionarVuelo.Size = new System.Drawing.Size(122, 15);
            this.lblSeleccionarVuelo.TabIndex = 0;
            this.lblSeleccionarVuelo.Text = "Seleccione un Vuelo:";
            // 
            // cmbConsultaVuelo
            // 
            this.cmbConsultaVuelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsultaVuelo.FormattingEnabled = true;
            this.cmbConsultaVuelo.Location = new System.Drawing.Point(200, 22);
            this.cmbConsultaVuelo.Name = "cmbConsultaVuelo";
            this.cmbConsultaVuelo.Size = new System.Drawing.Size(200, 21);
            this.cmbConsultaVuelo.TabIndex = 1;
            // 
            // dgvDatosVuelo
            // 
            this.dgvDatosVuelo.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatosVuelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosVuelo.Location = new System.Drawing.Point(30, 65);
            this.dgvDatosVuelo.Name = "dgvDatosVuelo";
            this.dgvDatosVuelo.Size = new System.Drawing.Size(730, 360);
            this.dgvDatosVuelo.TabIndex = 2;
            // 
            // UC_Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tpPrincipal);
            this.Name = "UC_Consultas";
            this.Size = new System.Drawing.Size(840, 520);
            this.tpPrincipal.ResumeLayout(false);
            this.tpPasajero.ResumeLayout(false);
            this.tpPasajero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPasajero)).EndInit();
            this.tpVuelo.ResumeLayout(false);
            this.tpVuelo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosVuelo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tpPrincipal;
        private System.Windows.Forms.TabPage tpPasajero;
        private System.Windows.Forms.TabPage tpVuelo;
        private System.Windows.Forms.Label lblSeleccionarPasajero;
        private System.Windows.Forms.ComboBox cmbConsultaPasajero;
        private System.Windows.Forms.DataGridView dgvDatosPasajero;
        private System.Windows.Forms.Label lblSeleccionarVuelo;
        private System.Windows.Forms.ComboBox cmbConsultaVuelo;
        private System.Windows.Forms.DataGridView dgvDatosVuelo;
    }
}