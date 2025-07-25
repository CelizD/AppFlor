using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class VentasEsperaForm : Form
    {
        public VentaEnEspera VentaSeleccionada { get; private set; }
        private readonly List<VentaEnEspera> _ventas;

        public VentasEsperaForm(List<VentaEnEspera> ventasEnEspera)
        {
            InitializeComponent();
            _ventas = ventasEnEspera;
            CargarLista();
        }

        private void CargarLista()
        {
            var displayList = _ventas.Select((venta, index) =>
                $"Venta #{index + 1} - {venta.Fecha:HH:mm} - Cliente: {venta.ClienteSeleccionado?.Nombre ?? "General"} - Items: {venta.Carrito.Count}"
            ).ToList();
            lstVentasEspera.DataSource = displayList;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SeleccionarVenta();
        }

        private void lstVentasEspera_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarVenta();
        }

        private void SeleccionarVenta()
        {
            if (lstVentasEspera.SelectedIndex >= 0)
            {
                VentaSeleccionada = _ventas[lstVentasEspera.SelectedIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
