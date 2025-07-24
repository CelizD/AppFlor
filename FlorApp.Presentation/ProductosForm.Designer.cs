namespace FlorApp.Presentation
{
    partial class ProductosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.numStockMaximo = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numStockMinimo = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnCargarFoto = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            this.pnlDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMaximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioCosto)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1184, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(12, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(248, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Catálogo de Productos";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvProductos);
            this.pnlGrid.Controls.Add(this.pnlBusqueda);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(350, 60);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrid.Size = new System.Drawing.Size(834, 601);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeight = 30;
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(10, 60);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.RowTemplate.Height = 28;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(814, 531);
            this.dgvProductos.TabIndex = 1;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.Controls.Add(this.btnBuscar);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(10, 10);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(814, 50);
            this.pnlBusqueda.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(306, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBuscar.Location = new System.Drawing.Point(3, 9);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(297, 29);
            this.txtBuscar.TabIndex = 0;
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlDetalles.Controls.Add(this.numStockMaximo);
            this.pnlDetalles.Controls.Add(this.label8);
            this.pnlDetalles.Controls.Add(this.numStockMinimo);
            this.pnlDetalles.Controls.Add(this.label7);
            this.pnlDetalles.Controls.Add(this.picFoto);
            this.pnlDetalles.Controls.Add(this.btnCargarFoto);
            this.pnlDetalles.Controls.Add(this.label6);
            this.pnlDetalles.Controls.Add(this.numPrecioVenta);
            this.pnlDetalles.Controls.Add(this.label5);
            this.pnlDetalles.Controls.Add(this.numPrecioCosto);
            this.pnlDetalles.Controls.Add(this.label4);
            this.pnlDetalles.Controls.Add(this.cmbProveedor);
            this.pnlDetalles.Controls.Add(this.label3);
            this.pnlDetalles.Controls.Add(this.cmbCategoria);
            this.pnlDetalles.Controls.Add(this.label2);
            this.pnlDetalles.Controls.Add(this.txtDescripcion);
            this.pnlDetalles.Controls.Add(this.label1);
            this.pnlDetalles.Controls.Add(this.txtNombre);
            this.pnlDetalles.Controls.Add(this.lblNombre);
            this.pnlDetalles.Controls.Add(this.pnlBotones);
            this.pnlDetalles.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDetalles.Location = new System.Drawing.Point(0, 60);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Size = new System.Drawing.Size(350, 601);
            this.pnlDetalles.TabIndex = 1;
            // 
            // numStockMaximo
            // 
            this.numStockMaximo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numStockMaximo.Location = new System.Drawing.Point(173, 430);
            this.numStockMaximo.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numStockMaximo.Name = "numStockMaximo";
            this.numStockMaximo.Size = new System.Drawing.Size(150, 25);
            this.numStockMaximo.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(170, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Stock Máximo:";
            // 
            // numStockMinimo
            // 
            this.numStockMinimo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numStockMinimo.Location = new System.Drawing.Point(17, 430);
            this.numStockMinimo.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numStockMinimo.Name = "numStockMinimo";
            this.numStockMinimo.Size = new System.Drawing.Size(150, 25);
            this.numStockMinimo.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(14, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Stock Mínimo:";
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.White;
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(17, 490);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(100, 100);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 15;
            this.picFoto.TabStop = false;
            // 
            // btnCargarFoto
            // 
            this.btnCargarFoto.Location = new System.Drawing.Point(123, 490);
            this.btnCargarFoto.Name = "btnCargarFoto";
            this.btnCargarFoto.Size = new System.Drawing.Size(100, 23);
            this.btnCargarFoto.TabIndex = 14;
            this.btnCargarFoto.Text = "Cargar Foto...";
            this.btnCargarFoto.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(14, 470);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Foto del Producto:";
            // 
            // numPrecioVenta
            // 
            this.numPrecioVenta.DecimalPlaces = 2;
            this.numPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numPrecioVenta.Location = new System.Drawing.Point(173, 370);
            this.numPrecioVenta.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numPrecioVenta.Name = "numPrecioVenta";
            this.numPrecioVenta.Size = new System.Drawing.Size(150, 25);
            this.numPrecioVenta.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(170, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Precio de Venta:";
            // 
            // numPrecioCosto
            // 
            this.numPrecioCosto.DecimalPlaces = 2;
            this.numPrecioCosto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numPrecioCosto.Location = new System.Drawing.Point(17, 370);
            this.numPrecioCosto.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numPrecioCosto.Name = "numPrecioCosto";
            this.numPrecioCosto.Size = new System.Drawing.Size(150, 25);
            this.numPrecioCosto.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(14, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Precio de Costo:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(17, 305);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(306, 25);
            this.cmbProveedor.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Proveedor:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(17, 245);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(306, 25);
            this.cmbCategoria.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(14, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Categoría:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDescripcion.Location = new System.Drawing.Point(17, 110);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(306, 100);
            this.txtDescripcion.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Descripción:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNombre.Location = new System.Drawing.Point(17, 50);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(306, 25);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNombre.Location = new System.Drawing.Point(14, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(142, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del Producto:";
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 521);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(350, 80);
            this.pnlBotones.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(233, 20);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 40);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(127, 20);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(21, 20);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 40);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // ProductosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlDetalles);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "ProductosForm";
            this.Text = "Gestión de Productos";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlDetalles.ResumeLayout(false);
            this.pnlDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMaximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStockMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioCosto)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPrecioCosto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPrecioVenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCargarFoto;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.NumericUpDown numStockMinimo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numStockMaximo;
        private System.Windows.Forms.Label label8;
    }
}