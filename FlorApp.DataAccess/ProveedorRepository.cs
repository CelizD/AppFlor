using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class ProveedorRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        public async Task<List<Proveedor>> ObtenerTodosAsync()
        {
            var proveedores = new List<Proveedor>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, NombreEmpresa, NombreContacto, Telefono, Email, Direccion FROM Proveedores";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            proveedores.Add(new Proveedor
                            {
                                Id = reader.GetInt32(0),
                                NombreEmpresa = reader.GetString(1),
                                NombreContacto = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Telefono = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Direccion = reader.IsDBNull(5) ? "" : reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return proveedores;
        }

        public async Task GuardarAsync(Proveedor proveedor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Proveedores (NombreEmpresa, NombreContacto, Telefono, Email, Direccion)
                              VALUES (@NombreEmpresa, @NombreContacto, @Telefono, @Email, @Direccion)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreEmpresa", proveedor.NombreEmpresa);
                    command.Parameters.AddWithValue("@NombreContacto", (object)proveedor.NombreContacto ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Telefono", (object)proveedor.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)proveedor.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Direccion", (object)proveedor.Direccion ?? DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarAsync(Proveedor proveedor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"UPDATE Proveedores SET 
                                NombreEmpresa = @NombreEmpresa, 
                                NombreContacto = @NombreContacto, 
                                Telefono = @Telefono, 
                                Email = @Email, 
                                Direccion = @Direccion
                              WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", proveedor.Id);
                    command.Parameters.AddWithValue("@NombreEmpresa", proveedor.NombreEmpresa);
                    command.Parameters.AddWithValue("@NombreContacto", (object)proveedor.NombreContacto ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Telefono", (object)proveedor.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)proveedor.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Direccion", (object)proveedor.Direccion ?? DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Proveedores WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
