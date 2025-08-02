namespace FlorApp.Presentation
{
    partial class KioscoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabCatalogo = new System.Windows.Forms.TabPage();
            this.flpCatalogo = new System.Windows.Forms.FlowLayoutPanel();
            this.tabCreaTuArreglo = new System.Windows.Forms.TabPage();
            this.btnAgregarArregloPersonalizado = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flpExtras = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbEnvoltura = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flpFlores = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.btnEliminarDelCarrito = new System.Windows.Forms.Button();
            this.btnFinalizarPedido = new System.Windows.Forms.Button();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlPrincipal.SuspendLayout();
            this.tabCatalogo.SuspendLayout();
            this.tabCreaTuArreglo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.pnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
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
            this.lblHeader.Size = new System.Drawing.Size(349, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "FlorApp Kiosco - Arma tu Pedido";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.splitContainer1.Panel1.Controls.Add(this.tabControlPrincipal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.dgvCarrito);
            this.splitContainer1.Panel2.Controls.Add(this.pnlTotal);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 701);
            this.splitContainer1.SplitterDistance = 750;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControlPrincipal
            // 
            this.tabControlPrincipal.Controls.Add(this.tabCatalogo);
            this.tabControlPrincipal.Controls.Add(this.tabCreaTuArreglo);
            this.tabControlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.tabControlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabControlPrincipal.Name = "tabControlPrincipal";
            this.tabControlPrincipal.SelectedIndex = 0;
            this.tabControlPrincipal.Size = new System.Drawing.Size(750, 701);
            this.tabControlPrincipal.TabIndex = 0;
            // 
            // tabCatalogo
            // 
            this.tabCatalogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.tabCatalogo.Controls.Add(this.flpCatalogo);
            this.tabCatalogo.Location = new System.Drawing.Point(4, 30);
            this.tabCatalogo.Name = "tabCatalogo";
            this.tabCatalogo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCatalogo.Size = new System.Drawing.Size(742, 667);
            this.tabCatalogo.TabIndex = 0;
            this.tabCatalogo.Text = "Catálogo de Arreglos";
            // 
            // flpCatalogo
            // 
            this.flpCatalogo.AutoScroll = true;
            this.flpCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCatalogo.Location = new System.Drawing.Point(3, 3);
            this.flpCatalogo.Name = "flpCatalogo";
            this.flpCatalogo.Padding = new System.Windows.Forms.Padding(10);
            this.flpCatalogo.Size = new System.Drawing.Size(736, 661);
            this.flpCatalogo.TabIndex = 0;
            // 
            // tabCreaTuArreglo
            // 
            this.tabCreaTuArreglo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.tabCreaTuArreglo.Controls.Add(this.btnAgregarArregloPersonalizado);
            this.tabCreaTuArreglo.Controls.Add(this.groupBox3);
            this.tabCreaTuArreglo.Controls.Add(this.groupBox2);
            this.tabCreaTuArreglo.Controls.Add(this.groupBox1);
            this.tabCreaTuArreglo.Location = new System.Drawing.Point(4, 30);
            this.tabCreaTuArreglo.Name = "tabCreaTuArreglo";
            this.tabCreaTuArreglo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreaTuArreglo.Size = new System.Drawing.Size(742, 667);
            this.tabCreaTuArreglo.TabIndex = 1;
            this.tabCreaTuArreglo.Text = "Crea tu Propio Arreglo";
            // 
            // btnAgregarArregloPersonalizado
            // 
            this.btnAgregarArregloPersonalizado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarArregloPersonalizado.FlatAppearance.BorderSize = 0;
            this.btnAgregarArregloPersonalizado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarArregloPersonalizado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAgregarArregloPersonalizado.ForeColor = System.Drawing.Color.White;
            this.btnAgregarArregloPersonalizado.Location = new System.Drawing.Point(23, 599);
            this.btnAgregarArregloPersonalizado.Name = "btnAgregarArregloPersonalizado";
            this.btnAgregarArregloPersonalizado.Size = new System.Drawing.Size(694, 60);
            this.btnAgregarArregloPersonalizado.TabIndex = 3;
            this.btnAgregarArregloPersonalizado.Text = "Agregar Arreglo Personalizado al Carrito";
            this.btnAgregarArregloPersonalizado.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.flpExtras);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(23, 445);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 137);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Paso 3: Añade un Extra";
            // 
            // flpExtras
            // 
            this.flpExtras.AutoScroll = true;
            this.flpExtras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpExtras.Location = new System.Drawing.Point(3, 25);
            this.flpExtras.Name = "flpExtras";
            this.flpExtras.Size = new System.Drawing.Size(688, 109);
            this.flpExtras.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbEnvoltura);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(23, 345);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 90);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paso 2: Elige la Envoltura";
            // 
            // cmbEnvoltura
            // 
            this.cmbEnvoltura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEnvoltura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnvoltura.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbEnvoltura.FormattingEnabled = true;
            this.cmbEnvoltura.Location = new System.Drawing.Point(17, 39);
            this.cmbEnvoltura.Name = "cmbEnvoltura";
            this.cmbEnvoltura.Size = new System.Drawing.Size(660, 29);
            this.cmbEnvoltura.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.flpFlores);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(23, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 315);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paso 1: Elige tus Flores";
            // 
            // flpFlores
            // 
            this.flpFlores.AutoScroll = true;
            this.flpFlores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFlores.Location = new System.Drawing.Point(3, 25);
            this.flpFlores.Name = "flpFlores";
            this.flpFlores.Size = new System.Drawing.Size(688, 287);
            this.flpFlores.TabIndex = 0;
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.AllowUserToResizeRows = false;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCarrito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCarrito.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCarrito.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.EnableHeadersVisualStyles = false;
            this.dgvCarrito.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.dgvCarrito.Location = new System.Drawing.Point(0, 0);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarrito.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(430, 561);
            this.dgvCarrito.TabIndex = 1;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.White;
            this.pnlTotal.Controls.Add(this.btnEliminarDelCarrito);
            this.pnlTotal.Controls.Add(this.btnFinalizarPedido);
            this.pnlTotal.Controls.Add(this.lblTotalValor);
            this.pnlTotal.Controls.Add(this.lblTotalTitulo);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotal.Location = new System.Drawing.Point(0, 561);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(430, 140);
            this.pnlTotal.TabIndex = 0;
            // 
            // btnEliminarDelCarrito
            // 
            this.btnEliminarDelCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarDelCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnEliminarDelCarrito.FlatAppearance.BorderSize = 0;
            this.btnEliminarDelCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDelCarrito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDelCarrito.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDelCarrito.Location = new System.Drawing.Point(20, 48);
            this.btnEliminarDelCarrito.Name = "btnEliminarDelCarrito";
            this.btnEliminarDelCarrito.Size = new System.Drawing.Size(390, 40);
            this.btnEliminarDelCarrito.TabIndex = 3;
            this.btnEliminarDelCarrito.Text = "Eliminar Producto Seleccionado";
            this.btnEliminarDelCarrito.UseVisualStyleBackColor = false;
            // 
            // btnFinalizarPedido
            // 
            this.btnFinalizarPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizarPedido.FlatAppearance.BorderSize = 0;
            this.btnFinalizarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarPedido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFinalizarPedido.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarPedido.Location = new System.Drawing.Point(20, 94);
            this.btnFinalizarPedido.Name = "btnFinalizarPedido";
            this.btnFinalizarPedido.Size = new System.Drawing.Size(390, 40);
            this.btnFinalizarPedido.TabIndex = 2;
            this.btnFinalizarPedido.Text = "Finalizar Pedido";
            this.btnFinalizarPedido.UseVisualStyleBackColor = false;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.lblTotalValor.Location = new System.Drawing.Point(210, 15);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(200, 25);
            this.lblTotalValor.TabIndex = 1;
            this.lblTotalValor.Text = "$0.00";
            this.lblTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(64, 25);
            this.lblTotalTitulo.TabIndex = 0;
            this.lblTotalTitulo.Text = "Total:";
            // 
            // KioscoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "KioscoForm";
            this.Text = "Kiosco de Autoservicio";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlPrincipal.ResumeLayout(false);
            this.tabCatalogo.ResumeLayout(false);
            this.tabCreaTuArreglo.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlPrincipal;
        private System.Windows.Forms.TabPage tabCatalogo;
        private System.Windows.Forms.TabPage tabCreaTuArreglo;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Button btnFinalizarPedido;
        private System.Windows.Forms.FlowLayoutPanel flpCatalogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flpFlores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbEnvoltura;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAgregarArregloPersonalizado;
        private System.Windows.Forms.FlowLayoutPanel flpExtras;
        private System.Windows.Forms.Button btnEliminarDelCarrito;
    }
}