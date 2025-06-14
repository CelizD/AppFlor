using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorApp.DataAccess
{
    public class FlorRepository
    {
        public string GuardarFlor(string nombre)
        {
            return $"Flor '{nombre}' registrada en la base de datos.";
        }
    }
}
