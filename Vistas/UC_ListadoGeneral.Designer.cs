namespace SistemaGestionAerolinea.Vistas
{
    partial class UC_ListadoGeneral
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
            this.lblListadoGeneral = new System.Windows.Forms.Label();
            this.dgvListadoGeneral = new System.Windows.Forms.DataGridView();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // lblListadoGeneral
            // 
            this.lblListadoGeneral.AutoSize = true;
            this.lblListadoGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblListadoGeneral.Location = new System.Drawing.Point(232, 37);
            this.lblListadoGeneral.Name = "lblListadoGeneral";
            this.lblListadoGeneral.Size = new System.Drawing.Size(336, 17);
            this.lblListadoGeneral.TabIndex = 0;
            this.lblListadoGeneral.Text = "REGISTRO MAESTRO DE RESERVAS DE VUELOS";
            // 
            // dgvListadoGeneral
            // 
            this.dgvListadoGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListadoGeneral.BackgroundColor = System.Drawing.Color.White;
            this.dgvListadoGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoGeneral.Location = new System.Drawing.Point(45, 70);
            this.dgvListadoGeneral.Name = "dgvListadoGeneral";
            this.dgvListadoGeneral.Size = new System.Drawing.Size(710, 270);
            this.dgvListadoGeneral.TabIndex = 1;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(42, 355);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(249, 13);
            this.lblTotalRegistros.TabIndex = 2;
            this.lblTotalRegistros.Text = "Se han recuperado {N} registros del sistema central";
            // 
            // UC_ListadoGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.lblListadoGeneral);
            this.Controls.Add(this.dgvListadoGeneral);
            this.Name = "UC_ListadoGeneral";
            this.Size = new System.Drawing.Size(800, 400);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListadoGeneral;
        private System.Windows.Forms.DataGridView dgvListadoGeneral;
        private System.Windows.Forms.Label lblTotalRegistros;
    }
}