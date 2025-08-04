namespace FlorApp.Presentation
{
    partial class DashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlCardAlertas = new System.Windows.Forms.Panel();
            this.lblAlertasValor = new System.Windows.Forms.Label();
            this.lblAlertasTitulo = new System.Windows.Forms.Label();
            this.pnlCardProductos = new System.Windows.Forms.Panel();
            this.lblProductosValor = new System.Windows.Forms.Label();
            this.lblProductosTitulo = new System.Windows.Forms.Label();
            this.pnlCardVentas = new System.Windows.Forms.Panel();
            this.lblVentasValor = new System.Windows.Forms.Label();
            this.lblVentasTitulo = new System.Windows.Forms.Label();
            this.pnlAccesosDirectos = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.btnKiosco = new System.Windows.Forms.Button();
            this.pnlAlertasInventario = new System.Windows.Forms.Panel();
            this.lstAlertas = new System.Windows.Forms.ListBox();
            this.lblAlertasInventario = new System.Windows.Forms.Label();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlEventosClientes = new System.Windows.Forms.Panel();
            this.lstEventosClientes = new System.Windows.Forms.ListBox();
            this.lblEventosClientes = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlCardAlertas.SuspendLayout();
            this.pnlCardProductos.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.pnlAccesosDirectos.SuspendLayout();
            this.pnlAlertasInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.pnlEventosClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1579, 74);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(33, 18);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(362, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Dashboard de Operaciones";
            // 
            // pnlCards
            // 
            this.pnlCards.Controls.Add(this.pnlCardAlertas);
            this.pnlCards.Controls.Add(this.pnlCardProductos);
            this.pnlCards.Controls.Add(this.pnlCardVentas);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 74);
            this.pnlCards.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(27, 25, 27, 12);
            this.pnlCards.Size = new System.Drawing.Size(1579, 160);
            this.pnlCards.TabIndex = 2;
            // 
            // pnlCardAlertas
            // 
            this.pnlCardAlertas.Controls.Add(this.lblAlertasValor);
            this.pnlCardAlertas.Controls.Add(this.lblAlertasTitulo);
            this.pnlCardAlertas.Location = new System.Drawing.Point(827, 25);
            this.pnlCardAlertas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardAlertas.Name = "pnlCardAlertas";
            this.pnlCardAlertas.Size = new System.Drawing.Size(373, 123);
            this.pnlCardAlertas.TabIndex = 2;
            // 
            // lblAlertasValor
            // 
            this.lblAlertasValor.Location = new System.Drawing.Point(13, 55);
            this.lblAlertasValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertasValor.Name = "lblAlertasValor";
            this.lblAlertasValor.Size = new System.Drawing.Size(347, 55);
            this.lblAlertasValor.TabIndex = 1;
            this.lblAlertasValor.Text = "0";
            // 
            // lblAlertasTitulo
            // 
            this.lblAlertasTitulo.AutoSize = true;
            this.lblAlertasTitulo.Location = new System.Drawing.Point(13, 12);
            this.lblAlertasTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertasTitulo.Name = "lblAlertasTitulo";
            this.lblAlertasTitulo.Size = new System.Drawing.Size(136, 16);
            this.lblAlertasTitulo.TabIndex = 0;
            this.lblAlertasTitulo.Text = "Productos Bajo Stock";
            // 
            // pnlCardProductos
            // 
            this.pnlCardProductos.Controls.Add(this.lblProductosValor);
            this.pnlCardProductos.Controls.Add(this.lblProductosTitulo);
            this.pnlCardProductos.Location = new System.Drawing.Point(427, 25);
            this.pnlCardProductos.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardProductos.Name = "pnlCardProductos";
            this.pnlCardProductos.Size = new System.Drawing.Size(373, 123);
            this.pnlCardProductos.TabIndex = 1;
            // 
            // lblProductosValor
            // 
            this.lblProductosValor.Location = new System.Drawing.Point(13, 55);
            this.lblProductosValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductosValor.Name = "lblProductosValor";
            this.lblProductosValor.Size = new System.Drawing.Size(347, 55);
            this.lblProductosValor.TabIndex = 1;
            this.lblProductosValor.Text = "0";
            // 
            // lblProductosTitulo
            // 
            this.lblProductosTitulo.AutoSize = true;
            this.lblProductosTitulo.Location = new System.Drawing.Point(13, 12);
            this.lblProductosTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductosTitulo.Name = "lblProductosTitulo";
            this.lblProductosTitulo.Size = new System.Drawing.Size(115, 16);
            this.lblProductosTitulo.TabIndex = 0;
            this.lblProductosTitulo.Text = "Productos Activos";
            // 
            // pnlCardVentas
            // 
            this.pnlCardVentas.Controls.Add(this.lblVentasValor);
            this.pnlCardVentas.Controls.Add(this.lblVentasTitulo);
            this.pnlCardVentas.Location = new System.Drawing.Point(27, 25);
            this.pnlCardVentas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Size = new System.Drawing.Size(373, 123);
            this.pnlCardVentas.TabIndex = 0;
            // 
            // lblVentasValor
            // 
            this.lblVentasValor.Location = new System.Drawing.Point(13, 55);
            this.lblVentasValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentasValor.Name = "lblVentasValor";
            this.lblVentasValor.Size = new System.Drawing.Size(347, 55);
            this.lblVentasValor.TabIndex = 1;
            this.lblVentasValor.Text = "$0.00";
            // 
            // lblVentasTitulo
            // 
            this.lblVentasTitulo.AutoSize = true;
            this.lblVentasTitulo.Location = new System.Drawing.Point(13, 12);
            this.lblVentasTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentasTitulo.Name = "lblVentasTitulo";
            this.lblVentasTitulo.Size = new System.Drawing.Size(95, 16);
            this.lblVentasTitulo.TabIndex = 0;
            this.lblVentasTitulo.Text = "Ventas del Día";
            // 
            // pnlAccesosDirectos
            // 
            this.pnlAccesosDirectos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAccesosDirectos.Controls.Add(this.btnConfiguracion);
            this.pnlAccesosDirectos.Controls.Add(this.btnReportes);
            this.pnlAccesosDirectos.Controls.Add(this.btnCompras);
            this.pnlAccesosDirectos.Controls.Add(this.btnInventario);
            this.pnlAccesosDirectos.Controls.Add(this.btnProveedores);
            this.pnlAccesosDirectos.Controls.Add(this.btnProductos);
            this.pnlAccesosDirectos.Controls.Add(this.btnClientes);
            this.pnlAccesosDirectos.Controls.Add(this.btnPedidos);
            this.pnlAccesosDirectos.Controls.Add(this.btnNuevaVenta);
            this.pnlAccesosDirectos.Controls.Add(this.btnKiosco);
            this.pnlAccesosDirectos.Location = new System.Drawing.Point(27, 246);
            this.pnlAccesosDirectos.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAccesosDirectos.Name = "pnlAccesosDirectos";
            this.pnlAccesosDirectos.Size = new System.Drawing.Size(373, 677);
            this.pnlAccesosDirectos.TabIndex = 3;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 614);
            this.btnConfiguracion.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(373, 62);
            this.btnConfiguracion.TabIndex = 9;
            this.btnConfiguracion.Text = "  Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(0, 552);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(4);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(373, 62);
            this.btnReportes.TabIndex = 8;
            this.btnReportes.Text = "  Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnCompras
            // 
            this.btnCompras.Location = new System.Drawing.Point(0, 490);
            this.btnCompras.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(373, 62);
            this.btnCompras.TabIndex = 7;
            this.btnCompras.Text = "  Compras";
            this.btnCompras.UseVisualStyleBackColor = true;
            // 
            // btnInventario
            // 
            this.btnInventario.Location = new System.Drawing.Point(0, 428);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(4);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(373, 62);
            this.btnInventario.TabIndex = 6;
            this.btnInventario.Text = "  Inventario";
            this.btnInventario.UseVisualStyleBackColor = true;
            // 
            // btnProveedores
            // 
            this.btnProveedores.Location = new System.Drawing.Point(0, 366);
            this.btnProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(373, 62);
            this.btnProveedores.TabIndex = 5;
            this.btnProveedores.Text = "  Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(0, 305);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(373, 62);
            this.btnProductos.TabIndex = 4;
            this.btnProductos.Text = "  Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(0, 244);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(373, 62);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "  Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnPedidos
            // 
            this.btnPedidos.Location = new System.Drawing.Point(0, 183);
            this.btnPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(373, 62);
            this.btnPedidos.TabIndex = 2;
            this.btnPedidos.Text = "  Pedidos";
            this.btnPedidos.UseVisualStyleBackColor = true;
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.Location = new System.Drawing.Point(0, 122);
            this.btnNuevaVenta.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(373, 62);
            this.btnNuevaVenta.TabIndex = 1;
            this.btnNuevaVenta.Text = "  Nueva Venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            // 
            // btnKiosco
            // 
            this.btnKiosco.Location = new System.Drawing.Point(0, 60);
            this.btnKiosco.Margin = new System.Windows.Forms.Padding(4);
            this.btnKiosco.Name = "btnKiosco";
            this.btnKiosco.Size = new System.Drawing.Size(373, 62);
            this.btnKiosco.TabIndex = 0;
            this.btnKiosco.Text = "  Kiosco Cliente";
            this.btnKiosco.UseVisualStyleBackColor = true;
            // 
            // pnlAlertasInventario
            // 
            this.pnlAlertasInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAlertasInventario.Controls.Add(this.lstAlertas);
            this.pnlAlertasInventario.Location = new System.Drawing.Point(427, 603);
            this.pnlAlertasInventario.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAlertasInventario.Name = "pnlAlertasInventario";
            this.pnlAlertasInventario.Size = new System.Drawing.Size(560, 320);
            this.pnlAlertasInventario.TabIndex = 4;
            // 
            // lstAlertas
            // 
            this.lstAlertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAlertas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstAlertas.ForeColor = System.Drawing.Color.Firebrick;
            this.lstAlertas.FormattingEnabled = true;
            this.lstAlertas.ItemHeight = 21;
            this.lstAlertas.Location = new System.Drawing.Point(27, 62);
            this.lstAlertas.Margin = new System.Windows.Forms.Padding(4);
            this.lstAlertas.Name = "lstAlertas";
            this.lstAlertas.Size = new System.Drawing.Size(505, 214);
            this.lstAlertas.TabIndex = 1;
            // 
            // lblAlertasInventario
            // 
            this.lblAlertasInventario.AutoSize = true;
            this.lblAlertasInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlertasInventario.Location = new System.Drawing.Point(15, 15);
            this.lblAlertasInventario.Name = "lblAlertasInventario";
            this.lblAlertasInventario.Size = new System.Drawing.Size(167, 21);
            this.lblAlertasInventario.TabIndex = 0;
            this.lblAlertasInventario.Text = "Alertas de Inventario";
            // 
            // chartVentas
            // 
            this.chartVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartVentas.BorderlineColor = System.Drawing.Color.Gainsboro;
            this.chartVentas.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVentas.Legends.Add(legend1);
            this.chartVentas.Location = new System.Drawing.Point(427, 246);
            this.chartVentas.Margin = new System.Windows.Forms.Padding(4);
            this.chartVentas.Name = "chartVentas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Ventas";
            this.chartVentas.Series.Add(series1);
            this.chartVentas.Size = new System.Drawing.Size(1125, 345);
            this.chartVentas.TabIndex = 5;
            this.chartVentas.Text = "chart1";
            // 
            // pnlEventosClientes
            // 
            this.pnlEventosClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEventosClientes.Controls.Add(this.lstEventosClientes);
            this.pnlEventosClientes.Location = new System.Drawing.Point(1000, 603);
            this.pnlEventosClientes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEventosClientes.Name = "pnlEventosClientes";
            this.pnlEventosClientes.Size = new System.Drawing.Size(560, 320);
            this.pnlEventosClientes.TabIndex = 6;
            // 
            // lstEventosClientes
            // 
            this.lstEventosClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEventosClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstEventosClientes.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lstEventosClientes.FormattingEnabled = true;
            this.lstEventosClientes.ItemHeight = 21;
            this.lstEventosClientes.Location = new System.Drawing.Point(27, 62);
            this.lstEventosClientes.Margin = new System.Windows.Forms.Padding(4);
            this.lstEventosClientes.Name = "lstEventosClientes";
            this.lstEventosClientes.Size = new System.Drawing.Size(505, 214);
            this.lstEventosClientes.TabIndex = 1;
            // 
            // lblEventosClientes
            // 
            this.lblEventosClientes.AutoSize = true;
            this.lblEventosClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEventosClientes.Location = new System.Drawing.Point(15, 15);
            this.lblEventosClientes.Name = "lblEventosClientes";
            this.lblEventosClientes.Size = new System.Drawing.Size(229, 21);
            this.lblEventosClientes.TabIndex = 0;
            this.lblEventosClientes.Text = "Próximos Eventos de Clientes";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 937);
            this.Controls.Add(this.pnlEventosClientes);
            this.Controls.Add(this.chartVentas);
            this.Controls.Add(this.pnlAlertasInventario);
            this.Controls.Add(this.pnlAccesosDirectos);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1594, 974);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlorApp - Dashboard";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlCardAlertas.ResumeLayout(false);
            this.pnlCardAlertas.PerformLayout();
            this.pnlCardProductos.ResumeLayout(false);
            this.pnlCardProductos.PerformLayout();
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.pnlAccesosDirectos.ResumeLayout(false);
            this.pnlAlertasInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.pnlEventosClientes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlCardVentas;
        private System.Windows.Forms.Label lblVentasTitulo;
        private System.Windows.Forms.Label lblVentasValor;
        private System.Windows.Forms.Panel pnlCardProductos;
        private System.Windows.Forms.Label lblProductosValor;
        private System.Windows.Forms.Label lblProductosTitulo;
        private System.Windows.Forms.Panel pnlCardAlertas;
        private System.Windows.Forms.Label lblAlertasValor;
        private System.Windows.Forms.Label lblAlertasTitulo;
        private System.Windows.Forms.Panel pnlAccesosDirectos;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel pnlAlertasInventario;
        private System.Windows.Forms.ListBox lstAlertas;
        private System.Windows.Forms.Label lblAlertasInventario;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.Panel pnlEventosClientes;
        private System.Windows.Forms.ListBox lstEventosClientes;
        private System.Windows.Forms.Label lblEventosClientes;
        private System.Windows.Forms.Button btnKiosco;
        private System.Windows.Forms.Button btnCompras;
    }
}
