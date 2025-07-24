using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class InventarioForm : Form
    {
        private readonly MovimientoInventarioRepository _movimientoRepository;
        private readonly ProductoRepository _productoRepository;
        private List<Producto> _listaProductos;

        public InventarioForm()
        {
            InitializeComponent();
            _movimientoRepository = new MovimientoInventarioRepository();
            _productoRepository = new ProductoRepository();
            this.Load += new EventHandler(InventarioForm_Load);
            btnRegistrarEntrada.Click += new EventHandler(btnRegistrarEntrada_Click);
            btnRegistrarSalida.Click += new EventHandler(btnRegistrarSalida_Click);
        }

        private async void InventarioForm_Load(object sender, EventArgs e)
        {
            await CargarDatosIniciales();
        }

        private async Task CargarDatosIniciales()
        {
            await CargarProductosEnComboBoxes();
            await CargarHistorialAsync();
        }

        private async Task CargarProductosEnComboBoxes()
        {
            try
            {
                _listaProductos = await _productoRepository.ObtenerTodosAsync();

                cmbProductoEntrada.DataSource = new List<Producto>(_listaProductos);
                cmbProductoEntrada.DisplayMember = "Nombre";
                cmbProductoEntrada.ValueMember = "Id";

                cmbProductoSalida.DataSource = new List<Producto>(_listaProductos);
                cmbProductoSalida.DisplayMember = "Nombre";
                cmbProductoSalida.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async Task CargarHistorialAsync()
        {
            try
            {
                var historial = await _movimientoRepository.ObtenerTodosAsync();
                dgvHistorial.DataSource = historial;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar el historial: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            if (cmbProductoEntrada.SelectedItem == null || numCantidadEntrada.Value <= 0)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un producto y especifique una cantidad válida.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = (Producto)cmbProductoEntrada.SelectedItem;
            int cantidad = (int)numCantidadEntrada.Value;

            var movimiento = new MovimientoInventario
            {
                ProductoId = productoSeleccionado.Id,
                NombreProducto = productoSeleccionado.Nombre,
                TipoMovimiento = "Entrada",
                Cantidad = cantidad,
                Fecha = DateTime.Now,
                Motivo = "Entrada manual de mercancía"
            };

            try
            {
                await _movimientoRepository.GuardarAsync(movimiento);
                await _productoRepository.ActualizarStockAsync(productoSeleccionado.Id, cantidad); // Sumar al stock

                CustomMessageBoxForm.Show("Entrada de inventario registrada exitosamente.", "Éxito", MessageBoxIcon.Information);

                await CargarDatosIniciales();
                numCantidadEntrada.Value = 0;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al registrar la entrada: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (cmbProductoSalida.SelectedItem == null || numCantidadSalida.Value <= 0)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un producto y especifique una cantidad válida.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = (Producto)cmbProductoSalida.SelectedItem;
            int cantidad = (int)numCantidadSalida.Value;

            // Recargar la info del producto para tener el stock más actualizado
            var productoActualizado = await _productoRepository.BuscarPorCodigoONombreAsync(productoSeleccionado.Nombre);

            if (productoActualizado.Stock < cantidad)
            {
                CustomMessageBoxForm.Show($"No hay suficiente stock para este producto. Stock actual: {productoActualizado.Stock}", "Stock Insuficiente", MessageBoxIcon.Warning);
                return;
            }

            var movimiento = new MovimientoInventario
            {
                ProductoId = productoSeleccionado.Id,
                NombreProducto = productoSeleccionado.Nombre,
                TipoMovimiento = "Ajuste por Merma",
                Cantidad = -cantidad, // Las salidas se registran como negativas
                Fecha = DateTime.Now,
                Motivo = txtMotivoSalida.Text
            };

            try
            {
                await _movimientoRepository.GuardarAsync(movimiento);
                await _productoRepository.ActualizarStockAsync(productoSeleccionado.Id, -cantidad); // Restar del stock

                CustomMessageBoxForm.Show("Salida de inventario registrada exitosamente.", "Éxito", MessageBoxIcon.Information);

                await CargarDatosIniciales();
                numCantidadSalida.Value = 0;
                txtMotivoSalida.Clear();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al registrar la salida: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }
    }
}
