using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class UsuarioRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            var usuarios = new List<Usuario>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, NombreUsuario, Rol FROM Usuarios"; // No obtenemos la contraseña por seguridad
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            usuarios.Add(new Usuario
                            {
                                Id = reader.GetInt32(0),
                                NombreUsuario = reader.GetString(1),
                                Rol = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public async Task GuardarAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Usuarios (NombreUsuario, Contrasena, Rol) VALUES (@NombreUsuario, @Contrasena, @Rol)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    command.Parameters.AddWithValue("@Rol", usuario.Rol);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Usuarios WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
