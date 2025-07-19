using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FlorApp.DataAccess
{
    // Esta clase se encarga de gestionar el acceso a los datos relacionados con las flores
    public class FlorRepository
    {
        // Contiene la cadena de conexión extraída del archivo App.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // Guarda una flor en la base de datos
        public string GuardarFlor(Flor flor)
        {
            try
            {
                // Abre una conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Consulta SQL para insertar una nueva flor
                    string query = "INSERT INTO Flores (Nombre, FechaRegistro) VALUES (@Nombre, @FechaRegistro)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Asigna los valores a los parámetros para evitar inyección SQL
                        command.Parameters.AddWithValue("@Nombre", flor.Nombre);
                        command.Parameters.AddWithValue("@FechaRegistro", DateTime.Now);

                        // Ejecuta el comando de inserción
                        int result = command.ExecuteNonQuery();

                        // Verifica si la operación fue exitosa
                        if (result > 0)
                        {
                            return $"Flor '{flor.Nombre}' registrada exitosamente.";
                        }
                        else
                        {
                            return "Error: No se pudo registrar la flor.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Retorna el mensaje de error si ocurre una excepción
                return $"Ocurrió un error: {ex.Message}";
            }
        }

        // Obtiene la lista de todas las flores almacenadas en la base de datos
        public List<Flor> ObtenerTodasLasFlores()
        {
            var flores = new List<Flor>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, Nombre, FechaRegistro FROM Flores";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var flor = new Flor
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                                };
                                flores.Add(flor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra el error en la consola si ocurre una excepción
                Console.WriteLine("Error al obtener flores: " + ex.Message);
            }
            return flores;
        }

        // Actualiza los datos de una flor existente en la base de datos
        public void ActualizarFlor(Flor flor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Consulta SQL para actualizar el nombre de una flor
                    string query = "UPDATE Flores SET Nombre = @Nombre WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", flor.Nombre);
                        command.Parameters.AddWithValue("@Id", flor.Id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar la flor: " + ex.Message);
            }
        }

        // Elimina una flor de la base de datos utilizando su identificador
        public void EliminarFlor(int idFlor)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Consulta SQL para eliminar una flor por su Id
                    string query = "DELETE FROM Flores WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", idFlor);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar la flor: " + ex.Message);
            }
        }
    }
}
