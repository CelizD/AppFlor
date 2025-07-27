namespace FlorApp.Presentation
{
    partial class InventarioForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.tabControlInventario = new System.Windows.Forms.TabControl();
            this.tabEntradas = new System.Windows.Forms.TabPage();
            this.btnRegistrarEntrada = new System.Windows.Forms.Button();
            this.numCantidadEntrada = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProductoEntrada = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSalidas = new System.Windows.Forms.TabPage();
            this.txtMotivoSalida = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.numCantidadSalida = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProductoSalida = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabAjusteFisico = new System.Windows.Forms.TabPage();
            this.btnAplicarAjuste = new System.Windows.Forms.Button();
            this.dgvAjusteStock = new System.Windows.Forms.DataGridView();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.tabControlInventario.SuspendLayout();
            this.tabEntradas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadEntrada)).BeginInit();
            this.tabSalidas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadSalida)).BeginInit();
            this.tabAjusteFisico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAjusteStock)).BeginInit();
            this.tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(784, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(12, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(245, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Gestión de Inventario";
            // 
            // tabControlInventario
            // 
            this.tabControlInventario.Controls.Add(this.tabEntradas);
            this.tabControlInventario.Controls.Add(this.tabSalidas);
            this.tabControlInventario.Controls.Add(this.tabAjusteFisico);
            this.tabControlInventario.Controls.Add(this.tabHistorial);
            this.tabControlInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControlInventario.Location = new System.Drawing.Point(0, 60);
            this.tabControlInventario.Name = "tabControlInventario";
            this.tabControlInventario.SelectedIndex = 0;
            this.tabControlInventario.Size = new System.Drawing.Size(784, 501);
            this.tabControlInventario.TabIndex = 2;
            // 
            // tabEntradas
            // 
            this.tabEntradas.Controls.Add(this.btnRegistrarEntrada);
            this.tabEntradas.Controls.Add(this.numCantidadEntrada);
            this.tabEntradas.Controls.Add(this.label2);
            this.tabEntradas.Controls.Add(this.cmbProductoEntrada);
            this.tabEntradas.Controls.Add(this.label1);
            this.tabEntradas.Location = new System.Drawing.Point(4, 26);
            this.tabEntradas.Name = "tabEntradas";
            this.tabEntradas.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntradas.Size = new System.Drawing.Size(776, 471);
            this.tabEntradas.TabIndex = 0;
            this.tabEntradas.Text = "Entradas de Mercancía";
            this.tabEntradas.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarEntrada
            // 
            this.btnRegistrarEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRegistrarEntrada.FlatAppearance.BorderSize = 0;
            this.btnRegistrarEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarEntrada.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarEntrada.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarEntrada.Location = new System.Drawing.Point(30, 190);
            this.btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            this.btnRegistrarEntrada.Size = new System.Drawing.Size(200, 45);
            this.btnRegistrarEntrada.TabIndex = 4;
            this.btnRegistrarEntrada.Text = "Registrar Entrada";
            this.btnRegistrarEntrada.UseVisualStyleBackColor = false;
            // 
            // numCantidadEntrada
            // 
            this.numCantidadEntrada.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numCantidadEntrada.Location = new System.Drawing.Point(30, 120);
            this.numCantidadEntrada.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numCantidadEntrada.Name = "numCantidadEntrada";
            this.numCantidadEntrada.Size = new System.Drawing.Size(120, 29);
            this.numCantidadEntrada.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad:";
            // 
            // cmbProductoEntrada
            // 
            this.cmbProductoEntrada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductoEntrada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductoEntrada.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbProductoEntrada.FormattingEnabled = true;
            this.cmbProductoEntrada.Location = new System.Drawing.Point(30, 50);
            this.cmbProductoEntrada.Name = "cmbProductoEntrada";
            this.cmbProductoEntrada.Size = new System.Drawing.Size(350, 29);
            this.cmbProductoEntrada.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto:";
            // 
            // tabSalidas
            // 
            this.tabSalidas.Controls.Add(this.txtMotivoSalida);
            this.tabSalidas.Controls.Add(this.label5);
            this.tabSalidas.Controls.Add(this.btnRegistrarSalida);
            this.tabSalidas.Controls.Add(this.numCantidadSalida);
            this.tabSalidas.Controls.Add(this.label3);
            this.tabSalidas.Controls.Add(this.cmbProductoSalida);
            this.tabSalidas.Controls.Add(this.label4);
            this.tabSalidas.Location = new System.Drawing.Point(4, 26);
            this.tabSalidas.Name = "tabSalidas";
            this.tabSalidas.Padding = new System.Windows.Forms.Padding(3);
            this.tabSalidas.Size = new System.Drawing.Size(776, 471);
            this.tabSalidas.TabIndex = 1;
            this.tabSalidas.Text = "Salidas / Ajustes";
            this.tabSalidas.UseVisualStyleBackColor = true;
            // 
            // txtMotivoSalida
            // 
            this.txtMotivoSalida.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMotivoSalida.Location = new System.Drawing.Point(30, 190);
            this.txtMotivoSalida.Multiline = true;
            this.txtMotivoSalida.Name = "txtMotivoSalida";
            this.txtMotivoSalida.Size = new System.Drawing.Size(350, 80);
            this.txtMotivoSalida.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Motivo del Ajuste:";
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRegistrarSalida.FlatAppearance.BorderSize = 0;
            this.btnRegistrarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSalida.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarSalida.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarSalida.Location = new System.Drawing.Point(30, 290);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Size = new System.Drawing.Size(200, 45);
            this.btnRegistrarSalida.TabIndex = 9;
            this.btnRegistrarSalida.Text = "Registrar Salida";
            this.btnRegistrarSalida.UseVisualStyleBackColor = false;
            // 
            // numCantidadSalida
            // 
            this.numCantidadSalida.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numCantidadSalida.Location = new System.Drawing.Point(30, 120);
            this.numCantidadSalida.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numCantidadSalida.Name = "numCantidadSalida";
            this.numCantidadSalida.Size = new System.Drawing.Size(120, 29);
            this.numCantidadSalida.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cantidad:";
            // 
            // cmbProductoSalida
            // 
            this.cmbProductoSalida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductoSalida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductoSalida.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbProductoSalida.FormattingEnabled = true;
            this.cmbProductoSalida.Location = new System.Drawing.Point(30, 50);
            this.cmbProductoSalida.Name = "cmbProductoSalida";
            this.cmbProductoSalida.Size = new System.Drawing.Size(350, 29);
            this.cmbProductoSalida.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Producto:";
            // 
            // tabAjusteFisico
            // 
            this.tabAjusteFisico.Controls.Add(this.btnAplicarAjuste);
            this.tabAjusteFisico.Controls.Add(this.dgvAjusteStock);
            this.tabAjusteFisico.Location = new System.Drawing.Point(4, 26);
            this.tabAjusteFisico.Name = "tabAjusteFisico";
            this.tabAjusteFisico.Size = new System.Drawing.Size(776, 471);
            this.tabAjusteFisico.TabIndex = 3;
            this.tabAjusteFisico.Text = "Ajuste por Conteo Físico";
            this.tabAjusteFisico.UseVisualStyleBackColor = true;
            // 
            // btnAplicarAjuste
            // 
            this.btnAplicarAjuste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicarAjuste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAplicarAjuste.FlatAppearance.BorderSize = 0;
            this.btnAplicarAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarAjuste.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAplicarAjuste.ForeColor = System.Drawing.Color.White;
            this.btnAplicarAjuste.Location = new System.Drawing.Point(568, 418);
            this.btnAplicarAjuste.Name = "btnAplicarAjuste";
            this.btnAplicarAjuste.Size = new System.Drawing.Size(200, 45);
            this.btnAplicarAjuste.TabIndex = 1;
            this.btnAplicarAjuste.Text = "Aplicar Ajustes";
            this.btnAplicarAjuste.UseVisualStyleBackColor = false;
            // 
            // dgvAjusteStock
            // 
            this.dgvAjusteStock.AllowUserToAddRows = false;
            this.dgvAjusteStock.AllowUserToDeleteRows = false;
            this.dgvAjusteStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAjusteStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAjusteStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvAjusteStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAjusteStock.Location = new System.Drawing.Point(8, 8);
            this.dgvAjusteStock.Name = "dgvAjusteStock";
            this.dgvAjusteStock.Size = new System.Drawing.Size(760, 400);
            this.dgvAjusteStock.TabIndex = 0;
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.dgvHistorial);
            this.tabHistorial.Location = new System.Drawing.Point(4, 26);
            this.tabHistorial.Name = "tabHistorial";
            this.tabHistorial.Size = new System.Drawing.Size(776, 471);
            this.tabHistorial.TabIndex = 2;
            this.tabHistorial.Text = "Historial de Movimientos";
            this.tabHistorial.UseVisualStyleBackColor = true;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 0);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(776, 471);
            this.dgvHistorial.TabIndex = 0;
            // 
            // InventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControlInventario);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "InventarioForm";
            this.Text = "Gestión de Inventario";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabControlInventario.ResumeLayout(false);
            this.tabEntradas.ResumeLayout(false);
            this.tabEntradas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadEntrada)).EndInit();
            this.tabSalidas.ResumeLayout(false);
            this.tabSalidas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadSalida)).EndInit();
            this.tabAjusteFisico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAjusteStock)).EndInit();
            this.tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TabControl tabControlInventario;
        private System.Windows.Forms.TabPage tabEntradas;
        private System.Windows.Forms.TabPage tabSalidas;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProductoEntrada;
        private System.Windows.Forms.NumericUpDown numCantidadEntrada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegistrarEntrada;
        private System.Windows.Forms.TextBox txtMotivoSalida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.NumericUpDown numCantidadSalida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbProductoSalida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabAjusteFisico;
        private System.Windows.Forms.DataGridView dgvAjusteStock;
        private System.Windows.Forms.Button btnAplicarAjuste;
    }
}
