namespace FlorApp.Presentation
{
    partial class DashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlCardVentas = new System.Windows.Forms.Panel();
            this.lblVentasValor = new System.Windows.Forms.Label();
            this.lblVentasTitulo = new System.Windows.Forms.Label();
            this.pnlCardProductos = new System.Windows.Forms.Panel();
            this.lblProductosValor = new System.Windows.Forms.Label();
            this.lblProductosTitulo = new System.Windows.Forms.Label();
            this.pnlCardAlertas = new System.Windows.Forms.Panel();
            this.lblAlertasValor = new System.Windows.Forms.Label();
            this.lblAlertasTitulo = new System.Windows.Forms.Label();
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
            this.pnlCardVentas.SuspendLayout();
            this.pnlCardProductos.SuspendLayout();
            this.pnlCardAlertas.SuspendLayout();
            this.pnlAccesosDirectos.SuspendLayout();
            this.pnlAlertasInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.pnlEventosClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
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
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(16, 18);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(335, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Dashboard de Operación";
            // 
            // pnlCards
            // 
            this.pnlCards.Controls.Add(this.pnlCardVentas);
            this.pnlCards.Controls.Add(this.pnlCardProductos);
            this.pnlCards.Controls.Add(this.pnlCardAlertas);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 74);
            this.pnlCards.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(27, 25, 27, 12);
            this.pnlCards.Size = new System.Drawing.Size(1579, 160);
            this.pnlCards.TabIndex = 2;
            // 
            // pnlCardVentas
            // 
            this.pnlCardVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlCardVentas.Controls.Add(this.lblVentasValor);
            this.pnlCardVentas.Controls.Add(this.lblVentasTitulo);
            this.pnlCardVentas.Location = new System.Drawing.Point(31, 28);
            this.pnlCardVentas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Size = new System.Drawing.Size(333, 111);
            this.pnlCardVentas.TabIndex = 0;
            // 
            // lblVentasValor
            // 
            this.lblVentasValor.AutoSize = true;
            this.lblVentasValor.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasValor.ForeColor = System.Drawing.Color.White;
            this.lblVentasValor.Location = new System.Drawing.Point(20, 46);
            this.lblVentasValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentasValor.Name = "lblVentasValor";
            this.lblVentasValor.Size = new System.Drawing.Size(109, 46);
            this.lblVentasValor.TabIndex = 1;
            this.lblVentasValor.Text = "$0.00";
            // 
            // lblVentasTitulo
            // 
            this.lblVentasTitulo.AutoSize = true;
            this.lblVentasTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasTitulo.ForeColor = System.Drawing.Color.White;
            this.lblVentasTitulo.Location = new System.Drawing.Point(24, 12);
            this.lblVentasTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentasTitulo.Name = "lblVentasTitulo";
            this.lblVentasTitulo.Size = new System.Drawing.Size(134, 25);
            this.lblVentasTitulo.TabIndex = 0;
            this.lblVentasTitulo.Text = "Ventas del Día";
            // 
            // pnlCardProductos
            // 
            this.pnlCardProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlCardProductos.Controls.Add(this.lblProductosValor);
            this.pnlCardProductos.Controls.Add(this.lblProductosTitulo);
            this.pnlCardProductos.Location = new System.Drawing.Point(400, 28);
            this.pnlCardProductos.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardProductos.Name = "pnlCardProductos";
            this.pnlCardProductos.Size = new System.Drawing.Size(333, 111);
            this.pnlCardProductos.TabIndex = 1;
            // 
            // lblProductosValor
            // 
            this.lblProductosValor.AutoSize = true;
            this.lblProductosValor.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosValor.ForeColor = System.Drawing.Color.White;
            this.lblProductosValor.Location = new System.Drawing.Point(20, 46);
            this.lblProductosValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductosValor.Name = "lblProductosValor";
            this.lblProductosValor.Size = new System.Drawing.Size(40, 46);
            this.lblProductosValor.TabIndex = 1;
            this.lblProductosValor.Text = "0";
            // 
            // lblProductosTitulo
            // 
            this.lblProductosTitulo.AutoSize = true;
            this.lblProductosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductosTitulo.ForeColor = System.Drawing.Color.White;
            this.lblProductosTitulo.Location = new System.Drawing.Point(24, 12);
            this.lblProductosTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductosTitulo.Name = "lblProductosTitulo";
            this.lblProductosTitulo.Size = new System.Drawing.Size(166, 25);
            this.lblProductosTitulo.TabIndex = 0;
            this.lblProductosTitulo.Text = "Productos Activos";
            // 
            // pnlCardAlertas
            // 
            this.pnlCardAlertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlCardAlertas.Controls.Add(this.lblAlertasValor);
            this.pnlCardAlertas.Controls.Add(this.lblAlertasTitulo);
            this.pnlCardAlertas.Location = new System.Drawing.Point(769, 28);
            this.pnlCardAlertas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCardAlertas.Name = "pnlCardAlertas";
            this.pnlCardAlertas.Size = new System.Drawing.Size(333, 111);
            this.pnlCardAlertas.TabIndex = 2;
            // 
            // lblAlertasValor
            // 
            this.lblAlertasValor.AutoSize = true;
            this.lblAlertasValor.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertasValor.ForeColor = System.Drawing.Color.White;
            this.lblAlertasValor.Location = new System.Drawing.Point(20, 46);
            this.lblAlertasValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertasValor.Name = "lblAlertasValor";
            this.lblAlertasValor.Size = new System.Drawing.Size(40, 46);
            this.lblAlertasValor.TabIndex = 1;
            this.lblAlertasValor.Text = "0";
            // 
            // lblAlertasTitulo
            // 
            this.lblAlertasTitulo.AutoSize = true;
            this.lblAlertasTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertasTitulo.ForeColor = System.Drawing.Color.White;
            this.lblAlertasTitulo.Location = new System.Drawing.Point(24, 12);
            this.lblAlertasTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertasTitulo.Name = "lblAlertasTitulo";
            this.lblAlertasTitulo.Size = new System.Drawing.Size(191, 25);
            this.lblAlertasTitulo.TabIndex = 0;
            this.lblAlertasTitulo.Text = "Productos Bajo Stock";
            // 
            // pnlAccesosDirectos
            // 
            this.pnlAccesosDirectos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAccesosDirectos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
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
            this.pnlAccesosDirectos.Location = new System.Drawing.Point(31, 255);
            this.pnlAccesosDirectos.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAccesosDirectos.Name = "pnlAccesosDirectos";
            this.pnlAccesosDirectos.Size = new System.Drawing.Size(333, 667);
            this.pnlAccesosDirectos.TabIndex = 3;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfiguracion.ForeColor = System.Drawing.Color.White;
            this.btnConfiguracion.Location = new System.Drawing.Point(29, 542);
            this.btnConfiguracion.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(275, 49);
            this.btnConfiguracion.TabIndex = 9;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(29, 486);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(4);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(275, 49);
            this.btnReportes.TabIndex = 8;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCompras.ForeColor = System.Drawing.Color.White;
            this.btnCompras.Location = new System.Drawing.Point(29, 431);
            this.btnCompras.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(275, 49);
            this.btnCompras.TabIndex = 7;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = false;
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Location = new System.Drawing.Point(29, 375);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(4);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(275, 49);
            this.btnInventario.TabIndex = 6;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.Location = new System.Drawing.Point(29, 320);
            this.btnProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(275, 49);
            this.btnProveedores.TabIndex = 5;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = false;
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Location = new System.Drawing.Point(29, 265);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(275, 49);
            this.btnProductos.TabIndex = 4;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(29, 209);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(275, 49);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            // 
            // btnPedidos
            // 
            this.btnPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnPedidos.FlatAppearance.BorderSize = 0;
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPedidos.ForeColor = System.Drawing.Color.White;
            this.btnPedidos.Location = new System.Drawing.Point(29, 154);
            this.btnPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(275, 49);
            this.btnPedidos.TabIndex = 2;
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.UseVisualStyleBackColor = false;
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnNuevaVenta.FlatAppearance.BorderSize = 0;
            this.btnNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNuevaVenta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaVenta.Location = new System.Drawing.Point(29, 98);
            this.btnNuevaVenta.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(275, 49);
            this.btnNuevaVenta.TabIndex = 1;
            this.btnNuevaVenta.Text = "Nueva Venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = false;
            // 
            // btnKiosco
            // 
            this.btnKiosco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnKiosco.FlatAppearance.BorderSize = 0;
            this.btnKiosco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiosco.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnKiosco.ForeColor = System.Drawing.Color.White;
            this.btnKiosco.Location = new System.Drawing.Point(29, 43);
            this.btnKiosco.Margin = new System.Windows.Forms.Padding(4);
            this.btnKiosco.Name = "btnKiosco";
            this.btnKiosco.Size = new System.Drawing.Size(275, 49);
            this.btnKiosco.TabIndex = 0;
            this.btnKiosco.Text = "Kiosco Cliente";
            this.btnKiosco.UseVisualStyleBackColor = false;
            // 
            // pnlAlertasInventario
            // 
            this.pnlAlertasInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAlertasInventario.BackColor = System.Drawing.Color.White;
            this.pnlAlertasInventario.Controls.Add(this.lstAlertas);
            this.pnlAlertasInventario.Controls.Add(this.lblAlertasInventario);
            this.pnlAlertasInventario.Location = new System.Drawing.Point(400, 601);
            this.pnlAlertasInventario.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAlertasInventario.Name = "pnlAlertasInventario";
            this.pnlAlertasInventario.Size = new System.Drawing.Size(560, 321);
            this.pnlAlertasInventario.TabIndex = 4;
            // 
            // lstAlertas
            // 
            this.lstAlertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAlertas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAlertas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstAlertas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lstAlertas.FormattingEnabled = true;
            this.lstAlertas.ItemHeight = 21;
            this.lstAlertas.Location = new System.Drawing.Point(27, 62);
            this.lstAlertas.Margin = new System.Windows.Forms.Padding(4);
            this.lstAlertas.Name = "lstAlertas";
            this.lstAlertas.Size = new System.Drawing.Size(507, 210);
            this.lstAlertas.TabIndex = 1;
            // 
            // lblAlertasInventario
            // 
            this.lblAlertasInventario.AutoSize = true;
            this.lblAlertasInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlertasInventario.Location = new System.Drawing.Point(20, 18);
            this.lblAlertasInventario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlertasInventario.Name = "lblAlertasInventario";
            this.lblAlertasInventario.Size = new System.Drawing.Size(212, 28);
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
            chartArea2.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVentas.Legends.Add(legend2);
            this.chartVentas.Location = new System.Drawing.Point(400, 255);
            this.chartVentas.Margin = new System.Windows.Forms.Padding(4);
            this.chartVentas.Name = "chartVentas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Ventas";
            this.chartVentas.Series.Add(series2);
            this.chartVentas.Size = new System.Drawing.Size(1144, 325);
            this.chartVentas.TabIndex = 5;
            this.chartVentas.Text = "chart1";
            // 
            // pnlEventosClientes
            // 
            this.pnlEventosClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEventosClientes.BackColor = System.Drawing.Color.White;
            this.pnlEventosClientes.Controls.Add(this.lstEventosClientes);
            this.pnlEventosClientes.Controls.Add(this.lblEventosClientes);
            this.pnlEventosClientes.Location = new System.Drawing.Point(984, 601);
            this.pnlEventosClientes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEventosClientes.Name = "pnlEventosClientes";
            this.pnlEventosClientes.Size = new System.Drawing.Size(560, 321);
            this.pnlEventosClientes.TabIndex = 6;
            // 
            // lstEventosClientes
            // 
            this.lstEventosClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEventosClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstEventosClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lstEventosClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lstEventosClientes.FormattingEnabled = true;
            this.lstEventosClientes.ItemHeight = 21;
            this.lstEventosClientes.Location = new System.Drawing.Point(27, 63);
            this.lstEventosClientes.Margin = new System.Windows.Forms.Padding(4);
            this.lstEventosClientes.Name = "lstEventosClientes";
            this.lstEventosClientes.Size = new System.Drawing.Size(507, 210);
            this.lstEventosClientes.TabIndex = 1;
            // 
            // lblEventosClientes
            // 
            this.lblEventosClientes.AutoSize = true;
            this.lblEventosClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEventosClientes.Location = new System.Drawing.Point(20, 18);
            this.lblEventosClientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventosClientes.Name = "lblEventosClientes";
            this.lblEventosClientes.Size = new System.Drawing.Size(290, 28);
            this.lblEventosClientes.TabIndex = 0;
            this.lblEventosClientes.Text = "Próximos Eventos de Clientes";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
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
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.pnlCardProductos.ResumeLayout(false);
            this.pnlCardProductos.PerformLayout();
            this.pnlCardAlertas.ResumeLayout(false);
            this.pnlCardAlertas.PerformLayout();
            this.pnlAccesosDirectos.ResumeLayout(false);
            this.pnlAlertasInventario.ResumeLayout(false);
            this.pnlAlertasInventario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.pnlEventosClientes.ResumeLayout(false);
            this.pnlEventosClientes.PerformLayout();
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