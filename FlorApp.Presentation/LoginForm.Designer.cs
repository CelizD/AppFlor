namespace FlorApp.Presentation
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.chkMostrarContrasena = new System.Windows.Forms.CheckBox();
            this.lblSalir = new System.Windows.Forms.Label();
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pnlContrasena = new System.Windows.Forms.Panel();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.pnlUsuario.SuspendLayout();
            this.pnlContrasena.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Window;
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.ForeColor = System.Drawing.Color.Black;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(533, 222);
            this.pnlHeader.TabIndex = 10;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 246);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(533, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "INICIAR SESIÓN";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIngresar
            // 
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(67, 517);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(400, 55);
            this.btnIngresar.TabIndex = 3;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(67, 474);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(400, 28);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Usuario o contraseña incorrectos.";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // chkMostrarContrasena
            // 
            this.chkMostrarContrasena.AutoSize = true;
            this.chkMostrarContrasena.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkMostrarContrasena.Location = new System.Drawing.Point(67, 431);
            this.chkMostrarContrasena.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMostrarContrasena.Name = "chkMostrarContrasena";
            this.chkMostrarContrasena.Size = new System.Drawing.Size(158, 24);
            this.chkMostrarContrasena.TabIndex = 2;
            this.chkMostrarContrasena.Text = "Mostrar contraseña";
            this.chkMostrarContrasena.UseVisualStyleBackColor = true;
            this.chkMostrarContrasena.CheckedChanged += new System.EventHandler(this.chkMostrarContrasena_CheckedChanged);
            // 
            // lblSalir
            // 
            this.lblSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSalir.Location = new System.Drawing.Point(0, 591);
            this.lblSalir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalir.Name = "lblSalir";
            this.lblSalir.Size = new System.Drawing.Size(533, 26);
            this.lblSalir.TabIndex = 4;
            this.lblSalir.Text = "SALIR";
            this.lblSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSalir.Click += new System.EventHandler(this.lblSalir_Click);
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.Controls.Add(this.txtUsuario);
            this.pnlUsuario.Location = new System.Drawing.Point(67, 308);
            this.pnlUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pnlUsuario.Size = new System.Drawing.Size(400, 49);
            this.pnlUsuario.TabIndex = 0;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(7, 6);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(386, 37);
            this.txtUsuario.TabIndex = 0;
            // 
            // pnlContrasena
            // 
            this.pnlContrasena.Controls.Add(this.txtContrasena);
            this.pnlContrasena.Location = new System.Drawing.Point(67, 369);
            this.pnlContrasena.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContrasena.Name = "pnlContrasena";
            this.pnlContrasena.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pnlContrasena.Size = new System.Drawing.Size(400, 49);
            this.pnlContrasena.TabIndex = 1;
            // 
            // txtContrasena
            // 
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContrasena.Location = new System.Drawing.Point(7, 6);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtContrasena.Multiline = true;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(386, 37);
            this.txtContrasena.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::FlorApp.Presentation.Properties.Resources.AppFlor;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(533, 222);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 640);
            this.Controls.Add(this.pnlContrasena);
            this.Controls.Add(this.pnlUsuario);
            this.Controls.Add(this.lblSalir);
            this.Controls.Add(this.chkMostrarContrasena);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.pnlHeader.ResumeLayout(false);
            this.pnlUsuario.ResumeLayout(false);
            this.pnlUsuario.PerformLayout();
            this.pnlContrasena.ResumeLayout(false);
            this.pnlContrasena.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox chkMostrarContrasena;
        private System.Windows.Forms.Label lblSalir;
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Panel pnlContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
    }
}
