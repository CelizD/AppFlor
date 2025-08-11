using FlorApp.DataAccess.Models;
using FlorApp.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlorApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Esto define la URL: /api/Productos
    public class ProductosController : ControllerBase
    {
        private readonly ProductoRepository _productoRepository;

        // Constructor: Aquí se prepara todo lo que el controlador necesita.
        public ProductosController()
        {
            // ATENCIÓN: Debes asegurarte de que esta cadena de conexión sea la correcta.
            // La copiamos de tu archivo App.config.
            string connectionString = @"Data Source=DESKTOP-QI5KU12\SQLEXPRESS;Initial Catalog=FloreriaDB;Integrated Security=True";
            _productoRepository = new ProductoRepository(connectionString);
        }

        // Este método responderá a las peticiones GET a /api/Productos
        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosProductos()
        {
            try
            {
                var productos = await _productoRepository.ObtenerTodosAsync();
                return Ok(productos); // Devuelve la lista de productos con un estado 200 OK.
            }
            catch (Exception ex)
            {
                // Si algo sale mal, devuelve un error 500 con el mensaje.
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}