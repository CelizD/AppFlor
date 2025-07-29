using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class ClienteRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // --- Mapeador reutilizable para no repetir código ---
        private Cliente MapearCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? "" : reader.GetString(reader.GetOrdinal("Direccion")),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email")),
                FechaEspecial = reader.IsDBNull(reader.GetOrdinal("FechaEspecial")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEspecial")),
                Puntos = reader.GetInt32(reader.GetOrdinal("Puntos")),
                TipoMembresia = reader.GetString(reader.GetOrdinal("TipoMembresia")),
                TotalGastado = reader.GetDecimal(reader.GetOrdinal("TotalGastado"))
            };
        }

        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            var clientes = new List<Cliente>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Nombre, Telefono, Direccion, Email, FechaEspecial, Puntos, TipoMembresia, TotalGastado FROM Clientes";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(MapearCliente(reader));
                        }
                    }
                }
            }
            return clientes;
        }

        /// <summary>
        /// Obtiene una lista de clientes filtrada por su tipo de membresía.
        /// </summary>
        public async Task<List<Cliente>> ObtenerPorFiltroAsync(string tipoMembresia)
        {
            if (string.IsNullOrEmpty(tipoMembresia) || tipoMembresia == "Todos")
            {
                return await ObtenerTodosAsync();
            }

            var clientes = new List<Cliente>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Nombre, Telefono, Direccion, Email, FechaEspecial, Puntos, TipoMembresia, TotalGastado FROM Clientes WHERE TipoMembresia = @TipoMembresia";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TipoMembresia", tipoMembresia);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(MapearCliente(reader));
                        }
                    }
                }
            }
            return clientes;
        }

        public async Task GuardarAsync(Cliente cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Clientes (Nombre, Telefono, Direccion, Email, FechaEspecial, Puntos, TipoMembresia, TotalGastado)
                              VALUES (@Nombre, @Telefono, @Direccion, @Email, @FechaEspecial, @Puntos, @TipoMembresia, @TotalGastado)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Telefono", (object)cliente.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Direccion", (object)cliente.Direccion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)cliente.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaEspecial", (object)cliente.FechaEspecial ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Puntos", cliente.Puntos);
                    command.Parameters.AddWithValue("@TipoMembresia", cliente.TipoMembresia);
                    command.Parameters.AddWithValue("@TotalGastado", cliente.TotalGastado);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarAsync(Cliente cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Clientes SET 
                                Nombre = @Nombre, 
                                Telefono = @Telefono, 
                                Direccion = @Direccion, 
                                Email = @Email, 
                                FechaEspecial = @FechaEspecial, 
                                Puntos = @Puntos, 
                                TipoMembresia = @TipoMembresia,
                                TotalGastado = @TotalGastado
                              WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", cliente.Id);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Telefono", (object)cliente.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Direccion", (object)cliente.Direccion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)cliente.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaEspecial", (object)cliente.FechaEspecial ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Puntos", cliente.Puntos);
                    command.Parameters.AddWithValue("@TipoMembresia", cliente.TipoMembresia);
                    command.Parameters.AddWithValue("@TotalGastado", cliente.TotalGastado);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Clientes WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarPuntosYTotalGastadoAsync(int clienteId, int puntos, decimal totalCompra)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Clientes 
                              SET Puntos = @Puntos, 
                                  TotalGastado = TotalGastado + @TotalCompra
                              WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Puntos", puntos);
                    command.Parameters.AddWithValue("@TotalCompra", totalCompra);
                    command.Parameters.AddWithValue("@Id", clienteId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<Cliente>> ObtenerConFechasEspecialesProximasAsync(int proximosDias)
        {
            var clientes = new List<Cliente>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                    SELECT Id, Nombre, FechaEspecial, Telefono, Email
                    FROM Clientes
                    WHERE 
                        (DATEFROMPARTS(YEAR(GETDATE()), MONTH(FechaEspecial), DAY(FechaEspecial)) 
                        BETWEEN GETDATE() AND DATEADD(day, @ProximosDias, GETDATE()))
                        OR
                        (DATEFROMPARTS(YEAR(GETDATE()) + 1, MONTH(FechaEspecial), DAY(FechaEspecial)) 
                        BETWEEN GETDATE() AND DATEADD(day, @ProximosDias, GETDATE()))";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProximosDias", proximosDias);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            clientes.Add(new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                FechaEspecial = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                                Telefono = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? "" : reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return clientes;
        }
    }
}
