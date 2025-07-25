using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class VentasEsperaForm : Form
    {
        // Propiedad para acceder a la venta seleccionada después de cerrar el formulario
        public VentaEnEspera VentaSeleccionada { get; private set; }

        // Lista interna que almacena las ventas en espera que se mostrarán
        private readonly List<VentaEnEspera> _ventas;

        // Constructor que recibe la lista de ventas en espera
        public VentasEsperaForm(List<VentaEnEspera> ventasEnEspera)
        {
            InitializeComponent();

            // Guardar la lista de ventas en espera recibida
            _ventas = ventasEnEspera;

            // Cargar los datos en el ListBox al iniciar el formulario
            CargarLista();
        }

        // Método para preparar y mostrar la lista de ventas en espera en el ListBox
        private void CargarLista()
        {
            // Se crea una lista de strings que describen cada venta
            var displayList = _ventas.Select((venta, index) =>
                $"Venta #{index + 1} - {venta.Fecha:HH:mm} - Cliente: {venta.ClienteSeleccionado?.Nombre ?? "General"} - Items: {venta.Carrito.Count}"
            ).ToList();

            // Asignar la lista de descripciones como fuente de datos del ListBox
            lstVentasEspera.DataSource = displayList;
        }

        // Evento al hacer clic en el botón "Aceptar"
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SeleccionarVenta();
        }

        // Evento al hacer doble clic en un elemento de la lista
        private void lstVentasEspera_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarVenta();
        }

        // Método para asignar la venta seleccionada y cerrar el formulario
        private void SeleccionarVenta()
        {
            // Verificar que se haya seleccionado algún elemento
            if (lstVentasEspera.SelectedIndex >= 0)
            {
                // Guardar la venta correspondiente al índice seleccionado
                VentaSeleccionada = _ventas[lstVentasEspera.SelectedIndex];

                // Establecer el resultado del diálogo como OK para indicar selección exitosa
                this.DialogResult = DialogResult.OK;

                // Cerrar el formulario
                this.Close();
            }
        }
    }
}
