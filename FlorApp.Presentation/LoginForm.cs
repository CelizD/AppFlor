using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class LoginForm : Form
    {
        // Propiedad pública para acceder al usuario que inició sesión
        public Usuario UsuarioAutenticado { get; private set; }

        // Simulación de base de datos de usuarios
        private List<Usuario> _usuariosRegistrados;

        public LoginForm()
        {
            InitializeComponent();
            CargarUsuariosDeEjemplo();
        }

        private void CargarUsuariosDeEjemplo()
        {
            _usuariosRegistrados = new List<Usuario>
            {
                new Usuario { Id = 1, NombreUsuario = "admin", Contrasena = "123", Rol = "Administrador" },
                new Usuario { Id = 2, NombreUsuario = "vendedor", Contrasena = "123", Rol = "Vendedor" }
            };
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            // Buscar al usuario en nuestra lista de simulación
            var usuario = _usuariosRegistrados.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);

            if (usuario != null)
            {
                // Si el usuario es válido, lo guardamos y cerramos el formulario
                this.UsuarioAutenticado = usuario;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Si no es válido, mostramos un mensaje de error
                lblError.Visible = true;
            }
        }
    }
}
