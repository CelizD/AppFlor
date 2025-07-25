using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    // Repositorio para manejar operaciones CRUD de usuarios
    public class UsuarioRepository
    {
        // Cadena de conexión a la base de datos desde App.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // Obtiene todos los usuarios sin incluir la contraseña por seguridad
        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            var usuarios = new List<Usuario>(); // Lista para almacenar resultados
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión
                var query = "SELECT Id, NombreUsuario, Rol FROM Usuarios"; // Consulta sin contraseña

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync()) // Lee cada fila
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
            return usuarios; // Devuelve la lista completa
        }

        // Inserta un nuevo usuario con su contraseña y rol
        public async Task GuardarAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión
                var query = @"INSERT INTO Usuarios (NombreUsuario, Contrasena, Rol) VALUES (@NombreUsuario, @Contrasena, @Rol)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    command.Parameters.AddWithValue("@Rol", usuario.Rol);
                    await command.ExecuteNonQueryAsync(); // Ejecuta el INSERT
                }
            }
        }

        // Elimina un usuario según su Id
        public async Task EliminarAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión
                var query = "DELETE FROM Usuarios WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync(); // Ejecuta el DELETE
                }
            }
        }
    }
}
