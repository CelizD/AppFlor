using FlorApp.DataAccess;
using System;
using System.Configuration; // <-- AÑADIR ESTA LÍNEA
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ProveedoresForm : Form
    {
        private readonly ProveedorRepository _proveedorRepository;
        private int? _idSeleccionado = null;

        public ProveedoresForm()
        {
            InitializeComponent();

            // --- CORRECCIÓN APLICADA AQUÍ ---
            // 1. Leer la cadena de conexión en el formulario.
            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            // 2. Pasar la cadena de conexión al crear el repositorio.
            _proveedorRepository = new ProveedorRepository(connectionString);

            this.Load += new EventHandler(ProveedoresForm_Load);
            dgvProveedores.CellClick += new DataGridViewCellEventHandler(dgvProveedores_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        private async void ProveedoresForm_Load(object sender, EventArgs e)
        {
            await CargarProveedoresAsync();
            LimpiarCampos();
        }

        private async Task CargarProveedoresAsync()
        {
            try
            {
                var proveedores = await _proveedorRepository.ObtenerTodosAsync();
                dgvProveedores.DataSource = proveedores;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar los proveedores: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var proveedor = (Proveedor)dgvProveedores.Rows[e.RowIndex].DataBoundItem;
                if (proveedor != null)
                {
                    _idSeleccionado = proveedor.Id;
                    txtNombreEmpresa.Text = proveedor.NombreEmpresa;
                    txtNombreContacto.Text = proveedor.NombreContacto;
                    txtTelefono.Text = proveedor.Telefono;
                    txtEmail.Text = proveedor.Email;
                    txtDireccion.Text = proveedor.Direccion;
                }
            }
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = null;
            txtNombreEmpresa.Clear();
            txtNombreContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            dgvProveedores.ClearSelection();
            txtNombreEmpresa.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
            {
                CustomMessageBoxForm.Show("El nombre de la empresa es obligatorio.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var proveedor = new Proveedor
            {
                NombreEmpresa = txtNombreEmpresa.Text,
                NombreContacto = txtNombreContacto.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text
            };

            try
            {
                if (_idSeleccionado == null)
                {
                    await _proveedorRepository.GuardarAsync(proveedor);
                    CustomMessageBoxForm.Show("Proveedor guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }
                else
                {
                    proveedor.Id = _idSeleccionado.Value;
                    await _proveedorRepository.ActualizarAsync(proveedor);
                    CustomMessageBoxForm.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }

                await CargarProveedoresAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar el proveedor: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un proveedor de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmar Eliminación");

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await _proveedorRepository.EliminarAsync(_idSeleccionado.Value);
                    CustomMessageBoxForm.Show("Proveedor eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    await CargarProveedoresAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    CustomMessageBoxForm.Show($"Error al eliminar el proveedor: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }
    }
}
