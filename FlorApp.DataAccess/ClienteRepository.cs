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
                            clientes.Add(new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Telefono = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Direccion = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                FechaEspecial = reader.IsDBNull(5) ? (DateTime?)null : reader.GetDateTime(5),
                                Puntos = reader.GetInt32(6),
                                TipoMembresia = reader.GetString(7),
                                TotalGastado = reader.GetDecimal(8)
                            });
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
    }
}
