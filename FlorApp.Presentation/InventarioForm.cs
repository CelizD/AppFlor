using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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

            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _movimientoRepository = new MovimientoInventarioRepository(connectionString);
            _productoRepository = new ProductoRepository(connectionString);

            this.Load += new EventHandler(InventarioForm_Load);
            btnRegistrarEntrada.Click += new EventHandler(btnRegistrarEntrada_Click);
            btnRegistrarSalida.Click += new EventHandler(btnRegistrarSalida_Click);
            btnAplicarAjuste.Click += new EventHandler(btnAplicarAjuste_Click);
            tabControlInventario.SelectedIndexChanged += new EventHandler(tabControlInventario_SelectedIndexChanged);
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

        private async void tabControlInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlInventario.SelectedTab == tabAjusteFisico)
            {
                await CargarProductosParaAjusteAsync();
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
                await _productoRepository.ActualizarStockAsync(productoSeleccionado.Id, cantidad);

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
            var productoActualizado = _listaProductos.FirstOrDefault(p => p.Id == productoSeleccionado.Id);

            if (productoActualizado != null && productoActualizado.Stock < cantidad)
            {
                CustomMessageBoxForm.Show($"No hay suficiente stock para este producto. Stock actual: {productoActualizado.Stock}", "Stock Insuficiente", MessageBoxIcon.Warning);
                return;
            }

            var movimiento = new MovimientoInventario
            {
                ProductoId = productoSeleccionado.Id,
                NombreProducto = productoSeleccionado.Nombre,
                TipoMovimiento = "Ajuste por Merma",
                Cantidad = -cantidad,
                Fecha = DateTime.Now,
                Motivo = txtMotivoSalida.Text
            };

            try
            {
                await _movimientoRepository.GuardarAsync(movimiento);
                await _productoRepository.ActualizarStockAsync(productoSeleccionado.Id, -cantidad);

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

        private async Task CargarProductosParaAjusteAsync()
        {
            try
            {
                var productos = await _productoRepository.ObtenerTodosAsync();
                var dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("StockSistema", typeof(int));
                dt.Columns.Add("StockReal", typeof(int));

                foreach (var p in productos)
                {
                    dt.Rows.Add(p.Id, p.Nombre, p.Stock, p.Stock);
                }

                dgvAjusteStock.DataSource = dt;
                dgvAjusteStock.Columns["Id"].ReadOnly = true;
                dgvAjusteStock.Columns["Nombre"].ReadOnly = true;
                dgvAjusteStock.Columns["StockSistema"].ReadOnly = true;
                dgvAjusteStock.Columns["StockReal"].ReadOnly = false;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar productos para ajuste: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private async void btnAplicarAjuste_Click(object sender, EventArgs e)
        {
            if (CustomConfirmBoxForm.Show("¿Está seguro de que desea aplicar estos ajustes de stock? Esta acción modificará su inventario permanentemente.", "Confirmar Ajuste") != DialogResult.Yes)
            {
                return;
            }

            try
            {
                foreach (DataGridViewRow row in dgvAjusteStock.Rows)
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    string nombre = row.Cells["Nombre"].Value.ToString();
                    int stockSistema = Convert.ToInt32(row.Cells["StockSistema"].Value);
                    int stockReal = Convert.ToInt32(row.Cells["StockReal"].Value);

                    if (stockSistema != stockReal)
                    {
                        int diferencia = stockReal - stockSistema;
                        await _productoRepository.EstablecerStockAsync(id, stockReal);

                        var movimiento = new MovimientoInventario
                        {
                            ProductoId = id,
                            NombreProducto = nombre,
                            TipoMovimiento = "Ajuste por Conteo",
                            Cantidad = diferencia,
                            Fecha = DateTime.Now,
                            Motivo = $"Ajuste de {stockSistema} a {stockReal}"
                        };
                        await _movimientoRepository.GuardarAsync(movimiento);
                    }
                }
                CustomMessageBoxForm.Show("Ajuste de inventario aplicado exitosamente.", "Éxito", MessageBoxIcon.Information);
                await CargarDatosIniciales();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al aplicar el ajuste: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }
    }
}
