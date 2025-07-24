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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.lblAccesosDirectos = new System.Windows.Forms.Label();
            this.pnlAlertasInventario = new System.Windows.Forms.Panel();
            this.lstAlertas = new System.Windows.Forms.ListBox();
            this.lblAlertasInventario = new System.Windows.Forms.Label();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.pnlCardProductos.SuspendLayout();
            this.pnlCardAlertas.SuspendLayout();
            this.pnlAccesosDirectos.SuspendLayout();
            this.pnlAlertasInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.pnlCards.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.pnlCardVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lblVentasValor.Size = new System.Drawing.Size(129, 46);
            this.lblVentasValor.TabIndex = 1;
            this.lblVentasValor.Text = "$1,250";
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
            this.pnlCardProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lblProductosValor.Size = new System.Drawing.Size(80, 46);
            this.lblProductosValor.TabIndex = 1;
            this.lblProductosValor.Text = "128";
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
            this.pnlCardAlertas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lblAlertasValor.Text = "5";
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
            this.pnlAccesosDirectos.Controls.Add(this.btnInventario);
            this.pnlAccesosDirectos.Controls.Add(this.btnProveedores);
            this.pnlAccesosDirectos.Controls.Add(this.btnProductos);
            this.pnlAccesosDirectos.Controls.Add(this.btnClientes);
            this.pnlAccesosDirectos.Controls.Add(this.btnPedidos);
            this.pnlAccesosDirectos.Controls.Add(this.btnNuevaVenta);
            this.pnlAccesosDirectos.Controls.Add(this.lblAccesosDirectos);
            this.pnlAccesosDirectos.Location = new System.Drawing.Point(31, 255);
            this.pnlAccesosDirectos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnConfiguracion.Location = new System.Drawing.Point(29, 591);
            this.btnConfiguracion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(275, 62);
            this.btnConfiguracion.TabIndex = 8;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(29, 517);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(275, 62);
            this.btnReportes.TabIndex = 7;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Location = new System.Drawing.Point(29, 443);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(275, 62);
            this.btnInventario.TabIndex = 6;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProveedores.ForeColor = System.Drawing.Color.White;
            this.btnProveedores.Location = new System.Drawing.Point(29, 369);
            this.btnProveedores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(275, 62);
            this.btnProveedores.TabIndex = 5;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Location = new System.Drawing.Point(29, 295);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(275, 62);
            this.btnProductos.TabIndex = 4;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(29, 222);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(275, 62);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnPedidos
            // 
            this.btnPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnPedidos.FlatAppearance.BorderSize = 0;
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPedidos.ForeColor = System.Drawing.Color.White;
            this.btnPedidos.Location = new System.Drawing.Point(29, 148);
            this.btnPedidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(275, 62);
            this.btnPedidos.TabIndex = 2;
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.UseVisualStyleBackColor = false;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnNuevaVenta.FlatAppearance.BorderSize = 0;
            this.btnNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaVenta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaVenta.Location = new System.Drawing.Point(29, 74);
            this.btnNuevaVenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(275, 62);
            this.btnNuevaVenta.TabIndex = 1;
            this.btnNuevaVenta.Text = "Nueva Venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = false;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // lblAccesosDirectos
            // 
            this.lblAccesosDirectos.AutoSize = true;
            this.lblAccesosDirectos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccesosDirectos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblAccesosDirectos.Location = new System.Drawing.Point(24, 25);
            this.lblAccesosDirectos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccesosDirectos.Name = "lblAccesosDirectos";
            this.lblAccesosDirectos.Size = new System.Drawing.Size(172, 28);
            this.lblAccesosDirectos.TabIndex = 0;
            this.lblAccesosDirectos.Text = "Accesos Directos";
            // 
            // pnlAlertasInventario
            // 
            this.pnlAlertasInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlAlertasInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlAlertasInventario.Controls.Add(this.lstAlertas);
            this.pnlAlertasInventario.Controls.Add(this.lblAlertasInventario);
            this.pnlAlertasInventario.Location = new System.Drawing.Point(400, 601);
            this.pnlAlertasInventario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlAlertasInventario.Name = "pnlAlertasInventario";
            this.pnlAlertasInventario.Size = new System.Drawing.Size(1144, 321);
            this.pnlAlertasInventario.TabIndex = 4;
            // 
            // lstAlertas
            // 
            this.lstAlertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAlertas.BackColor = System.Drawing.Color.White;
            this.lstAlertas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAlertas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAlertas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lstAlertas.FormattingEnabled = true;
            this.lstAlertas.ItemHeight = 21;
            this.lstAlertas.Location = new System.Drawing.Point(29, 63);
            this.lstAlertas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstAlertas.Name = "lstAlertas";
            this.lstAlertas.Size = new System.Drawing.Size(1085, 210);
            this.lstAlertas.TabIndex = 1;
            // 
            // lblAlertasInventario
            // 
            this.lblAlertasInventario.AutoSize = true;
            this.lblAlertasInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertasInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblAlertasInventario.Location = new System.Drawing.Point(24, 25);
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
            chartArea1.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVentas.Legends.Add(legend1);
            this.chartVentas.Location = new System.Drawing.Point(400, 255);
            this.chartVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartVentas.Name = "chartVentas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Ventas";
            this.chartVentas.Series.Add(series1);
            this.chartVentas.Size = new System.Drawing.Size(1144, 325);
            this.chartVentas.TabIndex = 5;
            this.chartVentas.Text = "chart1";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1579, 937);
            this.Controls.Add(this.chartVentas);
            this.Controls.Add(this.pnlAlertasInventario);
            this.Controls.Add(this.pnlAccesosDirectos);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.pnlAccesosDirectos.PerformLayout();
            this.pnlAlertasInventario.ResumeLayout(false);
            this.pnlAlertasInventario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
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
        private System.Windows.Forms.Label lblAccesosDirectos;
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
    }
}
