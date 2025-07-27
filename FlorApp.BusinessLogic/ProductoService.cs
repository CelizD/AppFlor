using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlorApp.BusinessLogic
{
    public class ProductoService
    {
        // Repositorio que interactúa con la base de datos
        private readonly ProductoRepository _productoRepository;

        // Constructor: instancia el repositorio
        public ProductoService()
        {
            _productoRepository = new ProductoRepository();
        }

        // Método para obtener todos los productos registrados
        public Task<List<Producto>> ObtenerTodosLosProductosAsync()
        {
            return _productoRepository.ObtenerTodosAsync();
        }

        // Guarda o actualiza un producto, aplicando validaciones
        public async Task GuardarProductoAsync(Producto producto)
        {
            // Validación: el nombre no puede estar vacío
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacío.");
            }

            // Validación: el precio de venta debe ser mayor que el de costo
            if (producto.PrecioVenta <= producto.PrecioCosto)
            {
                throw new ArgumentException("El precio de venta debe ser mayor que el precio de costo.");
            }

            // Evitar duplicidad: buscar si ya existe un producto con el mismo nombre
            var productoExistente = await _productoRepository.BuscarPorNombreAsync(producto.Nombre);
            if (productoExistente != null && productoExistente.Id != producto.Id)
            {
                throw new ArgumentException("Ya existe un producto con ese nombre en la base de datos.");
            }

            // Si el ID es 0, es un nuevo producto
            if (producto.Id == 0)
            {
                await _productoRepository.GuardarAsync(producto); // Insertar nuevo
            }
            else
            {
                await _productoRepository.ActualizarAsync(producto); // Actualizar existente
            }
        }

        // Elimina un producto si no tiene stock
        public async Task EliminarProductoAsync(int id)
        {
            // Obtener el producto por ID
            var producto = await _productoRepository.ObtenerPorIdAsync(id);

            // No permitir eliminar si el stock es mayor a cero
            if (producto != null && producto.Stock > 0)
            {
                throw new InvalidOperationException("No se puede eliminar un producto con stock disponible. Realice un ajuste de inventario primero.");
            }

            // Eliminar el producto
            await _productoRepository.EliminarAsync(id);
        }
    }
}
