namespace SistemaGestionAerolinea.Vistas
{
    partial class FrmPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método requerido para admitir el Diseñador. No modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.itemPasajeros = new System.Windows.Forms.ToolStripMenuItem();
            this.itemVuelos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReservas = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGenerarReserva = new System.Windows.Forms.ToolStripMenuItem();
            this.itemReservasExistentes = new System.Windows.Forms.ToolStripMenuItem();
            this.itemBusquedaAvanzada = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuGestion
            // 
            this.menuGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemPasajeros,
            this.itemVuelos});
            this.menuGestion.Name = "menuGestion";
            this.menuGestion.Size = new System.Drawing.Size(129, 20);
            this.menuGestion.Text = "GESTIÓN DE VUELOS";
            // 
            // itemPasajeros
            // 
            this.itemPasajeros.Name = "itemPasajeros";
            this.itemPasajeros.Size = new System.Drawing.Size(180, 22);
            this.itemPasajeros.Text = "PASAJEROS";
            this.itemPasajeros.Click += new System.EventHandler(this.itemPasajeros_Click);
            // 
            // itemVuelos
            // 
            this.itemVuelos.Name = "itemVuelos";
            this.itemVuelos.Size = new System.Drawing.Size(180, 22);
            this.itemVuelos.Text = "VUELOS";
            this.itemVuelos.Click += new System.EventHandler(this.itemVuelos_Click);
            // 
            // menuReservas
            // 
            this.menuReservas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemGenerarReserva,
            this.itemReservasExistentes,
            this.itemBusquedaAvanzada});
            this.menuReservas.Name = "menuReservas";
            this.menuReservas.Size = new System.Drawing.Size(71, 20);
            this.menuReservas.Text = "RESERVAS";
            // 
            // itemGenerarReserva
            // 
            this.itemGenerarReserva.Name = "itemGenerarReserva";
            this.itemGenerarReserva.Size = new System.Drawing.Size(215, 22);
            this.itemGenerarReserva.Text = "GENERAR RESERVA";
            this.itemGenerarReserva.Click += new System.EventHandler(this.itemGenerarReserva_Click);
            // 
            // itemReservasExistentes
            // 
            this.itemReservasExistentes.Name = "itemReservasExistentes";
            this.itemReservasExistentes.Size = new System.Drawing.Size(215, 22);
            this.itemReservasExistentes.Text = "VER RESERVAS EXISTENTES";
            this.itemReservasExistentes.Click += new System.EventHandler(this.itemVerReservas_Click);
            // 
            // itemBusquedaAvanzada
            // 
            this.itemBusquedaAvanzada.Name = "itemBusquedaAvanzada";
            this.itemBusquedaAvanzada.Size = new System.Drawing.Size(215, 22);
            this.itemBusquedaAvanzada.Text = "BÚSQUEDA AVANZADA";
            this.itemBusquedaAvanzada.Click += new System.EventHandler(this.itemConsultarHistorial_Click);
            // 
            // menuSistema
            // 
            this.menuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCerrarSesion});
            this.menuSistema.Name = "menuSistema";
            this.menuSistema.Size = new System.Drawing.Size(66, 20);
            this.menuSistema.Text = "SISTEMA";
            // 
            // itemCerrarSesion
            // 
            this.itemCerrarSesion.Name = "itemCerrarSesion";
            this.itemCerrarSesion.Size = new System.Drawing.Size(180, 22);
            this.itemCerrarSesion.Text = "CERRAR SESIÓN";
            this.itemCerrarSesion.Click += new System.EventHandler(this.itemCerrarSesion_Click);
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGestion,
            this.menuReservas,
            this.menuSistema});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(800, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 24);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(800, 426);
            this.pnlPrincipal.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmPrincipal";
            this.Text = "SISTEMA DE GESTIÓN INTEGRAL - AEROLÍNEA DOMESTIK";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menuGestion;
        private System.Windows.Forms.ToolStripMenuItem itemPasajeros;
        private System.Windows.Forms.ToolStripMenuItem itemVuelos;
        private System.Windows.Forms.ToolStripMenuItem menuReservas;
        private System.Windows.Forms.ToolStripMenuItem itemGenerarReserva;
        private System.Windows.Forms.ToolStripMenuItem itemReservasExistentes;
        private System.Windows.Forms.ToolStripMenuItem itemBusquedaAvanzada;
        private System.Windows.Forms.ToolStripMenuItem menuSistema;
        private System.Windows.Forms.ToolStripMenuItem itemCerrarSesion;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.Panel pnlPrincipal;
    }
}