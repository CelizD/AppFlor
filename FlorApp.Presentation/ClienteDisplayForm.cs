using FlorApp.DataAccess;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ClienteDisplayForm : Form
    {
        public ClienteDisplayForm()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            // Ocultar columnas innecesarias para el cliente
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

        /// <summary>
        /// Método público que el formulario de ventas llamará para actualizar esta pantalla.
        /// </summary>
        public void ActualizarVista(BindingList<VentaDetalle> carrito, decimal total)
        {
            // Mostrar u ocultar controles según si el carrito tiene items
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

            // Actualizar el total
            lblTotalValor.Text = total.ToString("C");
        }
    }
}
