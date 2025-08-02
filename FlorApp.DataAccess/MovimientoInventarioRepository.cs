using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class MovimientoInventarioRepository
    {
        private readonly string _connectionString;

        // --- CORRECCIÓN APLICADA AQUÍ ---
        // El repositorio ahora recibe la cadena de conexión desde la capa que lo crea.
        public MovimientoInventarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task GuardarAsync(MovimientoInventario movimiento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO MovimientosInventario (ProductoId, NombreProducto, TipoMovimiento, Cantidad, Fecha, Motivo)
                              VALUES (@ProductoId, @NombreProducto, @TipoMovimiento, @Cantidad, @Fecha, @Motivo)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductoId", movimiento.ProductoId);
                    command.Parameters.AddWithValue("@NombreProducto", movimiento.NombreProducto);
                    command.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                    command.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                    command.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                    command.Parameters.AddWithValue("@Motivo", (object)movimiento.Motivo ?? DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<MovimientoInventario>> ObtenerTodosAsync()
        {
            var movimientos = new List<MovimientoInventario>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, ProductoId, NombreProducto, TipoMovimiento, Cantidad, Fecha, Motivo FROM MovimientosInventario ORDER BY Fecha DESC";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            movimientos.Add(new MovimientoInventario
                            {
                                Id = reader.GetInt32(0),
                                ProductoId = reader.GetInt32(1),
                                NombreProducto = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                TipoMovimiento = reader.GetString(3),
                                Cantidad = reader.GetInt32(4),
                                Fecha = reader.GetDateTime(5),
                                Motivo = reader.IsDBNull(6) ? "" : reader.GetString(6)
                            });
                        }
                    }
                }
            }
            return movimientos;
        }
    }
}
