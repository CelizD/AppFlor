namespace FlorApp.Presentation
{
    partial class CobrarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalPagarValor = new System.Windows.Forms.Label();
            this.lblTotalPagarTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCambioValor = new System.Windows.Forms.Label();
            this.lblCambioTitulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTransferencia = new System.Windows.Forms.RadioButton();
            this.rbTarjeta = new System.Windows.Forms.RadioButton();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.numEfectivoRecibido = new System.Windows.Forms.NumericUpDown();
            this.btnExacto = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.btn200 = new System.Windows.Forms.Button();
            this.btn500 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEfectivoRecibido)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(484, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cobrar Venta";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblTotalPagarValor);
            this.panel1.Controls.Add(this.lblTotalPagarTitulo);
            this.panel1.Location = new System.Drawing.Point(20, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 100);
            this.panel1.TabIndex = 1;
            // 
            // lblTotalPagarValor
            // 
            this.lblTotalPagarValor.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagarValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalPagarValor.Location = new System.Drawing.Point(3, 40);
            this.lblTotalPagarValor.Name = "lblTotalPagarValor";
            this.lblTotalPagarValor.Size = new System.Drawing.Size(434, 50);
            this.lblTotalPagarValor.TabIndex = 1;
            this.lblTotalPagarValor.Text = "$0.00";
            this.lblTotalPagarValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalPagarTitulo
            // 
            this.lblTotalPagarTitulo.AutoSize = true;
            this.lblTotalPagarTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagarTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalPagarTitulo.Location = new System.Drawing.Point(160, 10);
            this.lblTotalPagarTitulo.Name = "lblTotalPagarTitulo";
            this.lblTotalPagarTitulo.Size = new System.Drawing.Size(112, 21);
            this.lblTotalPagarTitulo.TabIndex = 0;
            this.lblTotalPagarTitulo.Text = "Total a Pagar:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lblCambioValor);
            this.panel2.Controls.Add(this.lblCambioTitulo);
            this.panel2.Location = new System.Drawing.Point(20, 480);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 100);
            this.panel2.TabIndex = 2;
            // 
            // lblCambioValor
            // 
            this.lblCambioValor.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblCambioValor.Location = new System.Drawing.Point(3, 40);
            this.lblCambioValor.Name = "lblCambioValor";
            this.lblCambioValor.Size = new System.Drawing.Size(434, 50);
            this.lblCambioValor.TabIndex = 1;
            this.lblCambioValor.Text = "$0.00";
            this.lblCambioValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCambioTitulo
            // 
            this.lblCambioTitulo.AutoSize = true;
            this.lblCambioTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblCambioTitulo.Location = new System.Drawing.Point(180, 10);
            this.lblCambioTitulo.Name = "lblCambioTitulo";
            this.lblCambioTitulo.Size = new System.Drawing.Size(71, 21);
            this.lblCambioTitulo.TabIndex = 0;
            this.lblCambioTitulo.Text = "Cambio:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTransferencia);
            this.groupBox1.Controls.Add(this.rbTarjeta);
            this.groupBox1.Controls.Add(this.rbEfectivo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método de Pago";
            // 
            // rbTransferencia
            // 
            this.rbTransferencia.AutoSize = true;
            this.rbTransferencia.Location = new System.Drawing.Point(280, 25);
            this.rbTransferencia.Name = "rbTransferencia";
            this.rbTransferencia.Size = new System.Drawing.Size(109, 21);
            this.rbTransferencia.TabIndex = 2;
            this.rbTransferencia.Text = "Transferencia";
            this.rbTransferencia.UseVisualStyleBackColor = true;
            // 
            // rbTarjeta
            // 
            this.rbTarjeta.AutoSize = true;
            this.rbTarjeta.Location = new System.Drawing.Point(150, 25);
            this.rbTarjeta.Name = "rbTarjeta";
            this.rbTarjeta.Size = new System.Drawing.Size(67, 21);
            this.rbTarjeta.TabIndex = 1;
            this.rbTarjeta.Text = "Tarjeta";
            this.rbTarjeta.UseVisualStyleBackColor = true;
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Checked = true;
            this.rbEfectivo.Location = new System.Drawing.Point(20, 25);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(74, 21);
            this.rbEfectivo.TabIndex = 0;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "Efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Efectivo Recibido:";
            // 
            // numEfectivoRecibido
            // 
            this.numEfectivoRecibido.DecimalPlaces = 2;
            this.numEfectivoRecibido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numEfectivoRecibido.Location = new System.Drawing.Point(20, 295);
            this.numEfectivoRecibido.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numEfectivoRecibido.Name = "numEfectivoRecibido";
            this.numEfectivoRecibido.Size = new System.Drawing.Size(440, 29);
            this.numEfectivoRecibido.TabIndex = 5;
            this.numEfectivoRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnExacto
            // 
            this.btnExacto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExacto.Location = new System.Drawing.Point(6, 24);
            this.btnExacto.Name = "btnExacto";
            this.btnExacto.Size = new System.Drawing.Size(100, 40);
            this.btnExacto.TabIndex = 6;
            this.btnExacto.Text = "Exacto";
            this.btnExacto.UseVisualStyleBackColor = true;
            // 
            // btn100
            // 
            this.btn100.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn100.Location = new System.Drawing.Point(112, 24);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(100, 40);
            this.btn100.TabIndex = 7;
            this.btn100.Text = "$100";
            this.btn100.UseVisualStyleBackColor = true;
            // 
            // btn200
            // 
            this.btn200.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn200.Location = new System.Drawing.Point(218, 24);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(100, 40);
            this.btn200.TabIndex = 8;
            this.btn200.Text = "$200";
            this.btn200.UseVisualStyleBackColor = true;
            // 
            // btn500
            // 
            this.btn500.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn500.Location = new System.Drawing.Point(324, 24);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(100, 40);
            this.btn500.TabIndex = 9;
            this.btn500.Text = "$500";
            this.btn500.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(250, 600);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(210, 45);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(20, 600);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(210, 45);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExacto);
            this.groupBox2.Controls.Add(this.btn100);
            this.groupBox2.Controls.Add(this.btn200);
            this.groupBox2.Controls.Add(this.btn500);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(20, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 80);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pago Rápido";
            // 
            // CobrarForm
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.numEfectivoRecibido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CobrarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cobrar Venta";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEfectivoRecibido)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalPagarValor;
        private System.Windows.Forms.Label lblTotalPagarTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCambioValor;
        private System.Windows.Forms.Label lblCambioTitulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTransferencia;
        private System.Windows.Forms.RadioButton rbTarjeta;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numEfectivoRecibido;
        private System.Windows.Forms.Button btnExacto;
        private System.Windows.Forms.Button btn100;
        private System.Windows.Forms.Button btn200;
        private System.Windows.Forms.Button btn500;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
