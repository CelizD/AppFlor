using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ProductosForm : Form
    {
        private readonly ProductoRepository _productoRepository;
        private readonly ProveedorRepository _proveedorRepository;

        private Producto _productoSeleccionado;
        private byte[] _imagenProductoBytes;

        public ProductosForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _productoRepository = new ProductoRepository(connectionString);
            _proveedorRepository = new ProveedorRepository(connectionString);

            // Suscripción a eventos
            this.Load += new EventHandler(ProductosForm_Load);
            dgvProductos.SelectionChanged += new EventHandler(dgvProductos_SelectionChanged);
            btnCargarFoto.Click += new EventHandler(btnCargarFoto_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
        }

        private async void ProductosForm_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            await CargarProveedores();
            await CargarProductos();
        }

        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Arreglo Floral");
            cmbCategoria.Items.Add("Flor");
            cmbCategoria.Items.Add("Planta");
            cmbCategoria.Items.Add("Envoltura"); // <-- CATEGORÍA AÑADIDA
            cmbCategoria.Items.Add("Extra");
            cmbCategoria.Items.Add("Material");
        }

        private async Task CargarProveedores()
        {
            try
            {
                var proveedores = await _proveedorRepository.ObtenerTodosAsync();
                cmbProveedor.DataSource = proveedores.ToList();
                cmbProveedor.DisplayMember = "NombreEmpresa";
                cmbProveedor.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error fatal al cargar los proveedores: {ex.Message}", "Error de Conexión", MessageBoxIcon.Error);
            }
        }

        private async Task CargarProductos()
        {
            dgvProductos.SelectionChanged -= dgvProductos_SelectionChanged;
            dgvProductos.DataSource = await _productoRepository.ObtenerTodosAsync();
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            LimpiarCampos();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 1 && dgvProductos.CurrentRow?.DataBoundItem is Producto producto)
            {
                _productoSeleccionado = producto;
                MostrarDetallesProducto();
            }
            else
            {
                LimpiarCampos();
                _productoSeleccionado = null;
            }
        }

        private void MostrarDetallesProducto()
        {
            if (_productoSeleccionado == null) return;

            txtNombre.Text = _productoSeleccionado.Nombre;
            txtDescripcion.Text = _productoSeleccionado.Descripcion;
            cmbCategoria.SelectedItem = _productoSeleccionado.Categoria;

            if (_productoSeleccionado.ProveedorId > 0 && cmbProveedor.Items.Cast<Proveedor>().Any(p => p.Id == _productoSeleccionado.ProveedorId))
            {
                cmbProveedor.SelectedValue = _productoSeleccionado.ProveedorId;
            }
            else
            {
                cmbProveedor.SelectedIndex = -1;
            }

            numPrecioCosto.Value = _productoSeleccionado.PrecioCosto;
            numPrecioVenta.Value = _productoSeleccionado.PrecioVenta;
            numStockMinimo.Value = _productoSeleccionado.StockMinimo;
            numStockMaximo.Value = _productoSeleccionado.StockMaximo;
            txtColores.Text = _productoSeleccionado.ColoresDisponibles;

            _imagenProductoBytes = _productoSeleccionado.Foto;
            if (_imagenProductoBytes != null && _imagenProductoBytes.Length > 0)
            {
                using (var ms = new MemoryStream(_imagenProductoBytes))
                {
                    picFoto.Image = Image.FromStream(ms);
                }
            }
            else
            {
                picFoto.Image = null;
            }
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _imagenProductoBytes = File.ReadAllBytes(ofd.FileName);
                    picFoto.Image = new Bitmap(ofd.FileName);
                }
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                CustomMessageBoxForm.Show("El nombre del producto es obligatorio.", "Validación", MessageBoxIcon.Warning);
                return;
            }

            if (cmbProveedor.SelectedValue == null)
            {
                CustomMessageBoxForm.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategoria.SelectedItem == null)
            {
                CustomMessageBoxForm.Show("Debe seleccionar una categoría.", "Validación", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_productoSeleccionado != null) // Actualizando
                {
                    _productoSeleccionado.Nombre = txtNombre.Text;
                    _productoSeleccionado.Descripcion = txtDescripcion.Text;
                    _productoSeleccionado.Categoria = cmbCategoria.SelectedItem.ToString();
                    _productoSeleccionado.ProveedorId = (int)cmbProveedor.SelectedValue;
                    _productoSeleccionado.PrecioCosto = numPrecioCosto.Value;
                    _productoSeleccionado.PrecioVenta = numPrecioVenta.Value;
                    _productoSeleccionado.StockMinimo = (int)numStockMinimo.Value;
                    _productoSeleccionado.StockMaximo = (int)numStockMaximo.Value;
                    _productoSeleccionado.ColoresDisponibles = txtColores.Text;
                    _productoSeleccionado.Foto = _imagenProductoBytes;

                    await _productoRepository.ActualizarAsync(_productoSeleccionado);
                    CustomMessageBoxForm.Show("Producto actualizado con éxito.", "Éxito", MessageBoxIcon.Information);
                }
                else // Creando uno nuevo
                {
                    var nuevoProducto = new Producto
                    {
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        Categoria = cmbCategoria.SelectedItem.ToString(),
                        ProveedorId = (int)cmbProveedor.SelectedValue,
                        PrecioCosto = numPrecioCosto.Value,
                        PrecioVenta = numPrecioVenta.Value,
                        Stock = 0,
                        StockMinimo = (int)numStockMinimo.Value,
                        StockMaximo = (int)numStockMaximo.Value,
                        FechaRegistro = DateTime.Now,
                        ColoresDisponibles = txtColores.Text,
                        Foto = _imagenProductoBytes
                    };
                    await _productoRepository.GuardarAsync(nuevoProducto);
                    CustomMessageBoxForm.Show("Producto guardado con éxito.", "Éxito", MessageBoxIcon.Information);
                }
                await CargarProductos();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione uno o más productos de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            string mensaje = dgvProductos.SelectedRows.Count == 1
                ? "¿Está seguro de que desea eliminar este producto?"
                : $"¿Está seguro de que desea eliminar los {dgvProductos.SelectedRows.Count} productos seleccionados?";

            var confirmacion = CustomConfirmBoxForm.Show(mensaje + " Esta acción no se puede deshacer.", "Confirmar Eliminación");

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    List<Task> tareasEliminacion = new List<Task>();
                    foreach (DataGridViewRow row in dgvProductos.SelectedRows)
                    {
                        if (row.DataBoundItem is Producto productoAEliminar)
                        {
                            tareasEliminacion.Add(_productoRepository.EliminarAsync(productoAEliminar.Id));
                        }
                    }
                    await Task.WhenAll(tareasEliminacion);

                    CustomMessageBoxForm.Show("Productos eliminados exitosamente.", "Éxito", MessageBoxIcon.Information);
                    await CargarProductos();
                }
                catch (Exception ex)
                {
                    CustomMessageBoxForm.Show($"Error al eliminar los productos: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            _productoSeleccionado = null;
            txtNombre.Clear();
            txtDescripcion.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            numPrecioCosto.Value = 0;
            numPrecioVenta.Value = 0;
            numStockMinimo.Value = 0;
            numStockMaximo.Value = 0;
            txtColores.Clear();
            picFoto.Image = null;
            _imagenProductoBytes = null;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }
    }
}
