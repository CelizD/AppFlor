namespace FlorApp.Presentation
{
    partial class ReportesForm
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
            this.tabControlReportes = new System.Windows.Forms.TabControl();
            this.tabVentas = new System.Windows.Forms.TabPage();
            this.dgvReporteVentas = new System.Windows.Forms.DataGridView();
            this.pnlFiltrosVentas = new System.Windows.Forms.Panel();
            this.btnGenerarReporteVentas = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMasVendidos = new System.Windows.Forms.TabPage();
            this.dgvMasVendidos = new System.Windows.Forms.DataGridView();
            this.tabGanancias = new System.Windows.Forms.TabPage();
            this.lblGananciaNeta = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalVendido = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tabControlReportes.SuspendLayout();
            this.tabVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteVentas)).BeginInit();
            this.pnlFiltrosVentas.SuspendLayout();
            this.tabMasVendidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasVendidos)).BeginInit();
            this.tabGanancias.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 60);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(12, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(259, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Reportes y Estadísticas";
            // 
            // tabControlReportes
            // 
            this.tabControlReportes.Controls.Add(this.tabVentas);
            this.tabControlReportes.Controls.Add(this.tabMasVendidos);
            this.tabControlReportes.Controls.Add(this.tabGanancias);
            this.tabControlReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControlReportes.Location = new System.Drawing.Point(0, 60);
            this.tabControlReportes.Name = "tabControlReportes";
            this.tabControlReportes.SelectedIndex = 0;
            this.tabControlReportes.Size = new System.Drawing.Size(984, 501);
            this.tabControlReportes.TabIndex = 3;
            // 
            // tabVentas
            // 
            this.tabVentas.Controls.Add(this.dgvReporteVentas);
            this.tabVentas.Controls.Add(this.pnlFiltrosVentas);
            this.tabVentas.Location = new System.Drawing.Point(4, 26);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.Padding = new System.Windows.Forms.Padding(3);
            this.tabVentas.Size = new System.Drawing.Size(976, 471);
            this.tabVentas.TabIndex = 0;
            this.tabVentas.Text = "Reporte de Ventas";
            this.tabVentas.UseVisualStyleBackColor = true;
            // 
            // dgvReporteVentas
            // 
            this.dgvReporteVentas.AllowUserToAddRows = false;
            this.dgvReporteVentas.AllowUserToDeleteRows = false;
            this.dgvReporteVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporteVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvReporteVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporteVentas.Location = new System.Drawing.Point(3, 63);
            this.dgvReporteVentas.Name = "dgvReporteVentas";
            this.dgvReporteVentas.ReadOnly = true;
            this.dgvReporteVentas.Size = new System.Drawing.Size(970, 405);
            this.dgvReporteVentas.TabIndex = 1;
            // 
            // pnlFiltrosVentas
            // 
            this.pnlFiltrosVentas.Controls.Add(this.btnGenerarReporteVentas);
            this.pnlFiltrosVentas.Controls.Add(this.dtpFechaFin);
            this.pnlFiltrosVentas.Controls.Add(this.label2);
            this.pnlFiltrosVentas.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltrosVentas.Controls.Add(this.label1);
            this.pnlFiltrosVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltrosVentas.Location = new System.Drawing.Point(3, 3);
            this.pnlFiltrosVentas.Name = "pnlFiltrosVentas";
            this.pnlFiltrosVentas.Size = new System.Drawing.Size(970, 60);
            this.pnlFiltrosVentas.TabIndex = 0;
            // 
            // btnGenerarReporteVentas
            // 
            this.btnGenerarReporteVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenerarReporteVentas.FlatAppearance.BorderSize = 0;
            this.btnGenerarReporteVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporteVentas.ForeColor = System.Drawing.Color.White;
            this.btnGenerarReporteVentas.Location = new System.Drawing.Point(470, 15);
            this.btnGenerarReporteVentas.Name = "btnGenerarReporteVentas";
            this.btnGenerarReporteVentas.Size = new System.Drawing.Size(150, 30);
            this.btnGenerarReporteVentas.TabIndex = 4;
            this.btnGenerarReporteVentas.Text = "Generar Reporte";
            this.btnGenerarReporteVentas.UseVisualStyleBackColor = false;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFechaFin.Location = new System.Drawing.Point(240, 20);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 25);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFechaInicio.Location = new System.Drawing.Point(20, 20);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 25);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio:";
            // 
            // tabMasVendidos
            // 
            this.tabMasVendidos.Controls.Add(this.dgvMasVendidos);
            this.tabMasVendidos.Location = new System.Drawing.Point(4, 26);
            this.tabMasVendidos.Name = "tabMasVendidos";
            this.tabMasVendidos.Padding = new System.Windows.Forms.Padding(3);
            this.tabMasVendidos.Size = new System.Drawing.Size(976, 471);
            this.tabMasVendidos.TabIndex = 1;
            this.tabMasVendidos.Text = "Productos Más Vendidos";
            this.tabMasVendidos.UseVisualStyleBackColor = true;
            // 
            // dgvMasVendidos
            // 
            this.dgvMasVendidos.AllowUserToAddRows = false;
            this.dgvMasVendidos.AllowUserToDeleteRows = false;
            this.dgvMasVendidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMasVendidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMasVendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMasVendidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMasVendidos.Location = new System.Drawing.Point(3, 3);
            this.dgvMasVendidos.Name = "dgvMasVendidos";
            this.dgvMasVendidos.ReadOnly = true;
            this.dgvMasVendidos.Size = new System.Drawing.Size(970, 465);
            this.dgvMasVendidos.TabIndex = 0;
            // 
            // tabGanancias
            // 
            this.tabGanancias.Controls.Add(this.lblGananciaNeta);
            this.tabGanancias.Controls.Add(this.label4);
            this.tabGanancias.Controls.Add(this.lblTotalVendido);
            this.tabGanancias.Controls.Add(this.label3);
            this.tabGanancias.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.tabGanancias.Location = new System.Drawing.Point(4, 26);
            this.tabGanancias.Name = "tabGanancias";
            this.tabGanancias.Size = new System.Drawing.Size(976, 471);
            this.tabGanancias.TabIndex = 2;
            this.tabGanancias.Text = "Reporte de Ganancias";
            this.tabGanancias.UseVisualStyleBackColor = true;
            // 
            // lblGananciaNeta
            // 
            this.lblGananciaNeta.AutoSize = true;
            this.lblGananciaNeta.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblGananciaNeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblGananciaNeta.Location = new System.Drawing.Point(30, 150);
            this.lblGananciaNeta.Name = "lblGananciaNeta";
            this.lblGananciaNeta.Size = new System.Drawing.Size(91, 37);
            this.lblGananciaNeta.TabIndex = 3;
            this.lblGananciaNeta.Text = "$0.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ganancia Bruta Estimada:";
            // 
            // lblTotalVendido
            // 
            this.lblTotalVendido.AutoSize = true;
            this.lblTotalVendido.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalVendido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalVendido.Location = new System.Drawing.Point(30, 60);
            this.lblTotalVendido.Name = "lblTotalVendido";
            this.lblTotalVendido.Size = new System.Drawing.Size(91, 37);
            this.lblTotalVendido.TabIndex = 1;
            this.lblTotalVendido.Text = "$0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(309, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ingresos Totales (Periodo Sel.):";
            // 
            // ReportesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControlReportes);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "ReportesForm";
            this.Text = "Módulo de Reportes";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabControlReportes.ResumeLayout(false);
            this.tabVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteVentas)).EndInit();
            this.pnlFiltrosVentas.ResumeLayout(false);
            this.pnlFiltrosVentas.PerformLayout();
            this.tabMasVendidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasVendidos)).EndInit();
            this.tabGanancias.ResumeLayout(false);
            this.tabGanancias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TabControl tabControlReportes;
        private System.Windows.Forms.TabPage tabVentas;
        private System.Windows.Forms.TabPage tabMasVendidos;
        private System.Windows.Forms.TabPage tabGanancias;
        private System.Windows.Forms.Panel pnlFiltrosVentas;
        private System.Windows.Forms.Button btnGenerarReporteVentas;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReporteVentas;
        private System.Windows.Forms.DataGridView dgvMasVendidos;
        private System.Windows.Forms.Label lblGananciaNeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalVendido;
        private System.Windows.Forms.Label label3;
    }
}
