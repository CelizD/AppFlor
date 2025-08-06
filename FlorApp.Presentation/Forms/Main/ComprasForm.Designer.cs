namespace FlorApp.Presentation.Forms.Main
{
    partial class ComprasForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRecibirMercancia = new System.Windows.Forms.Button();
            this.btnNuevaOrden = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.pnlDetalles = new System.Windows.Forms.Panel();
            this.pnlNuevaOrden = new System.Windows.Forms.Panel();
            this.btnGuardarOrden = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetallesOrden = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.pnlDetalles.SuspendLayout();
            this.pnlNuevaOrden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1184, 60);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(12, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(325, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Módulo de Compras a Proveedores";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRecibirMercancia);
            this.splitContainer1.Panel1.Controls.Add(this.btnNuevaOrden);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvOrdenes);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlDetalles);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 501);
            this.splitContainer1.SplitterDistance = 650;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnRecibirMercancia
            // 
            this.btnRecibirMercancia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecibirMercancia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRecibirMercancia.FlatAppearance.BorderSize = 0;
            this.btnRecibirMercancia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibirMercancia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRecibirMercancia.ForeColor = System.Drawing.Color.White;
            this.btnRecibirMercancia.Location = new System.Drawing.Point(467, 448);
            this.btnRecibirMercancia.Name = "btnRecibirMercancia";
            this.btnRecibirMercancia.Size = new System.Drawing.Size(170, 40);
            this.btnRecibirMercancia.TabIndex = 3;
            this.btnRecibirMercancia.Text = "Recibir Mercancía";
            this.btnRecibirMercancia.UseVisualStyleBackColor = false;
            // 
            // btnNuevaOrden
            // 
            this.btnNuevaOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevaOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNuevaOrden.FlatAppearance.BorderSize = 0;
            this.btnNuevaOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaOrden.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNuevaOrden.ForeColor = System.Drawing.Color.White;
            this.btnNuevaOrden.Location = new System.Drawing.Point(13, 448);
            this.btnNuevaOrden.Name = "btnNuevaOrden";
            this.btnNuevaOrden.Size = new System.Drawing.Size(170, 40);
            this.btnNuevaOrden.TabIndex = 2;
            this.btnNuevaOrden.Text = "Crear Nueva Orden";
            this.btnNuevaOrden.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Historial de Órdenes de Compra";
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdenes.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(10, 40);
            this.dgvOrdenes.MultiSelect = false;
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenes.Size = new System.Drawing.Size(630, 400);
            this.dgvOrdenes.TabIndex = 0;
            // 
            // pnlDetalles
            // 
            this.pnlDetalles.Controls.Add(this.pnlNuevaOrden);
            this.pnlDetalles.Controls.Add(this.dgvDetallesOrden);
            this.pnlDetalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalles.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalles.Name = "pnlDetalles";
            this.pnlDetalles.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDetalles.Size = new System.Drawing.Size(530, 501);
            this.pnlDetalles.TabIndex = 0;
            // 
            // pnlNuevaOrden
            // 
            this.pnlNuevaOrden.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlNuevaOrden.Controls.Add(this.btnGuardarOrden);
            this.pnlNuevaOrden.Controls.Add(this.btnAgregarProducto);
            this.pnlNuevaOrden.Controls.Add(this.numCantidad);
            this.pnlNuevaOrden.Controls.Add(this.label4);
            this.pnlNuevaOrden.Controls.Add(this.cmbProducto);
            this.pnlNuevaOrden.Controls.Add(this.label3);
            this.pnlNuevaOrden.Controls.Add(this.cmbProveedor);
            this.pnlNuevaOrden.Controls.Add(this.label2);
            this.pnlNuevaOrden.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNuevaOrden.Location = new System.Drawing.Point(10, 291);
            this.pnlNuevaOrden.Name = "pnlNuevaOrden";
            this.pnlNuevaOrden.Size = new System.Drawing.Size(510, 200);
            this.pnlNuevaOrden.TabIndex = 1;
            // 
            // btnGuardarOrden
            // 
            this.btnGuardarOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardarOrden.FlatAppearance.BorderSize = 0;
            this.btnGuardarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarOrden.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardarOrden.ForeColor = System.Drawing.Color.White;
            this.btnGuardarOrden.Location = new System.Drawing.Point(340, 140);
            this.btnGuardarOrden.Name = "btnGuardarOrden";
            this.btnGuardarOrden.Size = new System.Drawing.Size(150, 40);
            this.btnGuardarOrden.TabIndex = 7;
            this.btnGuardarOrden.Text = "Guardar Orden";
            this.btnGuardarOrden.UseVisualStyleBackColor = false;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnAgregarProducto.FlatAppearance.BorderSize = 0;
            this.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.Location = new System.Drawing.Point(340, 80);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(150, 30);
            this.btnAgregarProducto.TabIndex = 6;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numCantidad.Location = new System.Drawing.Point(20, 150);
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(120, 29);
            this.numCantidad.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(17, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(20, 80);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(300, 29);
            this.cmbProducto.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(17, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Producto:";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(20, 25);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(300, 29);
            this.cmbProveedor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(17, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proveedor:";
            // 
            // dgvDetallesOrden
            // 
            this.dgvDetallesOrden.AllowUserToAddRows = false;
            this.dgvDetallesOrden.AllowUserToDeleteRows = false;
            this.dgvDetallesOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetallesOrden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesOrden.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetallesOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesOrden.Location = new System.Drawing.Point(10, 10);
            this.dgvDetallesOrden.Name = "dgvDetallesOrden";
            this.dgvDetallesOrden.ReadOnly = true;
            this.dgvDetallesOrden.Size = new System.Drawing.Size(510, 275);
            this.dgvDetallesOrden.TabIndex = 0;
            // 
            // ComprasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "ComprasForm";
            this.Text = "Módulo de Compras";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.pnlDetalles.ResumeLayout(false);
            this.pnlNuevaOrden.ResumeLayout(false);
            this.pnlNuevaOrden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesOrden)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecibirMercancia;
        private System.Windows.Forms.Button btnNuevaOrden;
        private System.Windows.Forms.Panel pnlDetalles;
        private System.Windows.Forms.DataGridView dgvDetallesOrden;
        private System.Windows.Forms.Panel pnlNuevaOrden;
        private System.Windows.Forms.Button btnGuardarOrden;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label2;
    }
}
