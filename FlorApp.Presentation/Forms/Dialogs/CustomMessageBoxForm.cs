using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlorApp.Presentation.Forms.Dialogs
{
    public partial class CustomMessageBoxForm : Form
    {
        // Constructor privado para inicializar el mensaje, título e icono personalizados
        private CustomMessageBoxForm(string message, string title, MessageBoxIcon icon)
        {
            InitializeComponent();

            // Asignar el texto del mensaje y título en los controles correspondientes
            lblMessage.Text = message;
            lblTitle.Text = title;

            // Cambiar el título de la ventana
            this.Text = title;

            // Cambiar color de fondo del encabezado e icono según el tipo de mensaje
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    pnlHeader.BackColor = Color.FromArgb(52, 152, 219); // Azul para información
                    picIcon.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Warning:
                    pnlHeader.BackColor = Color.FromArgb(243, 156, 18); // Naranja para advertencia
                    picIcon.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageBoxIcon.Error:
                    pnlHeader.BackColor = Color.FromArgb(231, 76, 60); // Rojo para error
                    picIcon.Image = SystemIcons.Error.ToBitmap();
                    break;
            }

            // Hacer que el botón OK tenga el mismo color de fondo que el encabezado para consistencia visual
            btnOk.BackColor = pnlHeader.BackColor;
        }

        // Método estático para mostrar el mensaje fácilmente sin instanciar el formulario manualmente
        public static void Show(string message, string title, MessageBoxIcon icon)
        {
            // Crear y mostrar el formulario de manera modal
            using (var form = new CustomMessageBoxForm(message, title, icon))
            {
                form.ShowDialog();
            }
        }

        // Evento para cerrar el formulario cuando se presiona el botón OK
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
