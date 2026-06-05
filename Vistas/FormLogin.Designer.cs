namespace SistemaGestionAerolinea.Vistas
{
    partial class FrmLogin
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
            this.lblTituloSistema = new System.Windows.Forms.Label();
            this.gbAcceso = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.chkVerClave = new System.Windows.Forms.CheckBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gbAcceso.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloSistema
            // 
            this.lblTituloSistema.AutoSize = true;
            this.lblTituloSistema.Location = new System.Drawing.Point(153, 56);
            this.lblTituloSistema.Name = "lblTituloSistema";
            this.lblTituloSistema.Size = new System.Drawing.Size(263, 13);
            this.lblTituloSistema.TabIndex = 0;
            this.lblTituloSistema.Text = "AEROLÍNEA DOMESTIK - GESTIÓN DE RESERVAS";
            // 
            // gbAcceso
            // 
            this.gbAcceso.Controls.Add(this.lblUsuario);
            this.gbAcceso.Controls.Add(this.txtUsuario);
            this.gbAcceso.Controls.Add(this.lblContrasena);
            this.gbAcceso.Controls.Add(this.txtClave);
            this.gbAcceso.Controls.Add(this.chkVerClave);
            this.gbAcceso.Controls.Add(this.lblClave);
            this.gbAcceso.Controls.Add(this.btnLogin);
            this.gbAcceso.Location = new System.Drawing.Point(183, 114);
            this.gbAcceso.Name = "gbAcceso";
            this.gbAcceso.Size = new System.Drawing.Size(234, 160);
            this.gbAcceso.TabIndex = 1;
            this.gbAcceso.TabStop = false;
            this.gbAcceso.Text = "Validación de Credenciales";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(7, 29);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(77, 26);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(10, 56);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(61, 13);
            this.lblContrasena.TabIndex = 1;
            this.lblContrasena.Text = "Contraseña";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(77, 56);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(100, 20);
            this.txtClave.TabIndex = 3;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // chkVerClave
            // 
            this.chkVerClave.AutoSize = true;
            this.chkVerClave.Location = new System.Drawing.Point(13, 83);
            this.chkVerClave.Name = "chkVerClave";
            this.chkVerClave.Size = new System.Drawing.Size(15, 14);
            this.chkVerClave.TabIndex = 5;
            this.chkVerClave.UseVisualStyleBackColor = true;
            this.chkVerClave.CheckedChanged += new System.EventHandler(this.chkVerClave_CheckedChanged);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(34, 84);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(96, 13);
            this.lblClave.TabIndex = 6;
            this.lblClave.Text = "Mostar Contraseña";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(77, 122);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTituloSistema);
            this.Controls.Add(this.gbAcceso);
            this.Name = "FrmLogin";
            this.Text = "Acceso al Sistema - Aerolínea Domestik";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.gbAcceso.ResumeLayout(false);
            this.gbAcceso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloSistema;
        private System.Windows.Forms.GroupBox gbAcceso;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkVerClave;
        private System.Windows.Forms.Label lblClave;
    }
}