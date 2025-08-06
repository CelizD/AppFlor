using FlorApp.DataAccess;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FlorApp.DataAccess.Models;


namespace FlorApp.Presentation.Forms.Dialogs
{
    public partial class ClienteDisplayForm : Form
    {
        // --- Variables para mover el formulario sin bordes ---
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public ClienteDisplayForm()
        {
            InitializeComponent();
            ConfigurarDataGridView();

            // --- Habilitar movimiento del formulario ---
            // Se asocian los eventos del mouse del panel principal a los manejadores.
            pnlMain.MouseDown += new MouseEventHandler(pnlMain_MouseDown);
            pnlMain.MouseMove += new MouseEventHandler(pnlMain_MouseMove);
            pnlMain.MouseUp += new MouseEventHandler(pnlMain_MouseUp);
        }

        // --- MÉTODOS PARA MOVER EL FORMULARIO ---

        private void pnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void ConfigurarDataGridView()
        {
            dgvCarritoCliente.AutoGenerateColumns = false;
            dgvCarritoCliente.Columns.Clear();

            dgvCarritoCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                FillWeight = 50
            });
            dgvCarritoCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cant.",
                FillWeight = 15
            });
            dgvCarritoCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioUnitario",
                HeaderText = "Precio",
                DefaultCellStyle = { Format = "c" },
                FillWeight = 20
            });
            dgvCarritoCliente.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalLinea",
                HeaderText = "Total",
                DefaultCellStyle = { Format = "c" },
                FillWeight = 25
            });
        }

        public void ActualizarVista(BindingList<VentaDetalle> carrito, decimal total)
        {
            if (carrito.Any())
            {
                lblBienvenida.Visible = false;
                dgvCarritoCliente.Visible = true;
                dgvCarritoCliente.DataSource = carrito;
            }
            else
            {
                lblBienvenida.Visible = true;
                dgvCarritoCliente.Visible = false;
                dgvCarritoCliente.DataSource = null;
            }

            lblTotalValor.Text = total.ToString("C");
        }
    }
}
