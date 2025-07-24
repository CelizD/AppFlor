using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class CustomConfirmBoxForm : Form
    {
        private CustomConfirmBoxForm(string message, string title)
        {
            InitializeComponent();
            lblMessage.Text = message;
            lblTitle.Text = title;
            this.Text = title;
            picIcon.Image = SystemIcons.Question.ToBitmap();
        }

        // Método estático para llamar al formulario y obtener una respuesta (Sí/No)
        public static DialogResult Show(string message, string title)
        {
            using (var form = new CustomConfirmBoxForm(message, title))
            {
                return form.ShowDialog();
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
