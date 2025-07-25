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
        public Usuario UsuarioAutenticado { get; private set; }
        private List<Usuario> _usuariosRegistrados;

        public LoginForm()
        {
            InitializeComponent();
            CargarUsuariosDeEjemplo();
            SetupPlaceholderText();
        }

        private void CargarUsuariosDeEjemplo()
        {
            _usuariosRegistrados = new List<Usuario>
            {
                new Usuario { Id = 1, NombreUsuario = "admin", Contrasena = "123", Rol = "Administrador" },
                new Usuario { Id = 2, NombreUsuario = "vendedor", Contrasena = "123", Rol = "Vendedor" }
            };
        }

        #region Lógica de Placeholders para TextBoxes

        private void SetupPlaceholderText()
        {
            // Configurar placeholders para txtUsuario
            txtUsuario.GotFocus += (s, e) => RemovePlaceholder(txtUsuario, "Usuario");
            txtUsuario.LostFocus += (s, e) => AddPlaceholder(txtUsuario, "Usuario");

            // Configurar placeholders para txtContrasena
            txtContrasena.GotFocus += (s, e) => RemovePlaceholder(txtContrasena, "Contraseña", true);
            txtContrasena.LostFocus += (s, e) => AddPlaceholder(txtContrasena, "Contraseña", true);
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (isPassword)
                {
                    textBox.PasswordChar = '●';
                }
            }
        }

        private void AddPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                if (isPassword)
                {
                    textBox.PasswordChar = '\0'; // Quitar el caracter de contraseña
                }
            }
        }

        #endregion

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            var usuario = _usuariosRegistrados.FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && u.Contrasena == contrasena);

            if (usuario != null)
            {
                this.UsuarioAutenticado = usuario;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Visible = true;
                txtContrasena.Clear();
                AddPlaceholder(txtContrasena, "Contraseña", true);
            }
        }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            // Solo cambiar el caracter si no es el texto de placeholder
            if (txtContrasena.Text != "Contraseña")
            {
                txtContrasena.PasswordChar = chkMostrarContrasena.Checked ? '\0' : '●';
            }
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
