using FlorApp.DataAccess;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ProveedoresForm : Form
    {
        // Repositorio para acceder a datos de proveedores
        private readonly ProveedorRepository _proveedorRepository;

        // Id del proveedor actualmente seleccionado (null si ninguno)
        private int? _idSeleccionado = null;

        public ProveedoresForm()
        {
            InitializeComponent();

            // Instanciar repositorio de proveedores
            _proveedorRepository = new ProveedorRepository();

            // Registrar manejadores de eventos para carga y controles
            this.Load += new EventHandler(ProveedoresForm_Load);
            dgvProveedores.CellClick += new DataGridViewCellEventHandler(dgvProveedores_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        // Evento que se ejecuta al cargar el formulario
        private async void ProveedoresForm_Load(object sender, EventArgs e)
        {
            // Cargar la lista de proveedores en el DataGridView
            await CargarProveedoresAsync();

            // Limpiar campos para nuevo registro
            LimpiarCampos();
        }

        // Método para obtener proveedores y asignarlos a la tabla
        private async Task CargarProveedoresAsync()
        {
            try
            {
                // Obtener todos los proveedores desde el repositorio (async)
                var proveedores = await _proveedorRepository.ObtenerTodosAsync();

                // Asignar la lista obtenida al DataGridView para mostrar
                dgvProveedores.DataSource = proveedores;
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre una excepción
                CustomMessageBoxForm.Show($"Error al cargar los proveedores: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Evento que se ejecuta al seleccionar una fila en la tabla
        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que el índice de fila sea válido (no cabecera)
            if (e.RowIndex >= 0)
            {
                // Obtener el proveedor correspondiente a la fila seleccionada
                var proveedor = (Proveedor)dgvProveedores.Rows[e.RowIndex].DataBoundItem;

                if (proveedor != null)
                {
                    // Guardar el Id para futuras operaciones (editar, eliminar)
                    _idSeleccionado = proveedor.Id;

                    // Mostrar datos del proveedor en los campos de texto
                    txtNombreEmpresa.Text = proveedor.NombreEmpresa;
                    txtNombreContacto.Text = proveedor.NombreContacto;
                    txtTelefono.Text = proveedor.Telefono;
                    txtEmail.Text = proveedor.Email;
                    txtDireccion.Text = proveedor.Direccion;
                }
            }
        }

        // Limpia los campos del formulario para crear un nuevo registro
        private void LimpiarCampos()
        {
            _idSeleccionado = null; // No hay proveedor seleccionado
            txtNombreEmpresa.Clear();
            txtNombreContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();

            // Quitar selección de la tabla
            dgvProveedores.ClearSelection();

            // Poner el foco en el campo nombre empresa para agilizar captura
            txtNombreEmpresa.Focus();
        }

        // Evento que limpia campos para ingresar un nuevo proveedor
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Evento que guarda o actualiza un proveedor al hacer clic en Guardar
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que el nombre de empresa no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombreEmpresa.Text))
            {
                CustomMessageBoxForm.Show("El nombre de la empresa es obligatorio.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto proveedor con datos capturados en el formulario
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
                if (_idSeleccionado == null) // Si no hay proveedor seleccionado, es nuevo
                {
                    // Guardar nuevo proveedor en base de datos (async)
                    await _proveedorRepository.GuardarAsync(proveedor);

                    // Informar éxito al usuario
                    CustomMessageBoxForm.Show("Proveedor guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }
                else // Si hay Id seleccionado, actualizar proveedor existente
                {
                    proveedor.Id = _idSeleccionado.Value;

                    // Actualizar proveedor en base de datos (async)
                    await _proveedorRepository.ActualizarAsync(proveedor);

                    // Informar éxito al usuario
                    CustomMessageBoxForm.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }

                // Recargar la lista para mostrar cambios
                await CargarProveedoresAsync();

                // Limpiar campos para nuevo registro
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre excepción al guardar o actualizar
                CustomMessageBoxForm.Show($"Error al guardar el proveedor: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Evento que elimina un proveedor seleccionado al hacer clic en Eliminar
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya un proveedor seleccionado para eliminar
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un proveedor de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            // Mostrar cuadro de confirmación antes de eliminar
            var confirmacion = CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmar Eliminación");

            // Si el usuario confirma, proceder con la eliminación
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Eliminar proveedor de la base de datos (async)
                    await _proveedorRepository.EliminarAsync(_idSeleccionado.Value);

                    // Informar éxito al usuario
                    CustomMessageBoxForm.Show("Proveedor eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    // Recargar lista para reflejar cambios
                    await CargarProveedoresAsync();

                    // Limpiar campos para nuevo registro
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    // Mostrar mensaje de error si falla la eliminación
                    CustomMessageBoxForm.Show($"Error al eliminar el proveedor: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }
    }
}
