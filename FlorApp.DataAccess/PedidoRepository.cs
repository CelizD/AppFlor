using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class PedidoRepository
    {
        private readonly string _connectionString;

        public PedidoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            var pedidos = new List<Pedido>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                // --- QUERY ACTUALIZADA ---
                var query = "SELECT Id, NombreCliente, Telefono, Email, Origen, Productos, MensajeTarjeta, FechaEntrega, DireccionEntrega, Estado, RepartidorAsignado FROM Pedidos ORDER BY FechaEntrega DESC";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            pedidos.Add(new Pedido
                            {
                                Id = reader.GetInt32(0),
                                NombreCliente = reader.GetString(1),
                                Telefono = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Email = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Origen = reader.IsDBNull(4) ? "Manual" : reader.GetString(4),
                                Productos = reader.GetString(5),
                                MensajeTarjeta = reader.IsDBNull(6) ? "" : reader.GetString(6),
                                FechaEntrega = reader.GetDateTime(7),
                                DireccionEntrega = reader.GetString(8),
                                Estado = reader.GetString(9),
                                RepartidorAsignado = reader.IsDBNull(10) ? "" : reader.GetString(10)
                            });
                        }
                    }
                }
            }
            return pedidos;
        }

        public async Task GuardarAsync(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                // --- QUERY ACTUALIZADA ---
                var query = @"INSERT INTO Pedidos (NombreCliente, Telefono, Email, Origen, Productos, MensajeTarjeta, FechaEntrega, DireccionEntrega, Estado, RepartidorAsignado)
                              VALUES (@NombreCliente, @Telefono, @Email, @Origen, @Productos, @MensajeTarjeta, @FechaEntrega, @DireccionEntrega, @Estado, @RepartidorAsignado)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                    command.Parameters.AddWithValue("@Telefono", (object)pedido.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)pedido.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Origen", (object)pedido.Origen ?? "Manual");
                    command.Parameters.AddWithValue("@Productos", pedido.Productos);
                    command.Parameters.AddWithValue("@MensajeTarjeta", (object)pedido.MensajeTarjeta ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaEntrega", pedido.FechaEntrega);
                    command.Parameters.AddWithValue("@DireccionEntrega", pedido.DireccionEntrega);
                    command.Parameters.AddWithValue("@Estado", pedido.Estado);
                    command.Parameters.AddWithValue("@RepartidorAsignado", (object)pedido.RepartidorAsignado ?? DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ActualizarAsync(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                // --- QUERY ACTUALIZADA ---
                var query = @"UPDATE Pedidos SET 
                                NombreCliente = @NombreCliente, 
                                Telefono = @Telefono,
                                Email = @Email,
                                Origen = @Origen,
                                Productos = @Productos, 
                                MensajeTarjeta = @MensajeTarjeta, 
                                FechaEntrega = @FechaEntrega, 
                                DireccionEntrega = @DireccionEntrega, 
                                Estado = @Estado, 
                                RepartidorAsignado = @RepartidorAsignado
                              WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", pedido.Id);
                    command.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                    command.Parameters.AddWithValue("@Telefono", (object)pedido.Telefono ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Email", (object)pedido.Email ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Origen", (object)pedido.Origen ?? "Manual");
                    command.Parameters.AddWithValue("@Productos", pedido.Productos);
                    command.Parameters.AddWithValue("@MensajeTarjeta", (object)pedido.MensajeTarjeta ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaEntrega", pedido.FechaEntrega);
                    command.Parameters.AddWithValue("@DireccionEntrega", pedido.DireccionEntrega);
                    command.Parameters.AddWithValue("@Estado", pedido.Estado);
                    command.Parameters.AddWithValue("@RepartidorAsignado", (object)pedido.RepartidorAsignado ?? DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "DELETE FROM Pedidos WHERE Id = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
