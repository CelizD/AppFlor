using FlorApp.DataAccess;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ProductosForm : Form
    {
        private readonly ProductoRepository _productoRepository;
        private int? _idSeleccionado = null;

        public ProductosForm()
        {
            InitializeComponent();
            _productoRepository = new ProductoRepository();
            this.Load += new EventHandler(ProductosForm_Load);
            dgvProductos.CellClick += new DataGridViewCellEventHandler(dgvProductos_CellClick);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        private async void ProductosForm_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
            CargarComboBoxes();
            LimpiarCampos();
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await _productoRepository.ObtenerTodosAsync();
                dgvProductos.DataSource = productos;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

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

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var producto = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                if (producto != null)
                {
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
            picFoto.Image = null;
            dgvProductos.ClearSelection();
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
                CustomMessageBoxForm.Show("El nombre del producto es obligatorio.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var producto = new Producto
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Categoria = cmbCategoria.Text,
                Proveedor = cmbProveedor.Text,
                PrecioCosto = numPrecioCosto.Value,
                PrecioVenta = numPrecioVenta.Value,
                Stock = 0, // El stock se gestiona en el módulo de inventario
                StockMinimo = (int)numStockMinimo.Value,
                StockMaximo = (int)numStockMaximo.Value
            };

            try
            {
                if (_idSeleccionado == null) // Es un nuevo producto
                {
                    await _productoRepository.GuardarAsync(producto);
                    CustomMessageBoxForm.Show("Producto guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }
                else // Estamos actualizando un producto existente
                {
                    producto.Id = _idSeleccionado.Value;
                    await _productoRepository.ActualizarAsync(producto);
                    CustomMessageBoxForm.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxIcon.Information);
                }

                await CargarProductosAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un producto de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación");

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await _productoRepository.EliminarAsync(_idSeleccionado.Value);
                    CustomMessageBoxForm.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);

                    await CargarProductosAsync();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    CustomMessageBoxForm.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }
    }
}
