using FlorApp.DataAccess;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ProductosForm : Form
    {
        // Repositorio para manejar operaciones sobre productos
        private readonly ProductoRepository _productoRepository;

        // Guarda el Id del producto seleccionado, o null si no hay selección
        private int? _idSeleccionado = null;

        public ProductosForm()
        {
            InitializeComponent();

            // Instanciar repositorio para acceder a datos de productos
            _productoRepository = new ProductoRepository();

            // Asociar eventos a controles y formulario
            this.Load += new EventHandler(ProductosForm_Load);
            dgvProductos.CellClick += new DataGridViewCellEventHandler(dgvProductos_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        // Se ejecuta al cargar el formulario
        private async void ProductosForm_Load(object sender, EventArgs e)
        {
            // Cargar y mostrar productos existentes
            await CargarProductosAsync();

            // Cargar datos en los ComboBoxes
            CargarComboBoxes();

            // Limpiar campos para ingreso nuevo
            LimpiarCampos();
        }

        // Carga productos desde la base de datos y los muestra en el DataGridView
        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await _productoRepository.ObtenerTodosAsync();
                dgvProductos.DataSource = productos;
            }
            catch (Exception ex)
            {
                // Mostrar error en caso de fallo al cargar productos
                CustomMessageBoxForm.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Llena los ComboBoxes con opciones estáticas para categorías y proveedores
        private void CargarComboBoxes()
        {
            // Categorías disponibles
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Flores Individuales");
            cmbCategoria.Items.Add("Arreglos Florales");
            cmbCategoria.Items.Add("Peluches");
            cmbCategoria.Items.Add("Chocolates");

            // Proveedores disponibles
            cmbProveedor.Items.Clear();
            cmbProveedor.Items.Add("Proveedor Flores de México");
            cmbProveedor.Items.Add("Regalos Internacionales S.A.");
            cmbProveedor.Items.Add("Chocolates del Sur");
        }

        // Evento que se ejecuta al hacer clic en una fila del DataGridView de productos
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Validar que se hizo clic en una fila válida
            {
                // Obtener el producto asociado a la fila seleccionada
                var producto = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;

                if (producto != null)
                {
                    // Guardar el Id del producto seleccionado para futuras operaciones
                    _idSeleccionado = producto.Id;

                    // Mostrar los datos del producto en los controles correspondientes
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    cmbCategoria.SelectedItem = producto.Categoria;
                    cmbProveedor.SelectedItem = producto.Proveedor;
                    numPrecioCosto.Value = producto.PrecioCosto;
                    numPrecioVenta.Value = producto.PrecioVenta;
                    numStockMinimo.Value = producto.StockMinimo;
                    numStockMaximo.Value = producto.StockMaximo;

                    // Aquí puedes cargar la imagen si tienes lógica para ello
                    // picFoto.Image = ...
                }
            }
        }

        // Limpia todos los campos y prepara el formulario para un nuevo producto
        private void LimpiarCampos()
        {
            _idSeleccionado = null; // Quitar selección previa

            txtNombre.Clear();       // Limpiar nombre
            txtDescripcion.Clear();  // Limpiar descripción

            cmbCategoria.SelectedIndex = -1; // Deseleccionar categoría
            cmbProveedor.SelectedIndex = -1; // Deseleccionar proveedor

            numPrecioCosto.Value = 0;     // Poner precios y stocks a 0
            numPrecioVenta.Value = 0;
            numStockMinimo.Value = 0;
            numStockMaximo.Value = 0;

            picFoto.Image = null;          // Limpiar imagen (si aplica)
            dgvProductos.ClearSelection(); // Deseleccionar filas en la tabla
            txtNombre.Focus();             // Foco en nombre para ingreso rápido
        }

        // Prepara el formulario para ingresar un nuevo producto
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Guarda un nuevo producto o actualiza uno existente
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                CustomMessageBoxForm.Show("El nombre del producto es obligatorio.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto producto con los datos del formulario
            var producto = new Producto
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Categoria = cmbCategoria.Text,
                Proveedor = cmbProveedor.Text,
                PrecioCosto = numPrecioCosto.Value,
                PrecioVenta = numPrecioVenta.Value,
                Stock = 0, // El stock real se maneja en módulo de inventario
                StockMinimo = (int)numStockMinimo.Value,
                StockMaximo = (int)numStockMaximo.Value
            };

            try
            {
                if (_idSeleccionado == null)
                {
                    // Guardar nuevo producto si no hay selección previa
                    await _productoRepository.GuardarAsync(producto);
                    CustomMessageBoxForm.Show("Producto guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }
                else
                {
                    // Actualizar producto existente usando Id seleccionado
                    producto.Id = _idSeleccionado.Value;
                    await _productoRepository.ActualizarAsync(producto);
                    CustomMessageBoxForm.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }

                // Recargar la lista y limpiar formulario después de guardar o actualizar
                await CargarProductosAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si falla el guardado o actualización
                CustomMessageBoxForm.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Elimina el producto seleccionado tras confirmación del usuario
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar que hay un producto seleccionado para eliminar
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un producto de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            // Confirmar la acción con el usuario
            var confirmacion = CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación");

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // Eliminar el producto y mostrar mensaje de éxito
                    await _productoRepository.EliminarAsync(_idSeleccionado.Value);
                    CustomMessageBoxForm.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    // Recargar la lista y limpiar formulario
                    await CargarProductosAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    // Mostrar mensaje de error si falla la eliminación
                    CustomMessageBoxForm.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }
    }
}
