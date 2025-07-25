using FlorApp.DataAccess;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ClientesForm : Form
    {
        // Repositorio para acceder a datos de clientes
        private readonly ClienteRepository _clienteRepository;
        // Id del cliente seleccionado en la grilla (nullable)
        private int? _idSeleccionado = null;

        // Constructor
        public ClientesForm()
        {
            InitializeComponent();

            // Instancia el repositorio
            _clienteRepository = new ClienteRepository();

            // Suscribe eventos
            this.Load += new EventHandler(ClientesForm_Load);
            dgvClientes.CellClick += new DataGridViewCellEventHandler(dgvClientes_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        // Evento al cargar el formulario
        private async void ClientesForm_Load(object sender, EventArgs e)
        {
            await CargarClientesAsync(); // Carga la lista de clientes en el DataGridView
            CargarComboBoxes();          // Llena los combos con opciones
            LimpiarCampos();             // Limpia campos y resetea controles
        }

        // Carga la lista de clientes desde la base de datos y la muestra
        private async Task CargarClientesAsync()
        {
            try
            {
                var clientes = await _clienteRepository.ObtenerTodosAsync();
                dgvClientes.DataSource = clientes; // Vincula la lista al DataGridView
            }
            catch (Exception ex)
            {
                // Muestra mensaje de error personalizado
                CustomMessageBoxForm.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Llena los combobox con los tipos de membresía disponibles
        private void CargarComboBoxes()
        {
            cmbTipoMembresia.Items.Clear();
            cmbTipoMembresia.Items.Add("Estándar");
            cmbTipoMembresia.Items.Add("Plata");
            cmbTipoMembresia.Items.Add("Oro");
        }

        // Evento al hacer clic en una celda del DataGridView
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Evitar clicks en encabezados u otras áreas
            {
                var cliente = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                if (cliente != null)
                {
                    _idSeleccionado = cliente.Id; // Guarda el Id del cliente seleccionado

                    // Llena los controles con los datos del cliente
                    txtNombre.Text = cliente.Nombre;
                    txtTelefono.Text = cliente.Telefono;
                    txtEmail.Text = cliente.Email;
                    txtDireccion.Text = cliente.Direccion;
                    if (cliente.FechaEspecial.HasValue)
                    {
                        dtpFechaEspecial.Value = cliente.FechaEspecial.Value;
                    }
                    cmbTipoMembresia.SelectedItem = cliente.TipoMembresia;
                    numTotalGastado.Value = cliente.TotalGastado;
                    numPuntos.Value = cliente.Puntos;
                }
            }
        }

        // Limpia los campos del formulario y resetea controles
        private void LimpiarCampos()
        {
            _idSeleccionado = null;
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            dtpFechaEspecial.Value = DateTime.Now;
            cmbTipoMembresia.SelectedIndex = -1;
            numTotalGastado.Value = 0;
            numPuntos.Value = 0;
            dgvClientes.ClearSelection();
            txtNombre.Focus(); // Pone foco en el campo de nombre
        }

        // Evento para el botón Nuevo, limpia campos para ingresar nuevo cliente
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Evento para el botón Guardar, guarda o actualiza cliente en BD
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación simple: nombre obligatorio
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                CustomMessageBoxForm.Show("El nombre del cliente es obligatorio.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            // Crea un objeto Cliente con datos del formulario
            var cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text,
                FechaEspecial = dtpFechaEspecial.Value,
                TipoMembresia = cmbTipoMembresia.Text ?? "Estándar",
                TotalGastado = numTotalGastado.Value,
                Puntos = (int)numPuntos.Value
            };

            try
            {
                if (_idSeleccionado == null)
                {
                    // Guarda nuevo cliente
                    await _clienteRepository.GuardarAsync(cliente);
                    CustomMessageBoxForm.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }
                else
                {
                    // Actualiza cliente existente
                    cliente.Id = _idSeleccionado.Value;
                    await _clienteRepository.ActualizarAsync(cliente);
                    CustomMessageBoxForm.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }

                // Recarga la lista y limpia formulario
                await CargarClientesAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Evento para botón Eliminar, elimina cliente seleccionado tras confirmación
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un cliente de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            // Muestra cuadro de confirmación personalizado
            var confirmacion = CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar Eliminación");

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Elimina cliente por Id
                    await _clienteRepository.EliminarAsync(_idSeleccionado.Value);
                    CustomMessageBoxForm.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    // Actualiza la lista y limpia campos
                    await CargarClientesAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    CustomMessageBoxForm.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }
    }
}
