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

            // Eventos al cargar el formulario y botones
            this.Load += new EventHandler(InventarioForm_Load);
            btnRegistrarEntrada.Click += new EventHandler(btnRegistrarEntrada_Click);
            btnRegistrarSalida.Click += new EventHandler(btnRegistrarSalida_Click);
        }

        // Evento al cargar el formulario
        private async void InventarioForm_Load(object sender, EventArgs e)
        {
            await CargarDatosIniciales();
        }

        // Carga productos y historial de movimientos
        private async Task CargarDatosIniciales()
        {
            await CargarProductosEnComboBoxes();
            await CargarHistorialAsync();
        }

        // Carga los productos en los combos para selección de entrada y salida
        private async Task CargarProductosEnComboBoxes()
        {
            try
            {
                _listaProductos = await _productoRepository.ObtenerTodosAsync();

                // Asignar lista de productos a combo para entradas
                cmbProductoEntrada.DataSource = new List<Producto>(_listaProductos);
                cmbProductoEntrada.DisplayMember = "Nombre";
                cmbProductoEntrada.ValueMember = "Id";

                // Asignar lista de productos a combo para salidas
                cmbProductoSalida.DataSource = new List<Producto>(_listaProductos);
                cmbProductoSalida.DisplayMember = "Nombre";
                cmbProductoSalida.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Carga historial de movimientos en el DataGridView
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

        // Evento para registrar entrada de inventario
        private async void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un producto y cantidad válida
            if (cmbProductoEntrada.SelectedItem == null || numCantidadEntrada.Value <= 0)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un producto y especifique una cantidad válida.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = (Producto)cmbProductoEntrada.SelectedItem;
            int cantidad = (int)numCantidadEntrada.Value;

            // Crear movimiento de tipo entrada
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
                // Guardar movimiento y actualizar stock sumando la cantidad
                await _movimientoRepository.GuardarAsync(movimiento);
                await _productoRepository.ActualizarStockAsync(productoSeleccionado.Id, cantidad);

                CustomMessageBoxForm.Show("Entrada de inventario registrada exitosamente.", "Éxito", MessageBoxIcon.Information);

                // Refrescar datos y limpiar campo
                await CargarDatosIniciales();
                numCantidadEntrada.Value = 0;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al registrar la entrada: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Evento para registrar salida de inventario
        private async void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            // Validar producto seleccionado y cantidad positiva
            if (cmbProductoSalida.SelectedItem == null || numCantidadSalida.Value <= 0)
            {
                CustomMessageBoxForm.Show("Por favor, seleccione un producto y especifique una cantidad válida.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var productoSeleccionado = (Producto)cmbProductoSalida.SelectedItem;
            int cantidad = (int)numCantidadSalida.Value;

            // Obtener producto actualizado para verificar stock actual
            var productoActualizado = await _productoRepository.BuscarPorCodigoONombreAsync(productoSeleccionado.Nombre);

            if (productoActualizado.Stock < cantidad)
            {
                // No permitir salida si stock es insuficiente
                CustomMessageBoxForm.Show($"No hay suficiente stock para este producto. Stock actual: {productoActualizado.Stock}", "Stock Insuficiente", MessageBoxIcon.Warning);
                return;
            }

            // Crear movimiento de tipo salida (cantidad negativa)
            var movimiento = new MovimientoInventario
            {
                ProductoId = productoSeleccionado.Id,
                NombreProducto = productoSeleccionado.Nombre,
                TipoMovimiento = "Ajuste por Merma",
                Cantidad = -cantidad, // Cantidad negativa para salida
                Fecha = DateTime.Now,
                Motivo = txtMotivoSalida.Text
            };

            try
            {
                // Guardar movimiento y actualizar stock restando cantidad
                await _movimientoRepository.GuardarAsync(movimiento);
                await _productoRepository.ActualizarStockAsync(productoSeleccionado.Id, -cantidad);

                CustomMessageBoxForm.Show("Salida de inventario registrada exitosamente.", "Éxito", MessageBoxIcon.Information);

                // Refrescar datos y limpiar campos
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
