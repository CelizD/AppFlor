using System;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class CobrarForm : Form
    {
        private decimal _totalAPagar; // Monto total a cobrar
        public string MetodoPagoSeleccionado { get; private set; } // Método de pago elegido

        public CobrarForm(decimal totalAPagar)
        {
            InitializeComponent();

            _totalAPagar = totalAPagar;

            // Mostrar el total a pagar en formato moneda
            lblTotalPagarValor.Text = _totalAPagar.ToString("C");

            // Inicializar el valor del efectivo recibido con el total a pagar
            numEfectivoRecibido.Value = _totalAPagar;

            // Seleccionar todo el texto para facilitar edición
            numEfectivoRecibido.Select(0, numEfectivoRecibido.Text.Length);

            // Eventos para recalcular el cambio cuando cambia el efectivo recibido
            numEfectivoRecibido.ValueChanged += (s, e) => CalcularCambio();
            numEfectivoRecibido.KeyUp += (s, e) => CalcularCambio();

            // Eventos para manejar el cambio del método de pago seleccionado
            rbEfectivo.CheckedChanged += MetodoPago_CheckedChanged;
            rbTarjeta.CheckedChanged += MetodoPago_CheckedChanged;
            rbTransferencia.CheckedChanged += MetodoPago_CheckedChanged;
        }

        // Método que se ejecuta al cambiar la selección del método de pago
        private void MetodoPago_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el método seleccionado es efectivo
            bool esEfectivo = rbEfectivo.Checked;

            // Solo habilitar controles relacionados con efectivo si se paga en efectivo
            numEfectivoRecibido.Enabled = esEfectivo;
            lblEfectivoRecibidoTitulo.Enabled = esEfectivo;
            lblCambioTitulo.Enabled = esEfectivo;
            lblCambioValor.Enabled = esEfectivo;

            if (!esEfectivo)
            {
                // Si no es efectivo, asignar el efectivo recibido igual al total a pagar
                numEfectivoRecibido.Value = _totalAPagar;
                CalcularCambio(); // Actualiza el cambio (debería ser cero)
            }
        }

        // Calcula el cambio que se debe entregar al cliente
        private void CalcularCambio()
        {
            decimal efectivo = numEfectivoRecibido.Value;
            decimal cambio = efectivo - _totalAPagar;

            // Mostrar el cambio solo si es positivo, sino cero
            lblCambioValor.Text = cambio >= 0 ? cambio.ToString("C") : "$0.00";
        }

        // Evento al hacer clic en el botón Aceptar para finalizar cobro
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validación: si es efectivo, no puede ser menor al total a pagar
            if (rbEfectivo.Checked && numEfectivoRecibido.Value < _totalAPagar)
            {
                CustomMessageBoxForm.Show("El efectivo recibido no puede ser menor al total a pagar.", "Monto Insuficiente", MessageBoxIcon.Warning);
                return;
            }

            // Guardar el método de pago según el radio button seleccionado
            if (rbEfectivo.Checked) MetodoPagoSeleccionado = "Efectivo";
            else if (rbTarjeta.Checked) MetodoPagoSeleccionado = "Tarjeta";
            else if (rbTransferencia.Checked) MetodoPagoSeleccionado = "Transferencia";

            // Cerrar el formulario con resultado OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
