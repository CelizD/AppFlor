using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; // <-- AÑADIR ESTA LÍNEA
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlorApp.DataAccess.Models;
using FlorApp.DataAccess.Repositories;


namespace FlorApp.Presentation.Forms.Main
{
    public partial class ComprasForm : Form
    {
        private readonly OrdenCompraRepository _ordenCompraRepository;
        private readonly ProveedorRepository _proveedorRepository;
        private readonly ProductoRepository _productoRepository;
        private BindingList<OrdenCompraDetalle> _carritoCompra;
        private int? _idOrdenSeleccionada = null;

        public ComprasForm()
        {
            InitializeComponent();

            // --- CORRECCIÓN APLICADA AQUÍ ---
            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _ordenCompraRepository = new OrdenCompraRepository(connectionString);
            _proveedorRepository = new ProveedorRepository(connectionString);
            _productoRepository = new ProductoRepository(connectionString);

            this.Load += new EventHandler(ComprasForm_Load);
            btnNuevaOrden.Click += new EventHandler(btnNuevaOrden_Click);
            btnAgregarProducto.Click += new EventHandler(btnAgregarProducto_Click);
            btnGuardarOrden.Click += new EventHandler(btnGuardarOrden_Click);
            dgvOrdenes.SelectionChanged += new EventHandler(dgvOrdenes_SelectionChanged);
            btnRecibirMercancia.Click += new EventHandler(btnRecibirMercancia_Click);
        }

        private async void ComprasForm_Load(object sender, EventArgs e)
        {
            _carritoCompra = new BindingList<OrdenCompraDetalle>();
            dgvDetallesOrden.DataSource = _carritoCompra;
            await CargarDatosIniciales();
        }

        private async Task CargarDatosIniciales()
        {
            await CargarOrdenesDeCompraAsync();
            await CargarComboBoxesAsync();
            pnlNuevaOrden.Enabled = false;
        }

        private async Task CargarOrdenesDeCompraAsync()
        {
            try
            {
                var ordenes = await _ordenCompraRepository.ObtenerTodasAsync();
                dgvOrdenes.DataSource = ordenes;
            }
            catch (Exception ex)
            {
                Dialogs.CustomMessageBoxForm.Show($"Error al cargar órdenes de compra: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async Task CargarComboBoxesAsync()
        {
            try
            {
                var proveedores = await _proveedorRepository.ObtenerTodosAsync();
                cmbProveedor.DataSource = proveedores;
                cmbProveedor.DisplayMember = "NombreEmpresa";
                cmbProveedor.ValueMember = "Id";

                var productos = await _productoRepository.ObtenerTodosAsync();
                cmbProducto.DataSource = productos;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                Dialogs.CustomMessageBoxForm.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void btnNuevaOrden_Click(object sender, EventArgs e)
        {
            pnlNuevaOrden.Enabled = true;
            _carritoCompra.Clear();
            _idOrdenSeleccionada = null;
            dgvOrdenes.ClearSelection();
            cmbProveedor.Focus();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null || numCantidad.Value <= 0)
            {
                Dialogs.CustomMessageBoxForm.Show("Debe seleccionar un producto y una cantidad mayor a 0.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var producto = (Producto)cmbProducto.SelectedItem;
            var detalle = new OrdenCompraDetalle
            {
                ProductoId = producto.Id,
                NombreProducto = producto.Nombre,
                Cantidad = (int)numCantidad.Value,
                CostoUnitario = producto.PrecioCosto
            };

            _carritoCompra.Add(detalle);
            numCantidad.Value = 0; // Limpiar la cantidad después de agregar
        }

        private async void btnGuardarOrden_Click(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedItem == null || _carritoCompra.Count == 0)
            {
                Dialogs.CustomMessageBoxForm.Show("Debe seleccionar un proveedor y añadir al menos un producto.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var proveedor = (Proveedor)cmbProveedor.SelectedItem;
            var orden = new OrdenCompra
            {
                ProveedorId = proveedor.Id,
                NombreProveedor = proveedor.NombreEmpresa,
                FechaCreacion = DateTime.Now,
                Estado = "Solicitada",
                TotalCosto = _carritoCompra.Sum(d => d.Cantidad * d.CostoUnitario),
                Detalles = _carritoCompra.ToList()
            };

            try
            {
                await _ordenCompraRepository.GuardarAsync(orden);
                Dialogs.CustomMessageBoxForm.Show("Orden de compra guardada exitosamente.", "Éxito", MessageBoxIcon.Information);
                await CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                Dialogs.CustomMessageBoxForm.Show($"Error al guardar la orden: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void dgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count > 0)
            {
                pnlNuevaOrden.Enabled = false;
                var ordenSeleccionada = (OrdenCompra)dgvOrdenes.SelectedRows[0].DataBoundItem;
                _idOrdenSeleccionada = ordenSeleccionada.Id;
                var detalles = await _ordenCompraRepository.ObtenerDetallesAsync(ordenSeleccionada.Id);
                dgvDetallesOrden.DataSource = detalles;
                btnRecibirMercancia.Enabled = ordenSeleccionada.Estado == "Solicitada";
            }
        }

        private async void btnRecibirMercancia_Click(object sender, EventArgs e)
        {
            if (_idOrdenSeleccionada == null)
            {
                Dialogs.CustomMessageBoxForm.Show("Por favor, seleccione una orden de la lista.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            if (Dialogs.CustomConfirmBoxForm.Show("¿Confirma que ha recibido toda la mercancía de esta orden? Esta acción actualizará el stock de los productos.", "Confirmar Recepción") == DialogResult.Yes)
            {
                try
                {
                    await _ordenCompraRepository.MarcarComoRecibidaAsync(_idOrdenSeleccionada.Value);
                    Dialogs.CustomMessageBoxForm.Show("Mercancía recibida y stock actualizado.", "Éxito", MessageBoxIcon.Information);
                    await CargarDatosIniciales();
                }
                catch (Exception ex)
                {
                    Dialogs.CustomMessageBoxForm.Show($"Error al recibir la mercancía: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }
    }
}
