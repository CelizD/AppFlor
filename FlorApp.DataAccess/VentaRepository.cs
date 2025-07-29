using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class VentaRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;

        public async Task<int> GuardarVentaAsync(Venta venta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var queryVenta = @"INSERT INTO Ventas (Fecha, Cliente, Subtotal, Impuestos, Total, MetodoPago, Vendedor)
                                           OUTPUT INSERTED.Id
                                           VALUES (@Fecha, @Cliente, @Subtotal, @Impuestos, @Total, @MetodoPago, @Vendedor)";
                        int ventaId;
                        using (var command = new SqlCommand(queryVenta, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Fecha", venta.Fecha);
                            command.Parameters.AddWithValue("@Cliente", (object)venta.Cliente ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Subtotal", venta.Subtotal);
                            command.Parameters.AddWithValue("@Impuestos", venta.Impuestos);
                            command.Parameters.AddWithValue("@Total", venta.Total);
                            command.Parameters.AddWithValue("@MetodoPago", (object)venta.MetodoPago ?? DBNull.Value);
                            command.Parameters.AddWithValue("@Vendedor", (object)venta.Vendedor ?? DBNull.Value);
                            ventaId = (int)await command.ExecuteScalarAsync();
                        }

                        foreach (var detalle in venta.Detalles)
                        {
                            var queryDetalle = @"INSERT INTO VentaDetalles (VentaId, ProductoId, NombreProducto, Cantidad, PrecioUnitario, TotalLinea)
                                                 VALUES (@VentaId, @ProductoId, @NombreProducto, @Cantidad, @PrecioUnitario, @TotalLinea)";
                            using (var command = new SqlCommand(queryDetalle, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@VentaId", ventaId);
                                command.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                command.Parameters.AddWithValue("@NombreProducto", detalle.NombreProducto);
                                command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                command.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                                command.Parameters.AddWithValue("@TotalLinea", detalle.TotalLinea);
                                await command.ExecuteNonQueryAsync();
                            }

                            bool esKit = false;
                            var checkKitQuery = "SELECT EsKit FROM Productos WHERE Id = @ProductoId";
                            using (var cmdCheck = new SqlCommand(checkKitQuery, connection, transaction))
                            {
                                cmdCheck.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                var result = await cmdCheck.ExecuteScalarAsync();
                                if (result != null) esKit = (bool)result;
                            }

                            if (esKit)
                            {
                                var getComponentsQuery = "SELECT ComponenteProductoId, Cantidad FROM KitComponentes WHERE KitProductoId = @KitProductoId";
                                using (var cmdComp = new SqlCommand(getComponentsQuery, connection, transaction))
                                {
                                    cmdComp.Parameters.AddWithValue("@KitProductoId", detalle.ProductoId);
                                    using (var reader = await cmdComp.ExecuteReaderAsync())
                                    {
                                        var componentes = new List<Tuple<int, int>>();
                                        while (await reader.ReadAsync())
                                        {
                                            componentes.Add(new Tuple<int, int>(reader.GetInt32(0), reader.GetInt32(1)));
                                        }
                                        reader.Close();

                                        foreach (var componente in componentes)
                                        {
                                            int componenteId = componente.Item1;
                                            int cantidadNecesaria = componente.Item2;
                                            int cantidadTotalADescontar = cantidadNecesaria * detalle.Cantidad;

                                            var updateStockQuery = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE Id = @ComponenteId";
                                            using (var cmdUpdate = new SqlCommand(updateStockQuery, connection, transaction))
                                            {
                                                cmdUpdate.Parameters.AddWithValue("@Cantidad", cantidadTotalADescontar);
                                                cmdUpdate.Parameters.AddWithValue("@ComponenteId", componenteId);
                                                await cmdUpdate.ExecuteNonQueryAsync();
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var queryStock = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE Id = @ProductoId";
                                using (var command = new SqlCommand(queryStock, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                                    command.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                                    await command.ExecuteNonQueryAsync();
                                }
                            }
                        }

                        transaction.Commit();
                        return ventaId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<List<ReporteVenta>> ObtenerReporteVentasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var reporte = new List<ReporteVenta>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT v.Id, v.Fecha, vd.NombreProducto, p.Categoria, vd.Cantidad, vd.PrecioUnitario, vd.TotalLinea
                              FROM Ventas v
                              JOIN VentaDetalles vd ON v.Id = vd.VentaId
                              LEFT JOIN Productos p ON vd.ProductoId = p.Id
                              WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
                              ORDER BY v.Fecha DESC";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin.AddDays(1).AddTicks(-1));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            reporte.Add(new ReporteVenta
                            {
                                VentaId = reader.GetInt32(0),
                                Fecha = reader.GetDateTime(1),
                                Producto = reader.GetString(2),
                                Categoria = reader.IsDBNull(3) ? "N/A" : reader.GetString(3),
                                Cantidad = reader.GetInt32(4),
                                PrecioUnitario = reader.GetDecimal(5),
                                Total = reader.GetDecimal(6)
                            });
                        }
                    }
                }
            }
            return reporte;
        }

        public async Task<decimal> ObtenerTotalVentasHoyAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT SUM(Total) FROM Ventas WHERE CONVERT(date, Fecha) = CONVERT(date, GETDATE())";
                using (var command = new SqlCommand(query, connection))
                {
                    var result = await command.ExecuteScalarAsync();
                    return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                }
            }
        }

        public async Task<Dictionary<string, double>> ObtenerVentasUltimos7DiasAsync()
        {
            var ventasDiarias = new Dictionary<string, double>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                    SELECT 
                        CONVERT(date, Fecha) AS Dia, 
                        SUM(Total) AS TotalVentas
                    FROM Ventas
                    WHERE Fecha >= DATEADD(day, -7, GETDATE())
                    GROUP BY CONVERT(date, Fecha)
                    ORDER BY Dia";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            DateTime dia = reader.GetDateTime(0);
                            double total = Convert.ToDouble(reader.GetDecimal(1));
                            ventasDiarias[dia.ToString("dd/MM")] = total;
                        }
                    }
                }
            }
            return ventasDiarias;
        }

        public async Task<List<ReporteRentabilidad>> ObtenerReporteRentabilidadAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var reporte = new List<ReporteRentabilidad>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                    SELECT 
                        vd.NombreProducto,
                        SUM(vd.Cantidad) AS UnidadesVendidas,
                        SUM(vd.TotalLinea) AS IngresosTotales,
                        SUM(vd.Cantidad * p.PrecioCosto) AS CostoTotal
                    FROM Ventas v
                    JOIN VentaDetalles vd ON v.Id = vd.VentaId
                    JOIN Productos p ON vd.ProductoId = p.Id
                    WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin
                    GROUP BY vd.NombreProducto
                    ORDER BY IngresosTotales DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin.AddDays(1).AddTicks(-1));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = new ReporteRentabilidad
                            {
                                NombreProducto = reader.GetString(0),
                                UnidadesVendidas = reader.GetInt32(1),
                                IngresosTotales = reader.GetDecimal(2),
                                CostoTotal = reader.GetDecimal(3)
                            };
                            item.GananciaNeta = item.IngresosTotales - item.CostoTotal;
                            reporte.Add(item);
                        }
                    }
                }
            }
            return reporte;
        }

        public async Task<List<ReporteVentasPorEmpleado>> ObtenerReporteVentasPorEmpleadoAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var reporte = new List<ReporteVentasPorEmpleado>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                    SELECT 
                        Vendedor,
                        COUNT(Id) AS CantidadVentas,
                        SUM(Total) AS TotalVendido
                    FROM Ventas
                    WHERE Fecha BETWEEN @FechaInicio AND @FechaFin AND Vendedor IS NOT NULL
                    GROUP BY Vendedor
                    ORDER BY TotalVendido DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin.AddDays(1).AddTicks(-1));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            reporte.Add(new ReporteVentasPorEmpleado
                            {
                                Vendedor = reader.GetString(0),
                                CantidadVentas = reader.GetInt32(1),
                                TotalVendido = reader.GetDecimal(2)
                            });
                        }
                    }
                }
            }
            return reporte;
        }

        public async Task<List<VentasPorDia>> ObtenerVentasPorDiaSemanaAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var reporte = new List<VentasPorDia>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                    SET LANGUAGE Spanish;
                    SELECT 
                        DATENAME(weekday, Fecha) AS DiaDeLaSemana,
                        SUM(Total) AS TotalVendido
                    FROM Ventas
                    WHERE Fecha BETWEEN @FechaInicio AND @FechaFin
                    GROUP BY DATENAME(weekday, Fecha), DATEPART(weekday, Fecha)
                    ORDER BY DATEPART(weekday, Fecha)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin.AddDays(1).AddTicks(-1));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            reporte.Add(new VentasPorDia
                            {
                                DiaDeLaSemana = reader.GetString(0),
                                TotalVendido = reader.GetDecimal(1)
                            });
                        }
                    }
                }
            }
            return reporte;
        }

        public async Task<List<VentasPorHora>> ObtenerVentasPorHoraAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            var reporte = new List<VentasPorHora>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
                    SELECT 
                        DATEPART(hour, Fecha) AS Hora,
                        SUM(Total) AS TotalVendido
                    FROM Ventas
                    WHERE Fecha BETWEEN @FechaInicio AND @FechaFin
                    GROUP BY DATEPART(hour, Fecha)
                    ORDER BY Hora";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin.AddDays(1).AddTicks(-1));
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            reporte.Add(new VentasPorHora
                            {
                                Hora = reader.GetInt32(0),
                                TotalVendido = reader.GetDecimal(1)
                            });
                        }
                    }
                }
            }
            return reporte;
        }
    }
}
