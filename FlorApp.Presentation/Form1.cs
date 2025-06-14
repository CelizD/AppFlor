using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlorApp.BusinessLogic;

namespace FlorApp.Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var servicio = new FlorService();
            string mensaje = servicio.RegistrarFlor("Rosa Blanca");
            MessageBox.Show(mensaje);
        }
    }
}
