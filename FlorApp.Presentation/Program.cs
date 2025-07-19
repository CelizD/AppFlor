using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    internal static class Program
    {
        // Punto de entrada principal para la aplicación
        [STAThread]
        static void Main()
        {
            // Habilita estilos visuales para la aplicación
            Application.EnableVisualStyles();

            // Configura el renderizado compatible con texto
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la ejecución con el formulario principal Form1
            Application.Run(new Form1());
        }
    }
}
