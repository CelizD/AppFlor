using FlorApp.DataAccess;
using FlorApp.BusinessLogic; // Referencia a la lógica de negocio
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ProductosForm : Form
    {
        // Se usa el servicio de productos en lugar del repositorio directamente
        private readonly ProductoService _productoService;

        // Almacena el ID del producto seleccionado en el DataGridView
        private int? _idSeleccionado = null;

        public ProductosForm()
        {
            InitializeComponent(); // Inicializa el formulario
            _productoService = new ProductoService(); // Instancia el servicio

            // Asignación de eventos
            this.Load += new EventHandler(ProductosForm_Load);
            dgvProductos.CellClick += new DataGridViewCellEventHandler(dgvProductos_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        // Evento al cargar el formulario
        private async void ProductosForm_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync(); // Cargar los productos en la tabla
            CargarComboBoxes(); // Cargar categorías y proveedores
            LimpiarCampos(); // Limpiar los campos del formulario
        }

        // Carga los productos desde el servicio
        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await _productoService.ObtenerTodosLosProductosAsync();
                dgvProductos.DataSource = productos; // Mostrar en la tabla
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Llena los comboBox de categoría y proveedor
        private void CargarComboBoxes()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Flores Individuales");
            cmbCategoria.Items.Add("Arreglos Florales");
            cmbCategoria.Items.Add("Peluches");
            cmbCategoria.Items.Add("Chocolates");

            cmbProveedor.Items.Clear();
            cmbProveedor.Items.Add("Proveedor Flores de México");
            cmbProveedor.Items.Add("Regalos Internacionales S.A.");
            cmbProveedor.Items.Add("Chocolates del Sur");
        }

        // Evento cuando se hace clic sobre una celda del DataGridView
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var producto = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                if (producto != null)
                {
                    // Cargar los datos del producto en los campos del formulario
                    _idSeleccionado = producto.Id;
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    cmbCategoria.SelectedItem = producto.Categoria;
                    cmbProveedor.SelectedItem = producto.Proveedor;
                    numPrecioCosto.Value = producto.PrecioCosto;
                    numPrecioVenta.Value = producto.PrecioVenta;
                    numStockMinimo.Value = producto.StockMinimo;
                    numStockMaximo.Value = producto.StockMaximo;
                }
            }
        }

        // Limpia los campos del formulario
        private void LimpiarCampos()
        {
            _idSeleccionado = null;
            txtNombre.Clear();
            txtDescripcion.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            numPrecioCosto.Value = 0;
            numPrecioVenta.Value = 0;
            numStockMinimo.Value = 0;
            numStockMaximo.Value = 0;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

        // Evento del botón "Nuevo"
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos(); // Limpia todo para ingresar un nuevo producto
        }

        // Evento del botón "Guardar"
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crear objeto producto desde los campos del formulario
            var producto = new Producto
            {
                Id = _idSeleccionado ?? 0,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Categoria = cmbCategoria.Text,
                Proveedor = cmbProveedor.Text,
                PrecioCosto = numPrecioCosto.Value,
                PrecioVenta = numPrecioVenta.Value,
                StockMinimo = (int)numStockMinimo.Value,
                StockMaximo = (int)numStockMaximo.Value
            };

            try
            {
                // Guardar o actualizar el producto usando la lógica de negocio
                await _productoService.GuardarProductoAsync(producto);

                // Mostrar mensaje de éxito
                string mensaje = _idSeleccionado == null ? "Producto guardado exitosamente." : "Producto actualizado exitosamente.";
                CustomMessageBoxForm.Show(mensaje, "Éxito", MessageBoxIcon.Information);

                await CargarProductosAsync(); // Recargar la tabla
                LimpiarCampos(); // Limpiar el formulario
            }
            catch (Exception ex)
            {
                // Mostrar errores si la validación falla (ej. precio, nombre duplicado)
                CustomMessageBoxForm.Show($"Error: {ex.Message}", "Error de Validación", MessageBoxIcon.Warning);
            }
        }

        // Evento del botón "Eliminar"
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un producto de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            // Confirmar con el usuario si desea eliminar el producto
            if (CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación") == DialogResult.Yes)
            {
                try
                {
                    await _productoService.EliminarProductoAsync(_idSeleccionado.Value); // Eliminar producto
                    CustomMessageBoxForm.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    await CargarProductosAsync(); // Recargar tabla
                    LimpiarCampos(); // Limpiar formulario
                }
                catch (Exception ex)
                {
                    // Captura error si el producto no puede ser eliminado (ej. tiene stock)
                    CustomMessageBoxForm.Show($"Error: {ex.Message}", "Operación no permitida", MessageBoxIcon.Warning);
                }
            }
        }
    }
}
