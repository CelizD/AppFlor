using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlorApp.BusinessLogic
{
    public class ProductoService
    {
        private readonly ProductoRepository _productoRepository;

        // El servicio ahora recibe la cadena de conexión desde la capa que lo crea.
        public ProductoService(string connectionString)
        {
            _productoRepository = new ProductoRepository(connectionString);
        }

        public Task<List<Producto>> ObtenerTodosLosProductosAsync()
        {
            return _productoRepository.ObtenerTodosAsync();
        }

        public async Task GuardarProductoAsync(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacío.");
            }
            if (producto.PrecioVenta <= producto.PrecioCosto)
            {
                throw new ArgumentException("El precio de venta debe ser mayor que el precio de costo.");
            }
            var productoExistente = await _productoRepository.BuscarPorNombreAsync(producto.Nombre);
            if (productoExistente != null && productoExistente.Id != producto.Id)
            {
                throw new ArgumentException("Ya existe un producto con ese nombre.");
            }

            if (producto.Id == 0)
            {
                await _productoRepository.GuardarAsync(producto);
            }
            else
            {
                await _productoRepository.ActualizarAsync(producto);
            }
        }

        public async Task EliminarProductoAsync(int id)
        {
            var producto = await _productoRepository.ObtenerPorIdAsync(id);
            if (producto != null && producto.Stock > 0)
            {
                throw new InvalidOperationException("No se puede eliminar un producto con stock disponible.");
            }
            await _productoRepository.EliminarAsync(id);
        }
    }
}
