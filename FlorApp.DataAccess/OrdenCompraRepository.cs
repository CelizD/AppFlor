using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class OrdenCompraRepository
    {
        private readonly string _connectionString;

        // --- CORRECCIÓN APLICADA AQUÍ ---
        public OrdenCompraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<OrdenCompra>> ObtenerTodasAsync()
        {
            var ordenes = new List<OrdenCompra>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, NombreProveedor, FechaCreacion, FechaRecepcion, Estado, TotalCosto FROM OrdenesCompra ORDER BY FechaCreacion DESC";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ordenes.Add(new OrdenCompra
                            {
                                Id = reader.GetInt32(0),
                                NombreProveedor = reader.GetString(1),
                                FechaCreacion = reader.GetDateTime(2),
                                FechaRecepcion = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                Estado = reader.GetString(4),
                                TotalCosto = reader.GetDecimal(5)
                            });
                        }
                    }
                }
            }
            return ordenes;
        }

        public async Task<List<OrdenCompraDetalle>> ObtenerDetallesAsync(int ordenCompraId)
        {
            var detalles = new List<OrdenCompraDetalle>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, ProductoId, NombreProducto, Cantidad, CostoUnitario FROM OrdenCompraDetalles WHERE OrdenCompraId = @OrdenCompraId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrdenCompraId", ordenCompraId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            detalles.Add(new OrdenCompraDetalle
                            {
                                Id = reader.GetInt32(0),
                                ProductoId = reader.GetInt32(1),
                                NombreProducto = reader.GetString(2),
                                Cantidad = reader.GetInt32(3),
                                CostoUnitario = reader.GetDecimal(4)
                            });
                        }
                    }
                }
            }
            return detalles;
        }

        public async Task GuardarAsync(OrdenCompra orden)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var queryOrden = @"INSERT INTO OrdenesCompra (ProveedorId, NombreProveedor, FechaCreacion, Estado, TotalCosto)
                                           OUTPUT INSERTED.Id
                                           VALUES (@ProveedorId, @NombreProveedor, @FechaCreacion, @Estado, @TotalCosto)";
                        int ordenId;
                        using (var command = new SqlCommand(queryOrden, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ProveedorId", orden.ProveedorId);
                            command.Parameters.AddWithValue("@NombreProveedor", orden.NombreProveedor);
                            command.Parameters.AddWithValue("@FechaCreacion", orden.FechaCreacion);
                            command.Parameters.AddWithValue("@Estado", orden.Estado);
                            command.Parameters.AddWithValue("@TotalCosto", orden.TotalCosto);
                            ordenId = (int)await command.ExecuteScalarAsync();
                        }

                        foreach (var detalle in orden.Detalles)
                        {
                            var queryDetalle = @"INSERT INTO OrdenCompraDetalles (OrdenCompraId, ProductoId, NombreProducto, Cantidad, CostoUnitario)
                                                 VALUES (@OrdenCompraId, @ProductoId, @NombreProducto, @Cantidad, @CostoUnitario)";
                            using (var command = new SqlCommand(queryDetalle, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrdenCompraId", ordenId);
                                command.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                command.Parameters.AddWithValue("@NombreProducto", detalle.NombreProducto);
                                command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                command.Parameters.AddWithValue("@CostoUnitario", detalle.CostoUnitario);
                                await command.ExecuteNonQueryAsync();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task MarcarComoRecibidaAsync(int ordenCompraId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var queryUpdateOrden = "UPDATE OrdenesCompra SET Estado = 'Recibida', FechaRecepcion = GETDATE() WHERE Id = @Id";
                        using (var command = new SqlCommand(queryUpdateOrden, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", ordenCompraId);
                            await command.ExecuteNonQueryAsync();
                        }

                        var detalles = await ObtenerDetallesAsync(ordenCompraId);

                        foreach (var detalle in detalles)
                        {
                            var queryUpdateStock = "UPDATE Productos SET Stock = Stock + @Cantidad WHERE Id = @ProductoId";
                            using (var command = new SqlCommand(queryUpdateStock, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                command.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                await command.ExecuteNonQueryAsync();
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
