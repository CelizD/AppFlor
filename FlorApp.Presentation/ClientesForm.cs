using FlorApp.DataAccess;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ClientesForm : Form
    {
        private readonly ClienteRepository _clienteRepository;
        private int? _idSeleccionado = null;

        // En el constructor de ClientesForm
        public ClientesForm()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _clienteRepository = new ClienteRepository(connectionString);

            this.Load += new EventHandler(ClientesForm_Load);
            dgvClientes.CellClick += new DataGridViewCellEventHandler(dgvClientes_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            cmbFiltroMembresia.SelectedIndexChanged += new EventHandler(cmbFiltroMembresia_SelectedIndexChanged);
            btnExportar.Click += new EventHandler(btnExportar_Click);
        }

        private async void ClientesForm_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
            await CargarClientesAsync();
            LimpiarCampos();
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                string filtro = cmbFiltroMembresia.SelectedItem?.ToString() ?? "Todos";
                var clientes = await _clienteRepository.ObtenerPorFiltroAsync(filtro);
                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void CargarComboBoxes()
        {
            cmbTipoMembresia.Items.Clear();
            cmbTipoMembresia.Items.Add("Estándar");
            cmbTipoMembresia.Items.Add("Plata");
            cmbTipoMembresia.Items.Add("Oro");

            cmbFiltroMembresia.Items.Clear();
            cmbFiltroMembresia.Items.Add("Todos");
            cmbFiltroMembresia.Items.Add("Estándar");
            cmbFiltroMembresia.Items.Add("Plata");
            cmbFiltroMembresia.Items.Add("Oro");
            cmbFiltroMembresia.SelectedIndex = 0;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cliente = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                if (cliente != null)
                {
                    _idSeleccionado = cliente.Id;
                    txtNombre.Text = cliente.Nombre;
                    txtTelefono.Text = cliente.Telefono;
                    txtEmail.Text = cliente.Email;
                    txtDireccion.Text = cliente.Direccion;

                    if (cliente.FechaEspecial.HasValue)
                    {
                        dtpFechaEspecial.Value = cliente.FechaEspecial.Value;
                    }
                    else
                    {
                        // Se puede asignar un valor por defecto si es nulo
                        dtpFechaEspecial.Value = DateTime.Now;
                    }

                    // Validar y asignar valores a NumericUpDown para evitar errores
                    if (cliente.TotalGastado >= numTotalGastado.Minimum && cliente.TotalGastado <= numTotalGastado.Maximum)
                    {
                        numTotalGastado.Value = cliente.TotalGastado;
                    }
                    else
                    {
                        numTotalGastado.Value = numTotalGastado.Minimum;
                    }

                    if (cliente.Puntos >= numPuntos.Minimum && cliente.Puntos <= numPuntos.Maximum)
                    {
                        numPuntos.Value = cliente.Puntos;
                    }
                    else
                    {
                        numPuntos.Value = numPuntos.Minimum;
                    }

                    cmbTipoMembresia.SelectedItem = cliente.TipoMembresia;
                }
            }
        }

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
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                CustomMessageBoxForm.Show("El nombre del cliente es obligatorio.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

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
                    await _clienteRepository.GuardarAsync(cliente);
                    CustomMessageBoxForm.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }
                else
                {
                    cliente.Id = _idSeleccionado.Value;
                    await _clienteRepository.ActualizarAsync(cliente);
                    CustomMessageBoxForm.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }

                await CargarClientesAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un cliente de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar Eliminación");

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await _clienteRepository.EliminarAsync(_idSeleccionado.Value);
                    CustomMessageBoxForm.Show("Cliente eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    await CargarClientesAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    CustomMessageBoxForm.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }

        private async void cmbFiltroMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CargarClientesAsync();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count == 0)
            {
                CustomMessageBoxForm.Show("No hay datos para exportar.", "Vacío", MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Archivo CSV|*.csv", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        var headers = dgvClientes.Columns.Cast<DataGridViewColumn>();
                        sb.AppendLine(string.Join(",", headers.Select(column => $"\"{column.HeaderText}\"")));

                        foreach (DataGridViewRow row in dgvClientes.Rows)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>();
                            sb.AppendLine(string.Join(",", cells.Select(cell => $"\"{cell.Value}\"")));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        CustomMessageBoxForm.Show("Datos exportados exitosamente.", "Éxito", MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBoxForm.Show($"Error al exportar los datos: {ex.Message}", "Error", MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
