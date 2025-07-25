using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    /// Proporciona métodos para interactuar con la base de datos para la entidad Cliente.
    /// Esta clase maneja las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y actualizaciones específicas.
    public class ClienteRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        /// Obtiene asincrónicamente una lista de todos los clientes de la base de datos.
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea es una lista de objetos Cliente.</returns>
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

        /// Guarda asincrónicamente un nuevo cliente en la base de datos.
        /// <param name="cliente">El objeto Cliente a guardar.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
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

        /// Actualiza asincrónicamente un cliente existente en la base de datos.
        /// <param name="cliente">El objeto Cliente con los datos actualizados.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
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

        /// Elimina asincrónicamente un cliente de la base de datos por su ID.
        /// <param name="id">El ID del cliente a eliminar.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
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

        /// Actualiza asincrónicamente los puntos de lealtad y el total gastado de un cliente específico.
        /// Suma el 'totalCompra' al 'TotalGastado' existente del cliente.
        /// <param name="clienteId">El ID del cliente a actualizar.</param>
        /// <param name="puntos">Los nuevos puntos de lealtad del cliente.</param>
        /// <param name="totalCompra">El monto de la compra actual para agregar al total gastado.</param>
        /// <returns>Una tarea que representa la operación asíncrona.</returns>
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
    }
}