using System;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class AbrirCajaForm : Form
    {
        public decimal MontoInicial { get; private set; }

        public AbrirCajaForm()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.MontoInicial = numMontoInicial.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
