using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    // Repositorio encargado de gestionar los movimientos del inventario
    public class MovimientoInventarioRepository
    {
        // Cadena de conexión obtenida del archivo de configuración App.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // Guarda un nuevo movimiento de inventario en la base de datos
        public async Task GuardarAsync(MovimientoInventario movimiento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión a la base de datos

                // Consulta SQL para insertar un nuevo registro de movimiento
                var query = @"
                    INSERT INTO MovimientosInventario 
                    (ProductoId, NombreProducto, TipoMovimiento, Cantidad, Fecha, Motivo)
                    VALUES (@ProductoId, @NombreProducto, @TipoMovimiento, @Cantidad, @Fecha, @Motivo)";

                using (var command = new SqlCommand(query, connection))
                {
                    // Asigna parámetros con valores del objeto 'movimiento'
                    command.Parameters.AddWithValue("@ProductoId", movimiento.ProductoId);
                    command.Parameters.AddWithValue("@NombreProducto", movimiento.NombreProducto);
                    command.Parameters.AddWithValue("@TipoMovimiento", movimiento.TipoMovimiento);
                    command.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                    command.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
                    command.Parameters.AddWithValue("@Motivo", (object)movimiento.Motivo ?? DBNull.Value); // Valor nulo si no hay motivo

                    // Ejecuta la instrucción SQL de manera asíncrona
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Obtiene todos los movimientos de inventario registrados, ordenados por fecha descendente
        public async Task<List<MovimientoInventario>> ObtenerTodosAsync()
        {
            var movimientos = new List<MovimientoInventario>(); // Lista que almacenará los resultados

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión

                // Consulta SQL para obtener todos los movimientos ordenados por fecha (más recientes primero)
                var query = @"
                    SELECT Id, ProductoId, NombreProducto, TipoMovimiento, Cantidad, Fecha, Motivo 
                    FROM MovimientosInventario 
                    ORDER BY Fecha DESC";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync()) // Ejecuta y lee los resultados
                {
                    while (await reader.ReadAsync()) // Recorre cada fila
                    {
                        // Crea un nuevo objeto MovimientoInventario con los datos leídos
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

            return movimientos; // Devuelve la lista completa
        }
    }
}
