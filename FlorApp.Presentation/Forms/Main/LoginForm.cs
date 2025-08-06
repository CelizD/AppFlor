using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FlorApp.DataAccess.Models;


namespace FlorApp.Presentation.Forms.Main
{
    public partial class LoginForm : Form
    {
        // --- PALETA DE COLORES DEL NUEVO DISEÑO ---
        private readonly Color colorFondo = ColorTranslator.FromHtml("#ECF0F1");
        private readonly Color colorPrincipal = ColorTranslator.FromHtml("#2C3E50");
        private readonly Color colorTexto = ColorTranslator.FromHtml("#34495E");
        private readonly Color colorPlaceholder = Color.Gray;
        private readonly Color colorBordeActivo = ColorTranslator.FromHtml("#3498DB");
        private readonly Color colorBordeInactivo = Color.LightGray;

        public Usuario UsuarioAutenticado { get; private set; }
        private List<Usuario> _usuariosRegistrados;

        public LoginForm()
        {
            InitializeComponent();
            CargarUsuariosDeEjemplo();
            AplicarEstilosModernos();
            SetupPlaceholderBehavior();
        }

        private void CargarUsuariosDeEjemplo()
        {
            _usuariosRegistrados = new List<Usuario>
            {
                new Usuario { Id = 1, NombreUsuario = "admin", Contrasena = "123", Rol = "Administrador" },
                new Usuario { Id = 2, NombreUsuario = "vendedor", Contrasena = "123", Rol = "Vendedor" }
            };
        }

        // --- MÉTODO PARA APLICAR EL NUEVO DISEÑO ---
        private void AplicarEstilosModernos()
        {
            this.BackColor = colorFondo;

            // Título
            lblTitulo.ForeColor = colorPrincipal;

            // Botones y Labels
            btnIngresar.BackColor = colorPrincipal;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;

            lblSalir.ForeColor = colorTexto;
            chkMostrarContrasena.ForeColor = colorTexto;

            // Paneles que contienen los TextBoxes
            pnlUsuario.BackColor = Color.White;
            pnlContrasena.BackColor = Color.White;
            pnlUsuario.Paint += (s, e) => e.Graphics.DrawLine(new Pen(colorBordeInactivo, 2), 0, pnlUsuario.Height - 1, pnlUsuario.Width, pnlUsuario.Height - 1);
            pnlContrasena.Paint += (s, e) => e.Graphics.DrawLine(new Pen(colorBordeInactivo, 2), 0, pnlContrasena.Height - 1, pnlContrasena.Width, pnlContrasena.Height - 1);
        }

        // --- LÓGICA PARA PLACEHOLDERS Y EFECTO DE FOCO ---
        private void SetupPlaceholderBehavior()
        {
            txtUsuario.GotFocus += Txt_GotFocus;
            txtUsuario.LostFocus += Txt_LostFocus;
            txtContrasena.GotFocus += Txt_GotFocus;
            txtContrasena.LostFocus += Txt_LostFocus;

            // Establecer el estado inicial de los placeholders
            Txt_LostFocus(txtUsuario, EventArgs.Empty);
            Txt_LostFocus(txtContrasena, EventArgs.Empty);
        }

        private void Txt_GotFocus(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var pnl = txt.Parent as Panel;

            // Asigna el evento para dibujar el borde activo
            pnl.Paint += Panel_Paint_Active;
            pnl.Invalidate(); // Vuelve a dibujar el panel

            if (txt.ForeColor == colorPlaceholder)
            {
                txt.Text = "";
                txt.ForeColor = colorTexto;
                if (txt == txtContrasena)
                {
                    txtContrasena.PasswordChar = '●';
                }
            }
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var pnl = txt.Parent as Panel;

            // Remueve el evento del borde activo para volver al inactivo
            pnl.Paint -= Panel_Paint_Active;
            pnl.Invalidate(); // Vuelve a dibujar el panel

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.ForeColor = colorPlaceholder;
                if (txt == txtUsuario) txt.Text = "Usuario";
                if (txt == txtContrasena)
                {
                    txt.Text = "Contraseña";
                    txtContrasena.PasswordChar = '\0';
                }
            }
        }

        // Evento que dibuja la línea de borde activa
        private void Panel_Paint_Active(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            e.Graphics.DrawLine(new Pen(colorBordeActivo, 2), 0, pnl.Height - 1, pnl.Width, pnl.Height - 1);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.ForeColor == colorPlaceholder ? "" : txtUsuario.Text;
            string contrasena = txtContrasena.ForeColor == colorPlaceholder ? "" : txtContrasena.Text;

            var usuario = _usuariosRegistrados
                .FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase)
                                  && u.Contrasena == contrasena);

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
                Txt_LostFocus(txtContrasena, EventArgs.Empty);
            }
        }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (txtContrasena.ForeColor != colorPlaceholder)
            {
                txtContrasena.PasswordChar = chkMostrarContrasena.Checked ? '\0' : '●';
            }
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
