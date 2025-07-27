using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class KitRepository
    {
        // Cadena de conexión obtenida desde el archivo App.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // Obtiene todos los componentes asociados a un producto tipo Kit
        public async Task<List<KitComponente>> ObtenerComponentesAsync(int kitProductoId)
        {
            var componentes = new List<KitComponente>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = @"
                    SELECT kc.Id, kc.KitProductoId, kc.ComponenteProductoId, p.Nombre AS NombreComponente, kc.Cantidad 
                    FROM KitComponentes kc
                    JOIN Productos p ON kc.ComponenteProductoId = p.Id
                    WHERE kc.KitProductoId = @KitProductoId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KitProductoId", kitProductoId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var componente = new KitComponente
                            {
                                Id = reader.GetInt32(0),
                                KitProductoId = reader.GetInt32(1),
                                ComponenteProductoId = reader.GetInt32(2),
                                NombreComponente = reader.GetString(3),
                                Cantidad = reader.GetInt32(4)
                            };
                            componentes.Add(componente);
                        }
                    }
                }
            }

            return componentes;
        }

        // Inserta un nuevo componente en un Kit ya existente
        public async Task AgregarComponenteAsync(KitComponente componente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = @"
                    INSERT INTO KitComponentes (KitProductoId, ComponenteProductoId, Cantidad)
                    VALUES (@KitProductoId, @ComponenteProductoId, @Cantidad)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@KitProductoId", componente.KitProductoId);
                    command.Parameters.AddWithValue("@ComponenteProductoId", componente.ComponenteProductoId);
                    command.Parameters.AddWithValue("@Cantidad", componente.Cantidad);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Elimina un componente específico de un Kit por su ID
        public async Task EliminarComponenteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM KitComponentes WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
