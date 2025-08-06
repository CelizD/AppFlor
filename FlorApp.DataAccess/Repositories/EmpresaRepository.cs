using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FlorApp.DataAccess.Models;

namespace FlorApp.DataAccess.Repositories
{
    public class EmpresaRepository
    {
        // Cadena de conexión obtenida desde el archivo de configuración
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // Obtiene los datos de la empresa con Id = 1
        public async Task<Empresa> ObtenerDatosAsync()
        {
            Empresa empresa = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Nombre, Direccion, Telefono, Logo FROM Empresa WHERE Id = 1";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        empresa = new Empresa
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            Direccion = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            Telefono = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            Logo = reader.IsDBNull(4) ? null : (byte[])reader["Logo"]
                        };
                    }
                }
            }

            return empresa;
        }

        // Guarda los datos modificados de la empresa con Id = 1
        public async Task GuardarAsync(Empresa empresa)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                    UPDATE Empresa SET 
                        Nombre = @Nombre, 
                        Direccion = @Direccion, 
                        Telefono = @Telefono, 
                        Logo = @Logo
                    WHERE Id = 1";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", empresa.Nombre);
                    command.Parameters.AddWithValue("@Direccion", empresa.Direccion);
                    command.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                    command.Parameters.AddWithValue("@Logo", (object)empresa.Logo ?? DBNull.Value);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
