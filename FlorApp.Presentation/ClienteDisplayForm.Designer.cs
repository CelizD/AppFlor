namespace FlorApp.Presentation
{
    partial class ClienteDisplayForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTotalContainer = new System.Windows.Forms.Panel();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalTitulo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvCarritoCliente = new System.Windows.Forms.DataGridView();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlTotalContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlMain.Size = new System.Drawing.Size(1067, 554);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTotalContainer);
            this.pnlRight.Controls.Add(this.picLogo);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(653, 25);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(387, 504);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlTotalContainer
            // 
            this.pnlTotalContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlTotalContainer.Controls.Add(this.lblTotalValor);
            this.pnlTotalContainer.Controls.Add(this.lblTotalTitulo);
            this.pnlTotalContainer.Location = new System.Drawing.Point(0, 357);
            this.pnlTotalContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTotalContainer.Name = "pnlTotalContainer";
            this.pnlTotalContainer.Size = new System.Drawing.Size(387, 148);
            this.pnlTotalContainer.TabIndex = 0;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValor.ForeColor = System.Drawing.Color.White;
            this.lblTotalValor.Location = new System.Drawing.Point(0, 69);
            this.lblTotalValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(387, 79);
            this.lblTotalValor.TabIndex = 1;
            this.lblTotalValor.Text = "$0.00";
            this.lblTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalTitulo
            // 
            this.lblTotalTitulo.AutoSize = true;
            this.lblTotalTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitulo.ForeColor = System.Drawing.Color.LightGray;
            this.lblTotalTitulo.Location = new System.Drawing.Point(155, 24);
            this.lblTotalTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalTitulo.Name = "lblTotalTitulo";
            this.lblTotalTitulo.Size = new System.Drawing.Size(73, 32);
            this.lblTotalTitulo.TabIndex = 0;
            this.lblTotalTitulo.Text = "Total:";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::FlorApp.Presentation.Properties.Resources.AppFlor;
            this.picLogo.Location = new System.Drawing.Point(96, 25);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 185);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlLeft.Controls.Add(this.dgvCarritoCliente);
            this.pnlLeft.Controls.Add(this.lblProductsTitle);
            this.pnlLeft.Controls.Add(this.lblBienvenida);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(27, 25);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlLeft.Size = new System.Drawing.Size(626, 504);
            this.pnlLeft.TabIndex = 0;
            // 
            // dgvCarritoCliente
            // 
            this.dgvCarritoCliente.AllowUserToAddRows = false;
            this.dgvCarritoCliente.AllowUserToDeleteRows = false;
            this.dgvCarritoCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarritoCliente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvCarritoCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCarritoCliente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCarritoCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarritoCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCarritoCliente.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCarritoCliente.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCarritoCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarritoCliente.EnableHeadersVisualStyles = false;
            this.dgvCarritoCliente.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.dgvCarritoCliente.Location = new System.Drawing.Point(27, 75);
            this.dgvCarritoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCarritoCliente.Name = "dgvCarritoCliente";
            this.dgvCarritoCliente.ReadOnly = true;
            this.dgvCarritoCliente.RowHeadersVisible = false;
            this.dgvCarritoCliente.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dgvCarritoCliente.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCarritoCliente.RowTemplate.Height = 40;
            this.dgvCarritoCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarritoCliente.Size = new System.Drawing.Size(572, 404);
            this.dgvCarritoCliente.TabIndex = 1;
            // 
            // lblProductsTitle
            // 
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsTitle.ForeColor = System.Drawing.Color.White;
            this.lblProductsTitle.Location = new System.Drawing.Point(27, 25);
            this.lblProductsTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Size = new System.Drawing.Size(199, 50);
            this.lblProductsTitle.TabIndex = 0;
            this.lblProductsTitle.Text = "Productos";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblBienvenida.Location = new System.Drawing.Point(27, 25);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(572, 454);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "¡Bienvenido!";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClienteDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClienteDisplayForm";
            this.Text = "ClienteDisplayForm";
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlTotalContainer.ResumeLayout(false);
            this.pnlTotalContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarritoCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.DataGridView dgvCarritoCliente;
        private System.Windows.Forms.Panel pnlTotalContainer;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label lblTotalTitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.PictureBox picLogo;
    }
}
