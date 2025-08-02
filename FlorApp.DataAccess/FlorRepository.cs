using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    // Repositorio encargado de manejar todas las operaciones CRUD de las flores
    public class FlorRepository
    {
        // Obtiene la cadena de conexión desde el archivo App.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // Método para guardar una nueva flor en la base de datos
        public string GuardarFlor(Flor flor)
        {
            try
            {
                // Se establece una conexión con la base de datos
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open(); // Abre la conexión

                    // Sentencia SQL para insertar una flor
                    string query = "INSERT INTO Flores (Nombre, FechaRegistro) VALUES (@Nombre, @FechaRegistro)";

                    // Se crea el comando con la consulta y la conexión
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Se asignan los valores de los parámetros de forma segura
                        command.Parameters.AddWithValue("@Nombre", flor.Nombre);
                        command.Parameters.AddWithValue("@FechaRegistro", DateTime.Now); // Fecha actual

                        // Ejecuta la consulta SQL y devuelve el número de filas afectadas
                        int result = command.ExecuteNonQuery();

                        // Si se afectó al menos una fila, se considera exitoso
                        return result > 0
                            ? $"Flor '{flor.Nombre}' registrada exitosamente."
                            : "Error: No se pudo registrar la flor.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Captura y devuelve cualquier error ocurrido
                return $"Ocurrió un error: {ex.Message}";
            }
        }

        // Método para obtener todas las flores registradas
        public List<Flor> ObtenerTodasLasFlores()
        {
            var flores = new List<Flor>(); // Lista para almacenar los resultados

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open(); // Abre la conexión

                    // Consulta SQL para obtener todas las flores
                    string query = "SELECT Id, Nombre, FechaRegistro FROM Flores";

                    // Se prepara el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader()) // Ejecuta y obtiene un lector
                    {
                        while (reader.Read()) // Recorre cada fila del resultado
                        {
                            // Crea una nueva instancia de Flor y la llena con los datos leídos
                            var flor = new Flor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                            };

                            // Agrega la flor a la lista
                            flores.Add(flor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra el error en la consola si ocurre
                Console.WriteLine("Error al obtener flores: " + ex.Message);
            }

            return flores; // Devuelve la lista de flores
        }

        // Método para actualizar el nombre de una flor existente
        public void ActualizarFlor(Flor flor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open(); // Abre la conexión

                    // Consulta SQL para actualizar una flor según su Id
                    string query = "UPDATE Flores SET Nombre = @Nombre WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Asigna los parámetros al comando
                        command.Parameters.AddWithValue("@Nombre", flor.Nombre);
                        command.Parameters.AddWithValue("@Id", flor.Id);

                        // Ejecuta la instrucción de actualización
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra el error en la consola
                Console.WriteLine("Error al actualizar la flor: " + ex.Message);
            }
        }

        // Método para eliminar una flor usando su Id
        public void EliminarFlor(int idFlor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open(); // Abre la conexión

                    // Consulta SQL para eliminar una flor por Id
                    string query = "DELETE FROM Flores WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Asigna el Id como parámetro
                        command.Parameters.AddWithValue("@Id", idFlor);

                        // Ejecuta la instrucción de eliminación
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra el error en la consola
                Console.WriteLine("Error al eliminar la flor: " + ex.Message);
            }
        }

        public Task<List<Flor>> ObtenerTodasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
