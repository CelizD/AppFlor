using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorApp.DataAccess;

namespace FlorApp.BusinessLogic
{

    public class FlorService
    {
        private FlorRepository _repo = new FlorRepository();

        public string RegistrarFlor(string nombre)
        {
            return _repo.GuardarFlor(nombre);
        }
    }
}
