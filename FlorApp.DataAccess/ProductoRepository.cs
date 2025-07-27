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

        // --- Mapeador reutilizable para no repetir código ---
        private Producto MapearProducto(SqlDataReader reader)
        {
            return new Producto
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")),
                Categoria = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? null : reader.GetString(reader.GetOrdinal("Categoria")),
                Proveedor = reader.IsDBNull(reader.GetOrdinal("Proveedor")) ? null : reader.GetString(reader.GetOrdinal("Proveedor")),
                PrecioCosto = reader.GetDecimal(reader.GetOrdinal("PrecioCosto")),
                PrecioVenta = reader.GetDecimal(reader.GetOrdinal("PrecioVenta")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                StockMinimo = reader.GetInt32(reader.GetOrdinal("StockMinimo")),
                StockMaximo = reader.GetInt32(reader.GetOrdinal("StockMaximo")),
                FechaRegistro = reader.GetDateTime(reader.GetOrdinal("FechaRegistro")),
                CodigoBarras = reader.IsDBNull(reader.GetOrdinal("CodigoBarras")) ? null : reader.GetString(reader.GetOrdinal("CodigoBarras")),
                EsKit = reader.GetBoolean(reader.GetOrdinal("EsKit"))
            };
        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            var productos = new List<Producto>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Productos";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            productos.Add(MapearProducto(reader));
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
                var query = "SELECT * FROM Productos WHERE CodigoBarras = @busqueda OR Nombre = @busqueda";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@busqueda", busqueda);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            producto = MapearProducto(reader);
                        }
                    }
                }
            }
            return producto;
        }

        public async Task<Producto> BuscarPorNombreAsync(string nombre)
        {
            Producto producto = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Productos WHERE Nombre = @Nombre";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            producto = MapearProducto(reader);
                        }
                    }
                }
            }
            return producto;
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            Producto producto = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Productos WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            producto = MapearProducto(reader);
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
                var query = @"INSERT INTO Productos (Nombre, Descripcion, Categoria, Proveedor, PrecioCosto, PrecioVenta, Stock, StockMinimo, StockMaximo, CodigoBarras, EsKit)
                              VALUES (@Nombre, @Descripcion, @Categoria, @Proveedor, @PrecioCosto, @PrecioVenta, @Stock, @StockMinimo, @StockMaximo, @CodigoBarras, @EsKit)";
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
                    command.Parameters.AddWithValue("@EsKit", producto.EsKit);
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
                                CodigoBarras = @CodigoBarras,
                                EsKit = @EsKit
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
                    command.Parameters.AddWithValue("@EsKit", producto.EsKit);
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

        public async Task ActualizarStockAsync(int productoId, int cantidadCambio)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE Productos SET Stock = Stock + @CantidadCambio WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CantidadCambio", cantidadCambio);
                    command.Parameters.AddWithValue("@Id", productoId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// Establece una cantidad de stock específica para un producto.
        /// Se utiliza para el ajuste por conteo físico.
        /// </summary>
        public async Task EstablecerStockAsync(int productoId, int nuevoStock)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE Productos SET Stock = @NuevoStock WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevoStock", nuevoStock);
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
                    var result = await command.ExecuteScalarAsync();
                    return result != null ? (int)result : 0;
                }
            }
        }

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
