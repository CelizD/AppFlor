using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    // Repositorio para manejar operaciones CRUD de proveedores
    public class ProveedorRepository
    {
        // Cadena de conexión al servidor de base de datos, desde App.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // Obtiene la lista completa de proveedores almacenados
        public async Task<List<Proveedor>> ObtenerTodosAsync()
        {
            var proveedores = new List<Proveedor>(); // Lista para almacenar resultados
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión

                var query = "SELECT Id, NombreEmpresa, NombreContacto, Telefono, Email, Direccion FROM Proveedores";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync()) // Lee fila por fila
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
            return proveedores; // Devuelve lista completa
        }

        // Inserta un nuevo proveedor en la base de datos
        public async Task GuardarAsync(Proveedor proveedor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión

                var query = @"INSERT INTO Proveedores (NombreEmpresa, NombreContacto, Telefono, Email, Direccion)
                              VALUES (@NombreEmpresa, @NombreContacto, @Telefono, @Email, @Direccion)";

                using (var command = new SqlCommand(query, connection))
                {
                    // Parámetros con valores del objeto proveedor
                    command.Parameters.AddWithValue("@NombreEmpresa", proveedor.NombreEmpresa);
                    command.Parameters.AddWithValue("@NombreContacto", (object)proveedor.NombreContacto ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Telefono", (object)proveedor.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)proveedor.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Direccion", (object)proveedor.Direccion ?? DBNull.Value);

                    await command.ExecuteNonQueryAsync(); // Ejecuta INSERT
                }
            }
        }

        // Actualiza la información de un proveedor existente
        public async Task ActualizarAsync(Proveedor proveedor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre conexión

                var query = @"UPDATE Proveedores SET 
                                NombreEmpresa = @NombreEmpresa, 
                                NombreContacto = @NombreContacto, 
                                Telefono = @Telefono, 
                                Email = @Email, 
                                Direccion = @Direccion
                              WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    // Parámetros con datos para la actualización
                    command.Parameters.AddWithValue("@Id", proveedor.Id);
                    command.Parameters.AddWithValue("@NombreEmpresa", proveedor.NombreEmpresa);
                    command.Parameters.AddWithValue("@NombreContacto", (object)proveedor.NombreContacto ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Telefono", (object)proveedor.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)proveedor.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Direccion", (object)proveedor.Direccion ?? DBNull.Value);

                    await command.ExecuteNonQueryAsync(); // Ejecuta UPDATE
                }
            }
        }

        // Elimina un proveedor de la base de datos por su Id
        public async Task EliminarAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre conexión

                var query = "DELETE FROM Proveedores WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Parámetro con el Id
                    await command.ExecuteNonQueryAsync(); // Ejecuta DELETE
                }
            }
        }
    }
}
