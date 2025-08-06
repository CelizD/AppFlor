using FlorApp.Presentation.Forms.Dialogs;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlorApp.DataAccess.Models;
using FlorApp.DataAccess.Repositories;


namespace FlorApp.Presentation.Forms.Main
{
    public partial class ConfiguracionForm : Form
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly EmpresaRepository _empresaRepository;
        private int? _idUsuarioSeleccionado = null;

        public ConfiguracionForm()
        {
            InitializeComponent();

            // Inicializar repositorios
            _usuarioRepository = new UsuarioRepository();
            _empresaRepository = new EmpresaRepository();

            // Suscribirse a eventos
            this.Load += new EventHandler(ConfiguracionForm_Load);
            dgvUsuarios.CellClick += new DataGridViewCellEventHandler(dgvUsuarios_CellClick);
            btnGuardarUsuario.Click += new EventHandler(btnGuardarUsuario_Click);
            btnEliminarUsuario.Click += new EventHandler(btnEliminarUsuario_Click);
            btnCargarLogo.Click += new EventHandler(btnCargarLogo_Click);
            btnGuardarEmpresa.Click += new EventHandler(btnGuardarEmpresa_Click);
        }

        private async void ConfiguracionForm_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
            await CargarUsuariosAsync();
            await CargarDatosEmpresaAsync();
        }

        #region Pestaña Usuarios

        // Carga usuarios desde la base y los muestra en el DataGridView
        private async Task CargarUsuariosAsync()
        {
            try
            {
                dgvUsuarios.DataSource = await _usuarioRepository.ObtenerTodosAsync();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Configura los items del ComboBox de roles
        private void CargarComboBoxes()
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Vendedor");
        }

        // Al seleccionar un usuario en la tabla, carga sus datos en los controles para editar
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var usuario = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;
                if (usuario != null)
                {
                    _idUsuarioSeleccionado = usuario.Id;
                    txtNombreUsuario.Text = usuario.NombreUsuario;
                    cmbRol.SelectedItem = usuario.Rol;
                    txtContrasena.Clear(); // Por seguridad, no mostrar la contraseña
                }
            }
        }

        // Guarda un usuario nuevo o actualiza uno existente
        private async void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                cmbRol.SelectedItem == null)
            {
                CustomMessageBoxForm.Show("Todos los campos son obligatorios para crear un usuario.", "Datos Incompletos", MessageBoxIcon.Warning);
                return;
            }

            var usuario = new Usuario
            {
                NombreUsuario = txtNombreUsuario.Text,
                Contrasena = txtContrasena.Text, // En producción, encriptar aquí
                Rol = cmbRol.SelectedItem.ToString()
            };

            try
            {
                await _usuarioRepository.GuardarAsync(usuario);
                CustomMessageBoxForm.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxIcon.Information);
                await CargarUsuariosAsync();
                LimpiarCamposUsuario();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Elimina el usuario seleccionado
        private async void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado == null)
            {
                CustomMessageBoxForm.Show("Seleccione un usuario de la lista para eliminar.", "Selección Requerida", MessageBoxIcon.Warning);
                return;
            }

            if (CustomConfirmBoxForm.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmar Eliminación") == DialogResult.Yes)
            {
                try
                {
                    await _usuarioRepository.EliminarAsync(_idUsuarioSeleccionado.Value);
                    CustomMessageBoxForm.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxIcon.Information);
                    await CargarUsuariosAsync();
                    LimpiarCamposUsuario();
                }
                catch (Exception ex)
                {
                    CustomMessageBoxForm.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxIcon.Error);
                }
            }
        }

        // Limpia los campos de usuario para ingresar uno nuevo
        private void LimpiarCamposUsuario()
        {
            _idUsuarioSeleccionado = null;
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            cmbRol.SelectedIndex = -1;
            dgvUsuarios.ClearSelection();
        }

        #endregion

        #region Pestaña Empresa

        // Carga datos de la empresa y los muestra en los controles
        private async Task CargarDatosEmpresaAsync()
        {
            try
            {
                var empresa = await _empresaRepository.ObtenerDatosAsync();
                if (empresa != null)
                {
                    txtNombreEmpresa.Text = empresa.Nombre;
                    txtDireccionEmpresa.Text = empresa.Direccion;
                    txtTelefonoEmpresa.Text = empresa.Telefono;
                    if (empresa.Logo != null)
                    {
                        using (var ms = new MemoryStream(empresa.Logo))
                        {
                            picLogo.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar los datos de la empresa: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Evento para cargar imagen de logo desde archivo
        private void btnCargarLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picLogo.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        // Guarda datos actualizados de la empresa, incluido el logo
        private async void btnGuardarEmpresa_Click(object sender, EventArgs e)
        {
            var empresa = new Empresa
            {
                Nombre = txtNombreEmpresa.Text,
                Direccion = txtDireccionEmpresa.Text,
                Telefono = txtTelefonoEmpresa.Text,
                Logo = ImageToByteArray(picLogo.Image)
            };

            try
            {
                await _empresaRepository.GuardarAsync(empresa);
                CustomMessageBoxForm.Show("Datos de la empresa guardados exitosamente.", "Éxito", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar los datos de la empresa: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Convierte una imagen a arreglo de bytes para almacenarla en base de datos
        private byte[] ImageToByteArray(Image imageIn)
        {
            if (imageIn == null) return null;
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        #endregion
    }
}
