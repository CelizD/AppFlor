using System;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class AbrirCajaForm : Form
    {
        // Propiedad para almacenar el monto inicial ingresado por el usuario
        public decimal MontoInicial { get; private set; }

        // Constructor del formulario
        public AbrirCajaForm()
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario
        }

        // Evento que se ejecuta al hacer clic en el botón Aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Captura el valor ingresado en el control numérico numMontoInicial
            this.MontoInicial = numMontoInicial.Value;

            // Establece el resultado del diálogo como OK para indicar éxito
            this.DialogResult = DialogResult.OK;

            // Cierra el formulario para volver al formulario llamante
            this.Close();
        }

        // Evento que se ejecuta al hacer clic en el botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Establece el resultado del diálogo como Cancel para indicar que se canceló la acción
            this.DialogResult = DialogResult.Cancel;

            // Cierra el formulario sin guardar ningún cambio
            this.Close();
        }
    }
}
