using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FlorApp.Presentation.Forms.Dialogs
{
    public partial class CobrarForm : Form
    {
        private decimal _totalAPagar;
        public string MetodoPagoSeleccionado { get; private set; }

        public CobrarForm(decimal totalAPagar)
        {
            InitializeComponent();

            // Si el total a pagar es negativo (debido a un gran descuento), lo tratamos como cero.
            _totalAPagar = totalAPagar < 0 ? 0 : totalAPagar;

            lblTotalPagarValor.Text = _totalAPagar.ToString("C");
            numEfectivoRecibido.Value = _totalAPagar; // Sugerir el monto exacto
            numEfectivoRecibido.Select(0, numEfectivoRecibido.Text.Length); // Seleccionar todo el texto

            // Conectar eventos para calcular cambio en tiempo real
            numEfectivoRecibido.ValueChanged += (s, e) => CalcularCambio();
            numEfectivoRecibido.KeyUp += (s, e) => CalcularCambio();

            // Lógica para los RadioButtons de método de pago
            rbEfectivo.CheckedChanged += MetodoPago_CheckedChanged;
            rbTarjeta.CheckedChanged += MetodoPago_CheckedChanged;
            rbTransferencia.CheckedChanged += MetodoPago_CheckedChanged;

            // Conectar eventos para los botones de pago rápido
            btnExacto.Click += (s, e) => numEfectivoRecibido.Value = _totalAPagar;
            btn100.Click += (s, e) => numEfectivoRecibido.Value = 100;
            btn200.Click += (s, e) => numEfectivoRecibido.Value = 200;
            btn500.Click += (s, e) => numEfectivoRecibido.Value = 500;
        }

        private void MetodoPago_CheckedChanged(object sender, EventArgs e)
        {
            // Si el pago no es en efectivo, deshabilitamos los controles de efectivo
            bool esEfectivo = rbEfectivo.Checked;

            numEfectivoRecibido.Enabled = esEfectivo;
            label3.Enabled = esEfectivo; // 'label3' es el nuevo nombre de 'lblEfectivoRecibidoTitulo'
            lblCambioTitulo.Enabled = esEfectivo;
            lblCambioValor.Enabled = esEfectivo;
            groupBox2.Enabled = esEfectivo; // Habilitar/deshabilitar los botones de pago rápido

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
