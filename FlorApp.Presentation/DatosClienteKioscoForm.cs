using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class DatosClienteKioscoForm : Form
    {
        // Propiedades públicas para obtener los datos después de que el formulario se cierre.
        public string NombreCliente { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }
        public string Direccion { get; private set; }
        public bool RecogeEnTienda { get; private set; }
        // --- NUEVA PROPIEDAD ---
        public string MensajeTarjeta { get; private set; }

        public DatosClienteKioscoForm()
        {
            InitializeComponent();
            this.Load += DatosClienteKioscoForm_Load;
        }

        private void DatosClienteKioscoForm_Load(object sender, EventArgs e)
        {
            AplicarEstilos();
            chkRecogerEnTienda.CheckedChanged += chkRecogerEnTienda_CheckedChanged;
            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += (s, ev) => this.DialogResult = DialogResult.Cancel;
        }

        private void AplicarEstilos()
        {
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            pnlHeader.BackColor = Color.FromArgb(46, 139, 87);
            lblTitulo.ForeColor = Color.White;

            btnAceptar.BackColor = Color.FromArgb(46, 139, 87);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.FlatAppearance.BorderSize = 0;

            btnCancelar.BackColor = Color.FromArgb(127, 140, 141);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
        }

        private void chkRecogerEnTienda_CheckedChanged(object sender, EventArgs e)
        {
            txtDireccion.Enabled = !chkRecogerEnTienda.Checked;
            if (chkRecogerEnTienda.Checked)
            {
                txtDireccion.BackColor = SystemColors.Control;
                txtDireccion.Text = "El pedido se recogerá en la tienda.";
            }
            else
            {
                txtDireccion.BackColor = Color.White;
                txtDireccion.Text = "";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                CustomMessageBoxForm.Show("Por favor, ingrese su nombre.", "Campo Requerido", MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                CustomMessageBoxForm.Show("Por favor, ingrese su número de teléfono.", "Campo Requerido", MessageBoxIcon.Warning);
                return;
            }

            if (!chkRecogerEnTienda.Checked && string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                CustomMessageBoxForm.Show("Por favor, ingrese su dirección de entrega o seleccione 'Recoger en tienda'.", "Campo Requerido", MessageBoxIcon.Warning);
                return;
            }

            // Guardar los datos en las propiedades públicas.
            NombreCliente = txtNombre.Text;
            Telefono = txtTelefono.Text;
            Email = txtEmail.Text;
            RecogeEnTienda = chkRecogerEnTienda.Checked;
            Direccion = RecogeEnTienda ? "Recoge en Tienda" : txtDireccion.Text;
            MensajeTarjeta = txtMensajeTarjeta.Text; // --- Guardar el mensaje de la tarjeta ---

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
