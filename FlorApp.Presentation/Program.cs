using FlorApp.DataAccess;
using System;
using System.Windows.Forms;
using FlorApp.Presentation.Forms.Main;
using FlorApp.DataAccess.Models;




namespace FlorApp.Presentation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Habilitar estilos visuales modernos para la aplicación
            Application.EnableVisualStyles(); 

            // Establecer compatibilidad en la forma en que se renderizan los controles
            Application.SetCompatibleTextRenderingDefault(false);

            // Crear el formulario de login
            LoginForm loginForm = new LoginForm();

            // Mostrar el formulario de login de forma modal (bloquea ejecución hasta cerrarse)
            DialogResult result = loginForm.ShowDialog();

            // Verificar si el usuario ingresó correctamente (DialogResult.OK)
            if (result == DialogResult.OK)
            {
                // Obtener el usuario autenticado desde el formulario de login
                Usuario usuario = loginForm.UsuarioAutenticado;

                // Abrir el formulario principal (Dashboard) pasando el usuario autenticado
                Application.Run(new DashboardForm(usuario));
            }
            // Si el usuario cierra o cancela el login, la aplicación termina automáticamente
        }
    }
}
