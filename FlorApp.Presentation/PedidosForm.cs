using FlorApp.DataAccess;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class PedidosForm : Form
    {
        // Repositorio para manejar operaciones de pedidos
        private readonly PedidoRepository _pedidoRepository;

        // Guarda el Id del pedido seleccionado, o null si no hay selección
        private int? _idSeleccionado = null;

        public PedidosForm()
        {
            InitializeComponent();

            // Instanciar el repositorio
            _pedidoRepository = new PedidoRepository();

            // Asociar eventos a controles y formulario
            this.Load += new EventHandler(PedidosForm_Load);
            dgvPedidos.CellClick += new DataGridViewCellEventHandler(dgvPedidos_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        // Se ejecuta al cargar el formulario
        private async void PedidosForm_Load(object sender, EventArgs e)
        {
            // Cargar los pedidos de la base de datos y mostrarlos
            await CargarPedidosAsync();

            // Llenar combos con datos iniciales
            CargarComboBoxes();

            // Limpiar los campos del formulario para nuevo ingreso
            LimpiarCampos();
        }

        // Obtiene y muestra todos los pedidos en el DataGridView
        private async Task CargarPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoRepository.ObtenerTodosAsync();
                dgvPedidos.DataSource = pedidos;
            }
            catch (Exception ex)
            {
                // Mostrar error si falla la carga
                CustomMessageBoxForm.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Llena los ComboBox con opciones estáticas
        private void CargarComboBoxes()
        {
            // Limpiar y agregar clientes de ejemplo
            cmbCliente.Items.Clear();
            cmbCliente.Items.Add("Ana Torres");
            cmbCliente.Items.Add("Luis Morales");
            cmbCliente.Items.Add("Cliente Ocasional");

            // Limpiar y agregar estados posibles
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Recibido");
            cmbEstado.Items.Add("En preparación");
            cmbEstado.Items.Add("En ruta");
            cmbEstado.Items.Add("Entregado");
            cmbEstado.Items.Add("Cancelado");

            // Limpiar y agregar repartidores de ejemplo
            cmbRepartidor.Items.Clear();
            cmbRepartidor.Items.Add("Juan Rodríguez");
            cmbRepartidor.Items.Add("Pedro Gómez");
            cmbRepartidor.Items.Add("N/A");
        }

        // Evento que se ejecuta al hacer clic en una fila del DataGridView
        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Validar fila válida
            {
                // Obtener el pedido asociado a la fila seleccionada
                var pedido = (Pedido)dgvPedidos.Rows[e.RowIndex].DataBoundItem;

                if (pedido != null)
                {
                    // Guardar el Id del pedido seleccionado
                    _idSeleccionado = pedido.Id;

                    // Mostrar los datos del pedido en los controles correspondientes
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

        // Limpia todos los campos y prepara el formulario para un nuevo pedido
        private void LimpiarCampos()
        {
            _idSeleccionado = null; // Quitar selección

            cmbCliente.Text = "";   // Limpiar cliente
            txtProductos.Clear();   // Limpiar productos
            txtMensaje.Clear();     // Limpiar mensaje
            txtDireccion.Clear();   // Limpiar dirección

            dtpFechaEntrega.Value = DateTime.Now; // Fecha actual

            cmbEstado.SelectedIndex = -1;      // Deseleccionar estado
            cmbRepartidor.SelectedIndex = -1;  // Deseleccionar repartidor

            dgvPedidos.ClearSelection(); // Deseleccionar filas en la tabla

            cmbCliente.Focus(); // Poner foco en cliente para entrada rápida
        }

        // Prepara el formulario para un nuevo pedido
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Guarda un nuevo pedido o actualiza uno existente
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(cmbCliente.Text) ||
                string.IsNullOrWhiteSpace(txtProductos.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                CustomMessageBoxForm.Show("Cliente, Productos y Dirección son campos obligatorios.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto pedido con datos ingresados
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
                if (_idSeleccionado == null)
                {
                    // Guardar nuevo pedido si no hay selección
                    await _pedidoRepository.GuardarAsync(pedido);
                    CustomMessageBoxForm.Show("Pedido guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }
                else
                {
                    // Actualizar pedido existente con Id seleccionado
                    pedido.Id = _idSeleccionado.Value;
                    await _pedidoRepository.ActualizarAsync(pedido);
                    CustomMessageBoxForm.Show("Pedido actualizado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }

                // Recargar lista y limpiar formulario tras guardar
                await CargarPedidosAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si falla guardar o actualizar
                CustomMessageBoxForm.Show($"Error al guardar el pedido: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Elimina el pedido seleccionado
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que hay un pedido seleccionado para eliminar
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un pedido de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            // Confirmar con el usuario antes de eliminar
            var confirmacion = CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este pedido?", "Confirmar Eliminación");

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Eliminar pedido y mostrar mensaje de éxito
                    await _pedidoRepository.EliminarAsync(_idSeleccionado.Value);
                    CustomMessageBoxForm.Show("Pedido eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    // Recargar lista y limpiar formulario
                    await CargarPedidosAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    // Mostrar error si falla eliminación
                    CustomMessageBoxForm.Show($"Error al eliminar el pedido: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }
    }
}
