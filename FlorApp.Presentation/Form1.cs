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
        // Repositorio para gestionar datos de flores
        private readonly FlorRepository _florRepository;

        public Form1()
        {
            InitializeComponent();

            // Instanciar repositorio al iniciar el formulario
            _florRepository = new FlorRepository();

            // Cargar flores en el DataGridView al abrir la ventana
            CargarFlores();
        }

        // Evento para registrar una nueva flor
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(txtNombreFlor.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la flor.", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir si no hay texto
            }

            // Crear objeto Flor con el nombre capturado
            Flor nuevaFlor = new Flor
            {
                Nombre = txtNombreFlor.Text
            };

            try
            {
                // Guardar la flor usando el repositorio
                string resultado = _florRepository.GuardarFlor(nuevaFlor);

                // Mostrar resultado al usuario
                MessageBox.Show(resultado, "Registro de Flor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el campo de texto y refrescar el DataGridView
                txtNombreFlor.Clear();
                CargarFlores();
            }
            catch (Exception ex)
            {
                // Mostrar error si ocurre una excepción
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar la lista de flores y mostrarlas en el DataGridView
        private void CargarFlores()
        {
            // Obtener lista de flores desde el repositorio
            List<Flor> listaDeFlores = _florRepository.ObtenerTodasLasFlores();

            // Asignar la lista como fuente de datos del DataGridView
            dgvFlores.DataSource = listaDeFlores;
        }

        // Evento al hacer clic en una celda del DataGridView
        private void dgvFlores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la fila clickeada sea válida
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dgvFlores.Rows[e.RowIndex];

                // Mostrar el nombre de la flor en el TextBox para edición
                txtNombreFlor.Text = row.Cells["Nombre"].Value.ToString();
            }
        }

        // Evento para editar la flor seleccionada
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una fila
            if (dgvFlores.SelectedRows.Count > 0)
            {
                // Obtener el Id de la flor seleccionada
                int idSeleccionado = Convert.ToInt32(dgvFlores.SelectedRows[0].Cells["Id"].Value);

                // Crear objeto Flor con el Id y nuevo nombre
                Flor florEditada = new Flor
                {
                    Id = idSeleccionado,
                    Nombre = txtNombreFlor.Text
                };

                // Actualizar la flor en el repositorio
                _florRepository.ActualizarFlor(florEditada);

                // Refrescar tabla y limpiar campo
                CargarFlores();
                txtNombreFlor.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento para eliminar la flor seleccionada
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una fila
            if (dgvFlores.SelectedRows.Count > 0)
            {
                // Preguntar confirmación antes de eliminar
                var confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar esta flor?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    // Obtener Id de la flor seleccionada
                    int idSeleccionado = Convert.ToInt32(dgvFlores.SelectedRows[0].Cells["Id"].Value);

                    // Eliminar la flor del repositorio
                    _florRepository.EliminarFlor(idSeleccionado);

                    // Actualizar tabla y limpiar TextBox
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
