using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class CustomMessageBoxForm : Form
    {
        private CustomMessageBoxForm(string message, string title, MessageBoxIcon icon)
        {
            InitializeComponent();
            lblMessage.Text = message;
            lblTitle.Text = title;
            this.Text = title;

            // Asignar color e icono según el tipo de mensaje
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    pnlHeader.BackColor = Color.FromArgb(52, 152, 219); // Azul
                    picIcon.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Warning:
                    pnlHeader.BackColor = Color.FromArgb(243, 156, 18); // Naranja
                    picIcon.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageBoxIcon.Error:
                    pnlHeader.BackColor = Color.FromArgb(231, 76, 60); // Rojo
                    picIcon.Image = SystemIcons.Error.ToBitmap();
                    break;
            }
            btnOk.BackColor = pnlHeader.BackColor;
        }

        // Método estático para llamar al formulario fácilmente
        public static void Show(string message, string title, MessageBoxIcon icon)
        {
            using (var form = new CustomMessageBoxForm(message, title, icon))
            {
                form.ShowDialog();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
