using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class CustomConfirmBoxForm : Form
    {
        // Constructor privado para inicializar el formulario con el mensaje y título personalizados
        private CustomConfirmBoxForm(string message, string title)
        {
            InitializeComponent();

            // Establece el texto del mensaje y título en los controles correspondientes
            lblMessage.Text = message;
            lblTitle.Text = title;

            // Cambia el título de la ventana
            this.Text = title;

            // Asigna un icono de pregunta al PictureBox para dar contexto visual
            picIcon.Image = SystemIcons.Question.ToBitmap();
        }

        // Método estático para mostrar el cuadro de confirmación y devolver el resultado (Sí o No)
        public static DialogResult Show(string message, string title)
        {
            // Crea una instancia temporal del formulario, lo muestra y devuelve el resultado del diálogo
            using (var form = new CustomConfirmBoxForm(message, title))
            {
                return form.ShowDialog();
            }
        }

        // Evento para cuando el usuario hace clic en el botón "Sí"
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes; // Indica respuesta afirmativa
            this.Close(); // Cierra el formulario
        }

        // Evento para cuando el usuario hace clic en el botón "No"
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No; // Indica respuesta negativa
            this.Close(); // Cierra el formulario
        }
    }
}
