using FlorApp.DataAccess;
using System;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Crear y mostrar el formulario de login
            LoginForm loginForm = new LoginForm();
            DialogResult result = loginForm.ShowDialog();

            // 2. Verificar si el inicio de sesión fue exitoso
            if (result == DialogResult.OK)
            {
                // 3. Si fue exitoso, obtener el usuario y abrir el Dashboard
                Usuario usuario = loginForm.UsuarioAutenticado;
                Application.Run(new DashboardForm(usuario)); // Pasamos el usuario al Dashboard
            }
            // Si el resultado no es OK (el usuario cerró la ventana o canceló), la aplicación simplemente terminará.
        }
    }
}