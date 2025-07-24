namespace FlorApp.Presentation
{
    partial class CobrarForm
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
            this.lblTotalPagarTitulo = new System.Windows.Forms.Label();
            this.lblTotalPagarValor = new System.Windows.Forms.Label();
            this.lblEfectivoRecibidoTitulo = new System.Windows.Forms.Label();
            this.numEfectivoRecibido = new System.Windows.Forms.NumericUpDown();
            this.lblCambioTitulo = new System.Windows.Forms.Label();
            this.lblCambioValor = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTransferencia = new System.Windows.Forms.RadioButton();
            this.rbTarjeta = new System.Windows.Forms.RadioButton();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numEfectivoRecibido)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalPagarTitulo
            // 
            this.lblTotalPagarTitulo.AutoSize = true;
            this.lblTotalPagarTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagarTitulo.Location = new System.Drawing.Point(30, 30);
            this.lblTotalPagarTitulo.Name = "lblTotalPagarTitulo";
            this.lblTotalPagarTitulo.Size = new System.Drawing.Size(133, 25);
            this.lblTotalPagarTitulo.TabIndex = 0;
            this.lblTotalPagarTitulo.Text = "Total a Pagar:";
            // 
            // lblTotalPagarValor
            // 
            this.lblTotalPagarValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagarValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalPagarValor.Location = new System.Drawing.Point(170, 30);
            this.lblTotalPagarValor.Name = "lblTotalPagarValor";
            this.lblTotalPagarValor.Size = new System.Drawing.Size(150, 25);
            this.lblTotalPagarValor.TabIndex = 1;
            this.lblTotalPagarValor.Text = "$0.00";
            this.lblTotalPagarValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEfectivoRecibidoTitulo
            // 
            this.lblEfectivoRecibidoTitulo.AutoSize = true;
            this.lblEfectivoRecibidoTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEfectivoRecibidoTitulo.Location = new System.Drawing.Point(30, 200);
            this.lblEfectivoRecibidoTitulo.Name = "lblEfectivoRecibidoTitulo";
            this.lblEfectivoRecibidoTitulo.Size = new System.Drawing.Size(142, 21);
            this.lblEfectivoRecibidoTitulo.TabIndex = 2;
            this.lblEfectivoRecibidoTitulo.Text = "Efectivo Recibido:";
            // 
            // numEfectivoRecibido
            // 
            this.numEfectivoRecibido.DecimalPlaces = 2;
            this.numEfectivoRecibido.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numEfectivoRecibido.Location = new System.Drawing.Point(175, 198);
            this.numEfectivoRecibido.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numEfectivoRecibido.Name = "numEfectivoRecibido";
            this.numEfectivoRecibido.Size = new System.Drawing.Size(145, 29);
            this.numEfectivoRecibido.TabIndex = 3;
            this.numEfectivoRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCambioTitulo
            // 
            this.lblCambioTitulo.AutoSize = true;
            this.lblCambioTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCambioTitulo.Location = new System.Drawing.Point(30, 250);
            this.lblCambioTitulo.Name = "lblCambioTitulo";
            this.lblCambioTitulo.Size = new System.Drawing.Size(85, 25);
            this.lblCambioTitulo.TabIndex = 4;
            this.lblCambioTitulo.Text = "Cambio:";
            // 
            // lblCambioValor
            // 
            this.lblCambioValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCambioValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblCambioValor.Location = new System.Drawing.Point(170, 250);
            this.lblCambioValor.Name = "lblCambioValor";
            this.lblCambioValor.Size = new System.Drawing.Size(150, 25);
            this.lblCambioValor.TabIndex = 5;
            this.lblCambioValor.Text = "$0.00";
            this.lblCambioValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(34, 310);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(130, 40);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(190, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 40);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTransferencia);
            this.groupBox1.Controls.Add(this.rbTarjeta);
            this.groupBox1.Controls.Add(this.rbEfectivo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(34, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método de Pago";
            // 
            // rbTransferencia
            // 
            this.rbTransferencia.AutoSize = true;
            this.rbTransferencia.Location = new System.Drawing.Point(15, 70);
            this.rbTransferencia.Name = "rbTransferencia";
            this.rbTransferencia.Size = new System.Drawing.Size(109, 21);
            this.rbTransferencia.TabIndex = 2;
            this.rbTransferencia.Text = "Transferencia";
            this.rbTransferencia.UseVisualStyleBackColor = true;
            // 
            // rbTarjeta
            // 
            this.rbTarjeta.AutoSize = true;
            this.rbTarjeta.Location = new System.Drawing.Point(15, 45);
            this.rbTarjeta.Name = "rbTarjeta";
            this.rbTarjeta.Size = new System.Drawing.Size(155, 21);
            this.rbTarjeta.TabIndex = 1;
            this.rbTarjeta.Text = "Tarjeta Crédito/Débito";
            this.rbTarjeta.UseVisualStyleBackColor = true;
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Checked = true;
            this.rbEfectivo.Location = new System.Drawing.Point(15, 20);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(74, 21);
            this.rbEfectivo.TabIndex = 0;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "Efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // CobrarForm
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(354, 381);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCambioValor);
            this.Controls.Add(this.lblCambioTitulo);
            this.Controls.Add(this.numEfectivoRecibido);
            this.Controls.Add(this.lblEfectivoRecibidoTitulo);
            this.Controls.Add(this.lblTotalPagarValor);
            this.Controls.Add(this.lblTotalPagarTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CobrarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cobrar Venta";
            ((System.ComponentModel.ISupportInitialize)(this.numEfectivoRecibido)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTotalPagarTitulo;
        private System.Windows.Forms.Label lblTotalPagarValor;
        private System.Windows.Forms.Label lblEfectivoRecibidoTitulo;
        private System.Windows.Forms.NumericUpDown numEfectivoRecibido;
        private System.Windows.Forms.Label lblCambioTitulo;
        private System.Windows.Forms.Label lblCambioValor;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTransferencia;
        private System.Windows.Forms.RadioButton rbTarjeta;
        private System.Windows.Forms.RadioButton rbEfectivo;
    }
}
