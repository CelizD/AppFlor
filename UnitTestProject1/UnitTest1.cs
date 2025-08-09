using FlorApp.DataAccess.Repositories;
using FlorApp.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FlorApp.Tests
{
    [TestClass]
    public class ProductoRepositoryTests
    {
        private readonly ProductoRepository _repository;
        private readonly string _connectionString;

        public ProductoRepositoryTests()
        {
            // Asegúrate de que este nombre de servidor sea correcto.
            _connectionString = "Server=DESKTOP-QI5KU12\\SQLEXPRESS;Database=FloreriaDB_Test;Trusted_Connection=True;";
            _repository = new ProductoRepository(_connectionString);
        }

        [TestMethod]
        public async Task GetAll_DebeRetornarListaDeProductos()
        {
            // Act
            var productos = await _repository.ObtenerTodosAsync();

            // Assert
            Assert.IsNotNull(productos);
        }

        [TestMethod]
        public async Task Find_Exitoso_DebeEncontrarProductoExistente()
        {
            // Arrange: Asume que existe un producto con Id = 1 en tu BD de prueba
            int idExistente = 1;

            // Act
            var producto = await _repository.ObtenerPorIdAsync(idExistente);

            // Assert
            Assert.IsNotNull(producto);
            Assert.AreEqual(idExistente, producto.Id);
        }

        [TestMethod]
        public async Task Find_Fallido_NoDebeEncontrarProductoInexistente()
        {
            // Arrange
            int idInexistente = -99;

            // Act
            var producto = await _repository.ObtenerPorIdAsync(idInexistente);

            // Assert
            Assert.IsNull(producto);
        }

        [TestMethod]
        public async Task Insert_Exitoso_DebeAgregarNuevoProducto()
        {
            // Arrange
            var nuevoProducto = new Producto
            {
                Nombre = "Test Rosa Unitaria",
                Categoria = "Flor",
                ProveedorId = 1,
                PrecioCosto = 10,
                PrecioVenta = 25,
                Stock = 100,
                StockMinimo = 10,
                StockMaximo = 200,
                FechaRegistro = DateTime.Now
            };

            // Act
            await _repository.GuardarAsync(nuevoProducto);

            // Assert
            var productoGuardado = await _repository.BuscarPorNombreAsync("Test Rosa Unitaria");
            Assert.IsNotNull(productoGuardado);
            Assert.AreEqual("Test Rosa Unitaria", productoGuardado.Nombre);

            // Limpieza
            await _repository.EliminarAsync(productoGuardado.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public async Task Insert_Fallido_NoDebePermitirNombreNulo()
        {
            // Arrange
            var productoInvalido = new Producto { Nombre = null, Categoria = "Flor", ProveedorId = 1, PrecioCosto = 1, PrecioVenta = 1, Stock = 1, StockMinimo = 1, StockMaximo = 1, FechaRegistro = DateTime.Now };

            // Act
            await _repository.GuardarAsync(productoInvalido);
        }

        [TestMethod]
        public async Task Update_Exitoso_DebeModificarProducto()
        {
            // Arrange
            var producto = new Producto { Nombre = "Producto a Modificar", Categoria = "Flor", ProveedorId = 1, PrecioCosto = 5, PrecioVenta = 10, Stock = 50, StockMinimo = 5, StockMaximo = 100, FechaRegistro = DateTime.Now };
            await _repository.GuardarAsync(producto);
            var productoGuardado = await _repository.BuscarPorNombreAsync("Producto a Modificar");

            // Act
            productoGuardado.PrecioVenta = 15;
            await _repository.ActualizarAsync(productoGuardado);

            // Assert
            var productoActualizado = await _repository.ObtenerPorIdAsync(productoGuardado.Id);
            Assert.AreEqual(15, productoActualizado.PrecioVenta);

            // Limpieza
            await _repository.EliminarAsync(productoGuardado.Id);
        }

        [TestMethod]
        public async Task Delete_Exitoso_DebeEliminarProducto()
        {
            // Arrange
            var producto = new Producto { Nombre = "Producto a Eliminar", Categoria = "Flor", ProveedorId = 1, PrecioCosto = 5, PrecioVenta = 10, Stock = 50, StockMinimo = 5, StockMaximo = 100, FechaRegistro = DateTime.Now };
            await _repository.GuardarAsync(producto);
            var productoGuardado = await _repository.BuscarPorNombreAsync("Producto a Eliminar");
            Assert.IsNotNull(productoGuardado, "Fallo en la preparación: El producto no se guardó correctamente.");

            // Act
            await _repository.EliminarAsync(productoGuardado.Id);

            // Assert
            var productoEliminado = await _repository.ObtenerPorIdAsync(productoGuardado.Id);
            Assert.IsNull(productoEliminado);
        }

        
        [TestMethod]
        public async Task Update_Fallido_NoDebeActualizarProductoInexistente()
        {
            // Arrange: Crea un producto que no existe en la BD
            var productoInexistente = new Producto
            {
                Id = -1, // Un ID que nunca existirá
                Nombre = "Producto Fantasma",
                Categoria = "Flor",
                ProveedorId = 1,
                PrecioVenta = 100,
                PrecioCosto = 50,
                Stock = 10,
                StockMinimo = 1,
                StockMaximo = 100,
                FechaRegistro = DateTime.Now
            };

            // Act
            await _repository.ActualizarAsync(productoInexistente);

            // Assert: Verifica que el producto sigue sin existir
            var resultado = await _repository.ObtenerPorIdAsync(-1);
            Assert.IsNull(resultado, "El producto no debería existir después del intento de actualización.");
        }

        [TestMethod]
        public async Task Delete_Fallido_NoDebeLanzarErrorAlEliminarIdInexistente()
        {
            // Arrange
            int idInexistente = -99;

            // Act y Assert: El método no debería lanzar una excepción
            try
            {
                await _repository.EliminarAsync(idInexistente);
                // Si llega aquí, la prueba es exitosa porque no hubo error.
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                // Si lanza cualquier excepción, la prueba falla.
                Assert.Fail("Se esperaba que no se lanzara ninguna excepción, pero se obtuvo: " + ex.Message);
            }
        }
        
    }
}