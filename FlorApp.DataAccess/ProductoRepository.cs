using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class ProductoRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            var productos = new List<Producto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Nombre, Descripcion, Categoria, Proveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo, StockMaximo, FechaRegistro, CodigoBarras FROM Productos";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new Producto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Categoria = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Proveedor = reader.IsDBNull(4) ? null : reader.GetString(4),
                                PrecioCosto = reader.GetDecimal(5),
                                PrecioVenta = reader.GetDecimal(6),
                                Stock = reader.GetInt32(7),
                                StockMinimo = reader.GetInt32(8),
                                StockMaximo = reader.GetInt32(9),
                                FechaRegistro = reader.GetDateTime(10),
                                CodigoBarras = reader.IsDBNull(11) ? null : reader.GetString(11)
                            });
                        }
                    }
                }
            }
            return productos;
        }

        public async Task<Producto> BuscarPorCodigoONombreAsync(string busqueda)
        {
            Producto producto = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Nombre, Descripcion, Categoria, Proveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo, StockMaximo, FechaRegistro, CodigoBarras FROM Productos WHERE CodigoBarras = @busqueda OR Nombre = @busqueda";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@busqueda", busqueda);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            producto = new Producto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Categoria = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Proveedor = reader.IsDBNull(4) ? null : reader.GetString(4),
                                PrecioCosto = reader.GetDecimal(5),
                                PrecioVenta = reader.GetDecimal(6),
                                Stock = reader.GetInt32(7),
                                StockMinimo = reader.GetInt32(8),
                                StockMaximo = reader.GetInt32(9),
                                FechaRegistro = reader.GetDateTime(10),
                                CodigoBarras = reader.IsDBNull(11) ? null : reader.GetString(11)
                            };
                        }
                    }
                }
            }
            return producto;
        }

        public async Task GuardarAsync(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Productos (Nombre, Descripcion, Categoria, Proveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo, StockMaximo, CodigoBarras)
                              VALUES (@Nombre, @Descripcion, @Categoria, @Proveedor, @PrecioCosto, @PrecioVenta, @Stock, @StockMinimo, @StockMaximo, @CodigoBarras)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", (object)producto.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Categoria", (object)producto.Categoria ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Proveedor", (object)producto.Proveedor ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PrecioCosto", producto.PrecioCosto);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
                    command.Parameters.AddWithValue("@StockMaximo", producto.StockMaximo);
                    command.Parameters.AddWithValue("@CodigoBarras", (object)producto.CodigoBarras ?? DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarAsync(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Productos SET 
                                Nombre = @Nombre, 
                                Descripcion = @Descripcion, 
                                Categoria = @Categoria, 
                                Proveedor = @Proveedor, 
                                PrecioCosto = @PrecioCosto, 
                                PrecioVenta = @PrecioVenta, 
                                StockMinimo = @StockMinimo, 
                                StockMaximo = @StockMaximo,
                                CodigoBarras = @CodigoBarras
                              WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", (object)producto.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Categoria", (object)producto.Categoria ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Proveedor", (object)producto.Proveedor ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PrecioCosto", producto.PrecioCosto);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
                    command.Parameters.AddWithValue("@StockMaximo", producto.StockMaximo);
                    command.Parameters.AddWithValue("@CodigoBarras", (object)producto.CodigoBarras ?? DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Productos WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // --- MÉTODO AÑADIDO ---
        public async Task ActualizarStockAsync(int productoId, int cantidadCambio)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                // Usamos un UPDATE relativo para sumar o restar del stock actual
                var query = "UPDATE Productos SET Stock = Stock + @CantidadCambio WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CantidadCambio", cantidadCambio); // puede ser positivo (entrada) o negativo (salida)
                    command.Parameters.AddWithValue("@Id", productoId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<int> ContarTodosAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT COUNT(Id) FROM Productos";
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        // --- NUEVO MÉTODO ---
        public async Task<List<Producto>> ObtenerProductosBajoStockAsync()
        {
            var productos = new List<Producto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Nombre, Stock, StockMinimo FROM Productos WHERE Stock <= StockMinimo";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(new Producto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Stock = reader.GetInt32(2),
                                StockMinimo = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return productos;
        }
    }
}
