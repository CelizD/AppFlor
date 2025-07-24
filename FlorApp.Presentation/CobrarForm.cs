using System;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class CobrarForm : Form
    {
        private decimal _totalAPagar;
        public string MetodoPagoSeleccionado { get; private set; }

        public CobrarForm(decimal totalAPagar)
        {
            InitializeComponent();
            _totalAPagar = totalAPagar;
            lblTotalPagarValor.Text = _totalAPagar.ToString("C");
            numEfectivoRecibido.Value = _totalAPagar;
            numEfectivoRecibido.Select(0, numEfectivoRecibido.Text.Length);

            numEfectivoRecibido.ValueChanged += (s, e) => CalcularCambio();
            numEfectivoRecibido.KeyUp += (s, e) => CalcularCambio();

            // Lógica para los RadioButtons
            rbEfectivo.CheckedChanged += MetodoPago_CheckedChanged;
            rbTarjeta.CheckedChanged += MetodoPago_CheckedChanged;
            rbTransferencia.CheckedChanged += MetodoPago_CheckedChanged;
        }

        private void MetodoPago_CheckedChanged(object sender, EventArgs e)
        {
            // Si el pago no es en efectivo, no se necesita calcular cambio
            bool esEfectivo = rbEfectivo.Checked;
            numEfectivoRecibido.Enabled = esEfectivo;
            lblEfectivoRecibidoTitulo.Enabled = esEfectivo;
            lblCambioTitulo.Enabled = esEfectivo;
            lblCambioValor.Enabled = esEfectivo;

            if (!esEfectivo)
            {
                numEfectivoRecibido.Value = _totalAPagar;
                CalcularCambio();
            }
        }

        private void CalcularCambio()
        {
            decimal efectivo = numEfectivoRecibido.Value;
            decimal cambio = efectivo - _totalAPagar;
            lblCambioValor.Text = cambio >= 0 ? cambio.ToString("C") : "$0.00";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (rbEfectivo.Checked && numEfectivoRecibido.Value < _totalAPagar)
            {
                CustomMessageBoxForm.Show("El efectivo recibido no puede ser menor al total a pagar.", "Monto Insuficiente", MessageBoxIcon.Warning);
                return;
            }

            // Guardar el método de pago seleccionado
            if (rbEfectivo.Checked) MetodoPagoSeleccionado = "Efectivo";
            else if (rbTarjeta.Checked) MetodoPagoSeleccionado = "Tarjeta";
            else if (rbTransferencia.Checked) MetodoPagoSeleccionado = "Transferencia";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
