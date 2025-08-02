using FlorApp.DataAccess;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq; // Necesario para .ToList()
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ProductosForm : Form
    {
        // --- CÓDIGO NUEVO ---
        // Añadimos el repositorio de proveedores
        private readonly ProductoRepository _productoRepository;
        private readonly ProveedorRepository _proveedorRepository; // <-- AÑADIDO

        private Producto _productoSeleccionado;
        private byte[] _imagenProductoBytes;

        public ProductosForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _productoRepository = new ProductoRepository(connectionString);
            _proveedorRepository = new ProveedorRepository(connectionString); // <-- AÑADIDO

            this.Load += new EventHandler(ProductosForm_Load);
            dgvProductos.SelectionChanged += new EventHandler(dgvProductos_SelectionChanged);
            btnCargarFoto.Click += new EventHandler(btnCargarFoto_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
        }

        private async void ProductosForm_Load(object sender, EventArgs e)
        {
            // --- CÓDIGO MODIFICADO ---
            // Cargamos los proveedores PRIMERO, para que el ComboBox esté listo.
            await CargarProveedores();
            await CargarProductos();
        }

        // --- CÓDIGO NUEVO ---
        // Este método carga los proveedores y los pone en el ComboBox.
        private async Task CargarProveedores()
        {
            try
            {
                var proveedores = await _proveedorRepository.ObtenerTodosAsync();

                cmbProveedor.DataSource = proveedores.ToList();
                cmbProveedor.DisplayMember = "NombreEmpresa"; // La propiedad que se mostrará al usuario
                cmbProveedor.ValueMember = "Id";               // El valor oculto que usaremos (el ID)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fatal al cargar los proveedores: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarProductos()
        {
            // Para evitar que el evento SelectionChanged se dispare mientras se carga
            dgvProductos.SelectionChanged -= dgvProductos_SelectionChanged;

            // Aquí necesitarás un método en tu ProductoRepository que también traiga el nombre del proveedor
            // o ajustar la carga. Por ahora, cargamos los productos.
            dgvProductos.DataSource = await _productoRepository.ObtenerTodosAsync();

            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;

            LimpiarCampos();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is Producto)
            {
                _productoSeleccionado = dgvProductos.CurrentRow.DataBoundItem as Producto;
                MostrarDetallesProducto();
            }
        }

        private void MostrarDetallesProducto()
        {
            if (_productoSeleccionado == null) return;

            txtNombre.Text = _productoSeleccionado.Nombre;
            txtDescripcion.Text = _productoSeleccionado.Descripcion;
            cmbCategoria.Text = _productoSeleccionado.Categoria;

            // --- CÓDIGO CORREGIDO ---
            // Usamos SelectedValue para seleccionar el proveedor por su ID.
            cmbProveedor.SelectedValue = _productoSeleccionado.ProveedorId;

            numPrecioCosto.Value = _productoSeleccionado.PrecioCosto;
            numPrecioVenta.Value = _productoSeleccionado.PrecioVenta;
            numStockMinimo.Value = _productoSeleccionado.StockMinimo;
            numStockMaximo.Value = _productoSeleccionado.StockMaximo;

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
            // --- CÓDIGO CORREGIDO Y MEJORADO ---
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProveedor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_productoSeleccionado != null) // Actualizando
                {
                    _productoSeleccionado.Nombre = txtNombre.Text;
                    _productoSeleccionado.Descripcion = txtDescripcion.Text;
                    _productoSeleccionado.Categoria = cmbCategoria.Text;
                    _productoSeleccionado.ProveedorId = (int)cmbProveedor.SelectedValue; // <-- Guarda el ID
                    _productoSeleccionado.PrecioCosto = numPrecioCosto.Value;
                    _productoSeleccionado.PrecioVenta = numPrecioVenta.Value;
                    _productoSeleccionado.StockMinimo = (int)numStockMinimo.Value;
                    _productoSeleccionado.StockMaximo = (int)numStockMaximo.Value;
                    _productoSeleccionado.Foto = _imagenProductoBytes;

                    await _productoRepository.ActualizarAsync(_productoSeleccionado);
                    MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Creando uno nuevo
                {
                    var nuevoProducto = new Producto
                    {
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        Categoria = cmbCategoria.Text,
                        ProveedorId = (int)cmbProveedor.SelectedValue, // <-- Guarda el ID
                        PrecioCosto = numPrecioCosto.Value,
                        PrecioVenta = numPrecioVenta.Value,
                        Stock = 0,
                        StockMinimo = (int)numStockMinimo.Value,
                        StockMaximo = (int)numStockMaximo.Value,
                        FechaRegistro = DateTime.Now,
                        Foto = _imagenProductoBytes
                    };
                    await _productoRepository.GuardarAsync(nuevoProducto);
                    MessageBox.Show("Producto guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                await CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            picFoto.Image = null;
            _imagenProductoBytes = null;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }
    }
}