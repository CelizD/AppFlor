using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    // Repositorio encargado de manejar las operaciones CRUD de los pedidos
    public class PedidoRepository
    {
        // Obtiene la cadena de conexión definida en App.config
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        // Obtiene todos los pedidos registrados en la base de datos
        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            var pedidos = new List<Pedido>(); // Lista que almacenará los pedidos recuperados

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre conexión con la base de datos

                var query = @"SELECT Id, NombreCliente, Productos, MensajeTarjeta, 
                                     FechaEntrega, DireccionEntrega, Estado, RepartidorAsignado 
                              FROM Pedidos";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    // Recorre los resultados y construye objetos Pedido
                    while (await reader.ReadAsync())
                    {
                        pedidos.Add(new Pedido
                        {
                            Id = reader.GetInt32(0),
                            NombreCliente = reader.GetString(1),
                            Productos = reader.GetString(2),
                            MensajeTarjeta = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            FechaEntrega = reader.GetDateTime(4),
                            DireccionEntrega = reader.GetString(5),
                            Estado = reader.GetString(6),
                            RepartidorAsignado = reader.IsDBNull(7) ? "" : reader.GetString(7)
                        });
                    }
                }
            }

            return pedidos; // Devuelve la lista completa de pedidos
        }

        // Guarda un nuevo pedido en la base de datos
        public async Task GuardarAsync(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión

                var query = @"INSERT INTO Pedidos 
                             (NombreCliente, Productos, MensajeTarjeta, FechaEntrega, DireccionEntrega, Estado, RepartidorAsignado)
                             VALUES 
                             (@NombreCliente, @Productos, @MensajeTarjeta, @FechaEntrega, @DireccionEntrega, @Estado, @RepartidorAsignado)";

                using (var command = new SqlCommand(query, connection))
                {
                    // Se asignan los valores del pedido como parámetros
                    command.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                    command.Parameters.AddWithValue("@Productos", pedido.Productos);
                    command.Parameters.AddWithValue("@MensajeTarjeta", (object)pedido.MensajeTarjeta ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaEntrega", pedido.FechaEntrega);
                    command.Parameters.AddWithValue("@DireccionEntrega", pedido.DireccionEntrega);
                    command.Parameters.AddWithValue("@Estado", pedido.Estado);
                    command.Parameters.AddWithValue("@RepartidorAsignado", (object)pedido.RepartidorAsignado ?? DBNull.Value);

                    // Ejecuta la inserción
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Actualiza los datos de un pedido existente según su Id
        public async Task ActualizarAsync(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión

                var query = @"UPDATE Pedidos SET 
                                NombreCliente = @NombreCliente, 
                                Productos = @Productos, 
                                MensajeTarjeta = @MensajeTarjeta, 
                                FechaEntrega = @FechaEntrega, 
                                DireccionEntrega = @DireccionEntrega, 
                                Estado = @Estado, 
                                RepartidorAsignado = @RepartidorAsignado
                              WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    // Se asignan los parámetros de actualización
                    command.Parameters.AddWithValue("@Id", pedido.Id);
                    command.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                    command.Parameters.AddWithValue("@Productos", pedido.Productos);
                    command.Parameters.AddWithValue("@MensajeTarjeta", (object)pedido.MensajeTarjeta ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaEntrega", pedido.FechaEntrega);
                    command.Parameters.AddWithValue("@DireccionEntrega", pedido.DireccionEntrega);
                    command.Parameters.AddWithValue("@Estado", pedido.Estado);
                    command.Parameters.AddWithValue("@RepartidorAsignado", (object)pedido.RepartidorAsignado ?? DBNull.Value);

                    // Ejecuta la actualización
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Elimina un pedido de la base de datos usando su Id
        public async Task EliminarAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(); // Abre la conexión

                var query = "DELETE FROM Pedidos WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Asigna el parámetro
                    await command.ExecuteNonQueryAsync(); // Ejecuta la eliminación
                }
            }
        }
    }
}
