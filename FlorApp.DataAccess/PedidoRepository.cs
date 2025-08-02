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

        // --- CORRECCIÓN APLICADA AQUÍ ---
        public PedidoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PedidoRepository()
        {
        }

        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            var pedidos = new List<Pedido>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, NombreCliente, Productos, MensajeTarjeta, FechaEntrega, DireccionEntrega, Estado, RepartidorAsignado FROM Pedidos ORDER BY FechaEntrega DESC";
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
            }
            return pedidos;
        }

        public async Task GuardarAsync(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Pedidos (NombreCliente, Productos, MensajeTarjeta, FechaEntrega, DireccionEntrega, Estado, RepartidorAsignado)
                              VALUES (@NombreCliente, @Productos, @MensajeTarjeta, @FechaEntrega, @DireccionEntrega, @Estado, @RepartidorAsignado)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
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
                    command.Parameters.AddWithValue("@Id", pedido.Id);
                    command.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
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
