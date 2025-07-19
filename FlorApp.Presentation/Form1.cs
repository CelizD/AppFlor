using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlorApp.DataAccess;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class Form1 : Form
    {
        // Se declara una variable para el repositorio a nivel de clase
        private readonly FlorRepository _florRepository;

        public Form1()
        {
            InitializeComponent();
            // Se instancia el repositorio al cargar el formulario
            _florRepository = new FlorRepository();

            CargarFlores();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Se valida que el campo de texto no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombreFlor.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la flor.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Se detiene la ejecución si no hay texto
            }

            // Se crea un nuevo objeto Flor con los datos del TextBox
            Flor nuevaFlor = new Flor
            {
                Nombre = txtNombreFlor.Text
            };

            // Se intenta guardar la flor usando el repositorio
            try
            {
                string resultado = _florRepository.GuardarFlor(nuevaFlor);

                // Se muestra el resultado al usuario
                MessageBox.Show(resultado, "Registro de Flor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Se limpia el campo de texto y se actualiza la tabla
                txtNombreFlor.Clear();
                CargarFlores();
            }
            catch (Exception ex)
            {
                // En caso de error, se muestra el mensaje
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CargarFlores()
        {
            // Se obtiene la lista de flores desde el repositorio
            List<Flor> listaDeFlores = _florRepository.ObtenerTodasLasFlores();

            // Se asigna la lista al DataGridView para mostrar los datos
            dgvFlores.DataSource = listaDeFlores;
        }

        private void dgvFlores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Se verifica que la celda clickeada sea válida
            if (e.RowIndex >= 0)
            {
                // Se obtiene la fila correspondiente
                DataGridViewRow row = dgvFlores.Rows[e.RowIndex];

                // Se muestra el nombre de la flor en el TextBox
                txtNombreFlor.Text = row.Cells["Nombre"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Se verifica que haya una fila seleccionada
            if (dgvFlores.SelectedRows.Count > 0)
            {
                // Se obtiene el Id de la flor seleccionada
                int idSeleccionado = Convert.ToInt32(dgvFlores.SelectedRows[0].Cells["Id"].Value);

                // Se crea un objeto Flor con los nuevos datos
                Flor florEditada = new Flor
                {
                    Id = idSeleccionado,
                    Nombre = txtNombreFlor.Text // Se toma el nuevo nombre del TextBox
                };

                // Se actualiza la flor en el repositorio
                _florRepository.ActualizarFlor(florEditada);

                // Se actualiza la tabla y se limpia el TextBox
                CargarFlores();
                txtNombreFlor.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Se verifica que haya una fila seleccionada
            if (dgvFlores.SelectedRows.Count > 0)
            {
                // Se solicita confirmación al usuario
                var confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar esta flor?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Se obtiene el Id de la flor seleccionada
                    int idSeleccionado = Convert.ToInt32(dgvFlores.SelectedRows[0].Cells["Id"].Value);

                    // Se elimina la flor desde el repositorio
                    _florRepository.EliminarFlor(idSeleccionado);

                    // Se actualiza la tabla y se limpia el TextBox
                    CargarFlores();
                    txtNombreFlor.Clear();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
