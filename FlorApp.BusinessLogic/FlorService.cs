using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorApp.DataAccess;

namespace FlorApp.BusinessLogic
{
    // Clase que contiene la lógica de negocio relacionada con las flores
    public class FlorService
    {
        // Instancia del repositorio para acceder a los datos de la base de datos
        private readonly FlorRepository _florRepository = new FlorRepository();

        // Método que permite registrar una nueva flor en el sistema
        public string RegistrarFlor(string nombre)
        {
            // Verifica si el nombre de la flor es válido
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return "El nombre de la flor no puede estar vacío.";
            }

            // Crea un nuevo objeto Flor con el nombre proporcionado
            var nuevaFlor = new Flor
            {
                Nombre = nombre
            };

            // Llama al repositorio para guardar la flor y devuelve el resultado
            return _florRepository.GuardarFlor(nuevaFlor);
        }
    }
}

