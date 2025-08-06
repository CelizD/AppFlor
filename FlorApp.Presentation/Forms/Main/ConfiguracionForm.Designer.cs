namespace FlorApp.Presentation.Forms.Main
{
    partial class ConfiguracionForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.tabControlConfig = new System.Windows.Forms.TabControl();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.pnlDetallesUsuario = new System.Windows.Forms.Panel();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnGuardarUsuario = new System.Windows.Forms.Button();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEmpresa = new System.Windows.Forms.TabPage();
            this.btnGuardarEmpresa = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnCargarLogo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefonoEmpresa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDireccionEmpresa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tabControlConfig.SuspendLayout();
            this.tabUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.pnlDetallesUsuario.SuspendLayout();
            this.tabEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(884, 60);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(12, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(298, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Configuración del Sistema";
            // 
            // tabControlConfig
            // 
            this.tabControlConfig.Controls.Add(this.tabUsuarios);
            this.tabControlConfig.Controls.Add(this.tabEmpresa);
            this.tabControlConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlConfig.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControlConfig.Location = new System.Drawing.Point(0, 60);
            this.tabControlConfig.Name = "tabControlConfig";
            this.tabControlConfig.SelectedIndex = 0;
            this.tabControlConfig.Size = new System.Drawing.Size(884, 501);
            this.tabControlConfig.TabIndex = 4;
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Controls.Add(this.dgvUsuarios);
            this.tabUsuarios.Controls.Add(this.pnlDetallesUsuario);
            this.tabUsuarios.Location = new System.Drawing.Point(4, 26);
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuarios.Size = new System.Drawing.Size(876, 471);
            this.tabUsuarios.TabIndex = 0;
            this.tabUsuarios.Text = "Gestión de Usuarios";
            this.tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(303, 3);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(570, 465);
            this.dgvUsuarios.TabIndex = 1;
            // 
            // pnlDetallesUsuario
            // 
            this.pnlDetallesUsuario.Controls.Add(this.btnEliminarUsuario);
            this.pnlDetallesUsuario.Controls.Add(this.btnGuardarUsuario);
            this.pnlDetallesUsuario.Controls.Add(this.cmbRol);
            this.pnlDetallesUsuario.Controls.Add(this.label3);
            this.pnlDetallesUsuario.Controls.Add(this.txtContrasena);
            this.pnlDetallesUsuario.Controls.Add(this.label2);
            this.pnlDetallesUsuario.Controls.Add(this.txtNombreUsuario);
            this.pnlDetallesUsuario.Controls.Add(this.label1);
            this.pnlDetallesUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDetallesUsuario.Location = new System.Drawing.Point(3, 3);
            this.pnlDetallesUsuario.Name = "pnlDetallesUsuario";
            this.pnlDetallesUsuario.Size = new System.Drawing.Size(300, 465);
            this.pnlDetallesUsuario.TabIndex = 0;
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnEliminarUsuario.FlatAppearance.BorderSize = 0;
            this.btnEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnEliminarUsuario.Location = new System.Drawing.Point(150, 250);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(120, 40);
            this.btnEliminarUsuario.TabIndex = 7;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnGuardarUsuario
            // 
            this.btnGuardarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardarUsuario.FlatAppearance.BorderSize = 0;
            this.btnGuardarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnGuardarUsuario.Location = new System.Drawing.Point(20, 250);
            this.btnGuardarUsuario.Name = "btnGuardarUsuario";
            this.btnGuardarUsuario.Size = new System.Drawing.Size(120, 40);
            this.btnGuardarUsuario.TabIndex = 6;
            this.btnGuardarUsuario.Text = "Guardar";
            this.btnGuardarUsuario.UseVisualStyleBackColor = false;
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(20, 180);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(250, 29);
            this.cmbRol.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rol:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContrasena.Location = new System.Drawing.Point(20, 110);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(250, 29);
            this.txtContrasena.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNombreUsuario.Location = new System.Drawing.Point(20, 40);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(250, 29);
            this.txtNombreUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario:";
            // 
            // tabEmpresa
            // 
            this.tabEmpresa.Controls.Add(this.btnGuardarEmpresa);
            this.tabEmpresa.Controls.Add(this.picLogo);
            this.tabEmpresa.Controls.Add(this.btnCargarLogo);
            this.tabEmpresa.Controls.Add(this.label7);
            this.tabEmpresa.Controls.Add(this.txtTelefonoEmpresa);
            this.tabEmpresa.Controls.Add(this.label6);
            this.tabEmpresa.Controls.Add(this.txtDireccionEmpresa);
            this.tabEmpresa.Controls.Add(this.label5);
            this.tabEmpresa.Controls.Add(this.txtNombreEmpresa);
            this.tabEmpresa.Controls.Add(this.label4);
            this.tabEmpresa.Location = new System.Drawing.Point(4, 26);
            this.tabEmpresa.Name = "tabEmpresa";
            this.tabEmpresa.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmpresa.Size = new System.Drawing.Size(876, 471);
            this.tabEmpresa.TabIndex = 1;
            this.tabEmpresa.Text = "Datos de la Empresa";
            this.tabEmpresa.UseVisualStyleBackColor = true;
            // 
            // btnGuardarEmpresa
            // 
            this.btnGuardarEmpresa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardarEmpresa.FlatAppearance.BorderSize = 0;
            this.btnGuardarEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEmpresa.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEmpresa.Location = new System.Drawing.Point(30, 400);
            this.btnGuardarEmpresa.Name = "btnGuardarEmpresa";
            this.btnGuardarEmpresa.Size = new System.Drawing.Size(200, 45);
            this.btnGuardarEmpresa.TabIndex = 9;
            this.btnGuardarEmpresa.Text = "Guardar Cambios";
            this.btnGuardarEmpresa.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Gainsboro;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(30, 280);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            // 
            // btnCargarLogo
            // 
            this.btnCargarLogo.Location = new System.Drawing.Point(140, 280);
            this.btnCargarLogo.Name = "btnCargarLogo";
            this.btnCargarLogo.Size = new System.Drawing.Size(120, 30);
            this.btnCargarLogo.TabIndex = 7;
            this.btnCargarLogo.Text = "Cargar Logo...";
            this.btnCargarLogo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Logo:";
            // 
            // txtTelefonoEmpresa
            // 
            this.txtTelefonoEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelefonoEmpresa.Location = new System.Drawing.Point(30, 210);
            this.txtTelefonoEmpresa.Name = "txtTelefonoEmpresa";
            this.txtTelefonoEmpresa.Size = new System.Drawing.Size(350, 29);
            this.txtTelefonoEmpresa.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Teléfono:";
            // 
            // txtDireccionEmpresa
            // 
            this.txtDireccionEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDireccionEmpresa.Location = new System.Drawing.Point(30, 110);
            this.txtDireccionEmpresa.Multiline = true;
            this.txtDireccionEmpresa.Name = "txtDireccionEmpresa";
            this.txtDireccionEmpresa.Size = new System.Drawing.Size(350, 60);
            this.txtDireccionEmpresa.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Dirección:";
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNombreEmpresa.Location = new System.Drawing.Point(30, 40);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(350, 29);
            this.txtNombreEmpresa.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nombre de la Empresa:";
            // 
            // ConfiguracionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabControlConfig);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ConfiguracionForm";
            this.Text = "Configuración";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabControlConfig.ResumeLayout(false);
            this.tabUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.pnlDetallesUsuario.ResumeLayout(false);
            this.pnlDetallesUsuario.PerformLayout();
            this.tabEmpresa.ResumeLayout(false);
            this.tabEmpresa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TabControl tabControlConfig;
        private System.Windows.Forms.TabPage tabUsuarios;
        private System.Windows.Forms.TabPage tabEmpresa;
        private System.Windows.Forms.Panel pnlDetallesUsuario;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnGuardarUsuario;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.TextBox txtDireccionEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefonoEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnCargarLogo;
        private System.Windows.Forms.Button btnGuardarEmpresa;
    }
}
