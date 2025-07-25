using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class LoginForm : Form
    {
        // Propiedad para guardar el usuario autenticado tras login exitoso
        public Usuario UsuarioAutenticado { get; private set; }

        // Lista simulada de usuarios registrados para validar el login
        private List<Usuario> _usuariosRegistrados;

        public LoginForm()
        {
            InitializeComponent();

            // Cargar usuarios de ejemplo (en un sistema real vendrían de BD)
            CargarUsuariosDeEjemplo();

            // Configurar el comportamiento de los placeholders en los TextBox
            SetupPlaceholderText();
        }

        // Método que inicializa la lista de usuarios de ejemplo
        private void CargarUsuariosDeEjemplo()
        {
            _usuariosRegistrados = new List<Usuario>
            {
                new Usuario { Id = 1, NombreUsuario = "admin", Contrasena = "123", Rol = "Administrador" },
                new Usuario { Id = 2, NombreUsuario = "vendedor", Contrasena = "123", Rol = "Vendedor" }
            };
        }

        #region Lógica de Placeholders para TextBoxes

        // Configura eventos para mostrar/ocultar texto placeholder
        private void SetupPlaceholderText()
        {
            // Para el TextBox de usuario
            txtUsuario.GotFocus += (s, e) => RemovePlaceholder(txtUsuario, "Usuario");
            txtUsuario.LostFocus += (s, e) => AddPlaceholder(txtUsuario, "Usuario");

            // Para el TextBox de contraseña (ocultando el texto al ingresar)
            txtContrasena.GotFocus += (s, e) => RemovePlaceholder(txtContrasena, "Contraseña", true);
            txtContrasena.LostFocus += (s, e) => AddPlaceholder(txtContrasena, "Contraseña", true);
        }

        // Quita el texto placeholder si está activo, y cambia el color y máscara si es password
        private void RemovePlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (isPassword)
                {
                    // Mostrar caracteres ocultos (●)
                    textBox.PasswordChar = '●';
                }
            }
        }

        // Añade el texto placeholder si el TextBox está vacío, y ajusta máscara si es password
        private void AddPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                if (isPassword)
                {
                    // Mostrar texto normal sin ocultar caracteres
                    textBox.PasswordChar = '\0';
                }
            }
        }

        #endregion

        // Evento clic para intentar iniciar sesión
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            // Buscar usuario en la lista que coincida con usuario y contraseña (sin importar mayúsculas/minúsculas)
            var usuario = _usuariosRegistrados
                .FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase)
                                  && u.Contrasena == contrasena);

            if (usuario != null)
            {
                // Login exitoso: guardar usuario autenticado y cerrar formulario con OK
                this.UsuarioAutenticado = usuario;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Mostrar mensaje de error y limpiar la contraseña
                lblError.Visible = true;
                txtContrasena.Clear();

                // Volver a poner placeholder en contraseña
                AddPlaceholder(txtContrasena, "Contraseña", true);
            }
        }

        // Evento para mostrar u ocultar caracteres de contraseña según checkbox
        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            // Cambiar solo si no está el texto placeholder en la caja de texto
            if (txtContrasena.Text != "Contraseña")
            {
                txtContrasena.PasswordChar = chkMostrarContrasena.Checked ? '\0' : '●';
            }
        }

        // Evento para cerrar la aplicación al dar clic en el label cerrar
        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
