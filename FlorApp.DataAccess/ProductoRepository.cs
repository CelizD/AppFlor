using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FlorApp.DataAccess;

namespace FlorApp.DataAccess
{
    public class ProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private Producto MapearProducto(SqlDataReader reader)
        {
            return new Producto
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),

                // --- LÍNEA MEJORADA (TAL COMO LA PEDISTE) ---
                // Revisa si el valor es NULL. Si lo es, asigna 0 (o un valor por defecto), si no, lee el número.
                ProveedorId = reader.IsDBNull(reader.GetOrdinal("ProveedorId")) ? 0 : reader.GetInt32(reader.GetOrdinal("ProveedorId")),

                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString(reader.GetOrdinal("Descripcion")),
                Categoria = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? null : reader.GetString(reader.GetOrdinal("Categoria")),
                PrecioCosto = reader.GetDecimal(reader.GetOrdinal("PrecioCosto")),
                PrecioVenta = reader.GetDecimal(reader.GetOrdinal("PrecioVenta")),
                Stock = reader.GetInt32(reader.GetOrdinal("Stock")),
                StockMinimo = reader.GetInt32(reader.GetOrdinal("StockMinimo")),
                StockMaximo = reader.GetInt32(reader.GetOrdinal("StockMaximo")),
                FechaRegistro = reader.GetDateTime(reader.GetOrdinal("FechaRegistro")),
                CodigoBarras = reader.IsDBNull(reader.GetOrdinal("CodigoBarras")) ? null : reader.GetString(reader.GetOrdinal("CodigoBarras")),
                EsKit = reader.GetBoolean(reader.GetOrdinal("EsKit")),
                ColoresDisponibles = reader.IsDBNull(reader.GetOrdinal("ColoresDisponibles")) ? null : reader.GetString(reader.GetOrdinal("ColoresDisponibles")),
                Foto = reader.IsDBNull(reader.GetOrdinal("Foto")) ? null : (byte[])reader["Foto"]
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
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        productos.Add(MapearProducto(reader));
                    }
                }
            }
            return productos;
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
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
                            return MapearProducto(reader);
                        }
                    }
                }
            }
            return null;
        }

        public async Task<Producto> BuscarPorNombreAsync(string nombre)
        {
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
                            return MapearProducto(reader);
                        }
                    }
                }
            }
            return null;
        }

        public async Task<Producto> BuscarPorCodigoONombreAsync(string busqueda)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Productos WHERE CodigoBarras = @busqueda OR Nombre LIKE @busquedaLike";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@busqueda", busqueda);
                    command.Parameters.AddWithValue("@busquedaLike", $"%{busqueda}%");
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapearProducto(reader);
                        }
                    }
                }
            }
            return null;
        }

        public async Task GuardarAsync(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Productos (Nombre, Descripcion, Categoria, ProveedorId, PrecioCosto, PrecioVenta, Stock, StockMinimo, StockMaximo, CodigoBarras, EsKit, ColoresDisponibles, Foto, FechaRegistro)
                              VALUES (@Nombre, @Descripcion, @Categoria, @ProveedorId, @PrecioCosto, @PrecioVenta, @Stock, @StockMinimo, @StockMaximo, @CodigoBarras, @EsKit, @ColoresDisponibles, @Foto, @FechaRegistro)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", (object)producto.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Categoria", (object)producto.Categoria ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProveedorId", producto.ProveedorId);
                    command.Parameters.AddWithValue("@PrecioCosto", producto.PrecioCosto);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
                    command.Parameters.AddWithValue("@StockMaximo", producto.StockMaximo);
                    command.Parameters.AddWithValue("@CodigoBarras", (object)producto.CodigoBarras ?? DBNull.Value);
                    command.Parameters.AddWithValue("@EsKit", producto.EsKit);
                    command.Parameters.AddWithValue("@ColoresDisponibles", (object)producto.ColoresDisponibles ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Foto", (object)producto.Foto ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaRegistro", producto.FechaRegistro);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarAsync(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Productos 
                              SET Nombre = @Nombre, Descripcion = @Descripcion, Categoria = @Categoria, ProveedorId = @ProveedorId, 
                                  PrecioCosto = @PrecioCosto, PrecioVenta = @PrecioVenta, StockMinimo = @StockMinimo, StockMaximo = @StockMaximo, 
                                  CodigoBarras = @CodigoBarras, EsKit = @EsKit, ColoresDisponibles = @ColoresDisponibles, Foto = @Foto 
                              WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", (object)producto.Descripcion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Categoria", (object)producto.Categoria ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProveedorId", producto.ProveedorId);
                    command.Parameters.AddWithValue("@PrecioCosto", producto.PrecioCosto);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
                    command.Parameters.AddWithValue("@StockMaximo", producto.StockMaximo);
                    command.Parameters.AddWithValue("@CodigoBarras", (object)producto.CodigoBarras ?? DBNull.Value);
                    command.Parameters.AddWithValue("@EsKit", producto.EsKit);
                    command.Parameters.AddWithValue("@ColoresDisponibles", (object)producto.ColoresDisponibles ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Foto", (object)producto.Foto ?? DBNull.Value);
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
                var query = "SELECT * FROM Productos WHERE Stock <= StockMinimo";
                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        productos.Add(MapearProducto(reader));
                    }
                }
            }
            return productos;
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
    }
}