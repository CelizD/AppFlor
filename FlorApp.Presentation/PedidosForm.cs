using FlorApp.DataAccess;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class PedidosForm : Form
    {
        private readonly PedidoRepository _pedidoRepository;
        private int? _idSeleccionado = null;

        public PedidosForm()
        {
            InitializeComponent();
            _pedidoRepository = new PedidoRepository();
            this.Load += new EventHandler(PedidosForm_Load);
            dgvPedidos.CellClick += new DataGridViewCellEventHandler(dgvPedidos_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        private async void PedidosForm_Load(object sender, EventArgs e)
        {
            await CargarPedidosAsync();
            CargarComboBoxes();
            LimpiarCampos();
        }

        private async Task CargarPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoRepository.ObtenerTodosAsync();
                dgvPedidos.DataSource = pedidos;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void CargarComboBoxes()
        {
            // En un futuro, estos podrían venir de las tablas de Clientes y Empleados
            cmbCliente.Items.Clear();
            cmbCliente.Items.Add("Ana Torres");
            cmbCliente.Items.Add("Luis Morales");
            cmbCliente.Items.Add("Cliente Ocasional");

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Recibido");
            cmbEstado.Items.Add("En preparación");
            cmbEstado.Items.Add("En ruta");
            cmbEstado.Items.Add("Entregado");
            cmbEstado.Items.Add("Cancelado");

            cmbRepartidor.Items.Clear();
            cmbRepartidor.Items.Add("Juan Rodríguez");
            cmbRepartidor.Items.Add("Pedro Gómez");
            cmbRepartidor.Items.Add("N/A");
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var pedido = (Pedido)dgvPedidos.Rows[e.RowIndex].DataBoundItem;
                if (pedido != null)
                {
                    _idSeleccionado = pedido.Id;
                    cmbCliente.Text = pedido.NombreCliente;
                    txtProductos.Text = pedido.Productos;
                    txtMensaje.Text = pedido.MensajeTarjeta;
                    txtDireccion.Text = pedido.DireccionEntrega;
                    dtpFechaEntrega.Value = pedido.FechaEntrega;
                    cmbEstado.SelectedItem = pedido.Estado;
                    cmbRepartidor.SelectedItem = pedido.RepartidorAsignado;
                }
            }
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = null;
            cmbCliente.Text = "";
            txtProductos.Clear();
            txtMensaje.Clear();
            txtDireccion.Clear();
            dtpFechaEntrega.Value = DateTime.Now;
            cmbEstado.SelectedIndex = -1;
            cmbRepartidor.SelectedIndex = -1;
            dgvPedidos.ClearSelection();
            cmbCliente.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCliente.Text) || string.IsNullOrWhiteSpace(txtProductos.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                CustomMessageBoxForm.Show("Cliente, Productos y Dirección son campos obligatorios.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var pedido = new Pedido
            {
                NombreCliente = cmbCliente.Text,
                Productos = txtProductos.Text,
                MensajeTarjeta = txtMensaje.Text,
                DireccionEntrega = txtDireccion.Text,
                FechaEntrega = dtpFechaEntrega.Value,
                Estado = cmbEstado.Text,
                RepartidorAsignado = cmbRepartidor.Text
            };

            try
            {
                if (_idSeleccionado == null) // Es un nuevo pedido
                {
                    await _pedidoRepository.GuardarAsync(pedido);
                    CustomMessageBoxForm.Show("Pedido guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }
                else // Estamos actualizando un pedido existente
                {
                    pedido.Id = _idSeleccionado.Value;
                    await _pedidoRepository.ActualizarAsync(pedido);
                    CustomMessageBoxForm.Show("Pedido actualizado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }

                await CargarPedidosAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar el pedido: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un pedido de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este pedido?", "Confirmar Eliminación");

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await _pedidoRepository.EliminarAsync(_idSeleccionado.Value);
                    CustomMessageBoxForm.Show("Pedido eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    await CargarPedidosAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    CustomMessageBoxForm.Show($"Error al eliminar el pedido: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }
    }
}
