using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class KioscoForm : Form
    {
        private readonly Color colorPrimario = ColorTranslator.FromHtml("#2E8B57");
        private readonly Color colorAcento = ColorTranslator.FromHtml("#E74C3C");
        private readonly Color colorFondo = ColorTranslator.FromHtml("#F8F9FA");
        private readonly Color colorTexto = ColorTranslator.FromHtml("#344A40");
        private readonly Color colorBorde = ColorTranslator.FromHtml("#DEE2E6");
        private readonly Color colorBlanco = Color.White;
        private readonly Color colorSeparador = Color.FromArgb(230, 230, 230);
        private readonly Color colorHoverFila = Color.FromArgb(240, 240, 240);

        private readonly ProductoRepository _productoRepository;
        private readonly PedidoRepository _pedidoRepository;
        private BindingList<VentaDetalle> _carrito;
        private List<Producto> _productosCatalogo;
        private List<Producto> _floresIndividuales;
        private List<dynamic> _listaDeExtras;
        private bool _datosYaCargados = false;

        public KioscoForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _productoRepository = new ProductoRepository(connectionString);
            _pedidoRepository = new PedidoRepository(connectionString);

            this.Load += KioscoForm_Load;
            btnAgregarArregloPersonalizado.Click += btnAgregarArregloPersonalizado_Click;
            btnFinalizarPedido.Click += btnFinalizarPedido_Click;
            btnEliminarDelCarrito.Click += btnEliminarDelCarrito_Click;
            dgvCarrito.CellDoubleClick += dgvCarrito_CellDoubleClick;
        }

        private async void KioscoForm_Load(object sender, EventArgs e)
        {
            if (_datosYaCargados) return;

            AplicarEstilosModernos();
            _carrito = new BindingList<VentaDetalle>();
            dgvCarrito.DataSource = _carrito;
            await CargarDatosIniciales();

            _datosYaCargados = true;
        }

        private void AplicarEstilosModernos()
        {
            this.BackColor = colorFondo;
            pnlHeader.BackColor = colorPrimario;
            lblHeader.ForeColor = colorBlanco;
            splitContainer1.Panel1.BackColor = colorFondo;
            splitContainer1.Panel2.BackColor = colorBlanco;
            pnlTotal.BackColor = colorFondo;

            dgvCarrito.BackgroundColor = colorBlanco;
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.GridColor = colorBorde;
            dgvCarrito.ColumnHeadersDefaultCellStyle.BackColor = colorBlanco;
            dgvCarrito.ColumnHeadersDefaultCellStyle.ForeColor = colorTexto;
            dgvCarrito.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvCarrito.DefaultCellStyle.ForeColor = colorTexto;
            dgvCarrito.DefaultCellStyle.SelectionBackColor = colorFondo;
            dgvCarrito.DefaultCellStyle.SelectionForeColor = colorTexto;
            dgvCarrito.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // --- CORRECCIÓN DE COLOR Y ESTILO EN BOTONES ---
            Button[] botonesPrincipales = { btnFinalizarPedido, btnAgregarArregloPersonalizado };
            foreach (var btn in botonesPrincipales)
            {
                btn.BackColor = colorPrimario;
                btn.ForeColor = colorBlanco; // Asegurar texto blanco
                btn.MouseEnter += (s, e) => ((Button)s).BackColor = colorAcento;
                btn.MouseLeave += (s, e) => ((Button)s).BackColor = colorPrimario;
            }

            btnEliminarDelCarrito.BackColor = ColorTranslator.FromHtml("#7F8C8D");
            btnEliminarDelCarrito.ForeColor = colorBlanco; // Asegurar texto blanco

            lblTotalTitulo.ForeColor = colorTexto;
            lblTotalValor.ForeColor = colorPrimario;
        }

        private async Task CargarDatosIniciales()
        {
            try
            {
                var todosLosProductos = await _productoRepository.ObtenerTodosAsync();
                _productosCatalogo = todosLosProductos.Where(p => p.Categoria == "Arreglo Floral").ToList();
                _floresIndividuales = todosLosProductos.Where(p => p.Categoria == "Flor").ToList();

                PoblarCatalogo();
                PoblarSeccionCreaTuArreglo();
                PoblarExtras();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar los productos: {ex.Message}", "Error de Conexión", MessageBoxIcon.Error);
            }
        }

        #region Poblar Controles
        private void PoblarCatalogo()
        {
            flpCatalogo.Controls.Clear();
            foreach (var producto in _productosCatalogo)
            {
                Panel card = new Panel { Width = 220, Height = 320, Margin = new Padding(10), BackColor = colorBlanco };
                card.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, colorBorde, ButtonBorderStyle.Solid);

                PictureBox pic = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, Dock = DockStyle.Top, Height = 160, Padding = new Padding(5) };
                if (producto.Foto != null && producto.Foto.Length > 0)
                {
                    using (var ms = new MemoryStream(producto.Foto)) { pic.Image = Image.FromStream(ms); }
                }

                Label name = new Label { Text = producto.Nombre, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = colorTexto, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Height = 50, Padding = new Padding(5) };
                Label price = new Label { Text = producto.PrecioVenta.ToString("C"), Font = new Font("Segoe UI", 12F), ForeColor = colorPrimario, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Height = 30 };

                Button btn = new Button { Text = "Agregar", Dock = DockStyle.Bottom, BackColor = colorPrimario, ForeColor = colorBlanco, FlatStyle = FlatStyle.Flat, Height = 40, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Tag = producto };
                btn.FlatAppearance.BorderSize = 0;
                btn.MouseEnter += (s, e) => ((Button)s).BackColor = colorAcento;
                btn.MouseLeave += (s, e) => ((Button)s).BackColor = colorPrimario;
                btn.Click += (s, e) => AgregarAlCarrito((Producto)((Button)s).Tag, 1);

                card.Controls.AddRange(new Control[] { name, pic, price, btn });
                flpCatalogo.Controls.Add(card);
            }
        }

        private void PoblarSeccionCreaTuArreglo()
        {
            flpFlores.Controls.Clear();
            foreach (var flor in _floresIndividuales)
            {
                Panel itemPanel = new Panel { Width = flpFlores.Width - 30, Height = 70, Margin = new Padding(5), BackColor = Color.White };
                Label lblNombre = new Label { Text = $"{flor.Nombre} ({flor.PrecioVenta:C})", Dock = DockStyle.Top, Font = new Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold), ForeColor = colorTexto, Height = 30, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(10, 5, 0, 0) };
                Panel pnlBottom = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10, 0, 10, 5) };
                NumericUpDown numCantidad = new NumericUpDown { Minimum = 0, Maximum = 100, Width = 60, Dock = DockStyle.Right, Tag = flor, Font = new Font("Segoe UI", 11F) };
                ComboBox cmbColor = new ComboBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10F), DropDownStyle = ComboBoxStyle.DropDownList };
                if (!string.IsNullOrWhiteSpace(flor.ColoresDisponibles))
                {
                    string[] colores = flor.ColoresDisponibles.Split(',').Select(c => c.Trim()).ToArray();
                    cmbColor.Items.AddRange(colores);
                    if (cmbColor.Items.Count > 0) cmbColor.SelectedIndex = 0;
                }
                else
                {
                    cmbColor.Items.Add("Único");
                    cmbColor.SelectedIndex = 0;
                    cmbColor.Enabled = false;
                }
                Panel separator = new Panel { Dock = DockStyle.Bottom, Height = 1, BackColor = colorSeparador };
                pnlBottom.Controls.Add(cmbColor);
                pnlBottom.Controls.Add(numCantidad);
                itemPanel.Controls.Add(pnlBottom);
                itemPanel.Controls.Add(lblNombre);
                itemPanel.Controls.Add(separator);
                Action<Control> addHoverEffect = null;
                addHoverEffect = (control) => {
                    control.MouseEnter += (s, e) => itemPanel.BackColor = colorHoverFila;
                    control.MouseLeave += (s, e) => itemPanel.BackColor = Color.White;
                    foreach (Control child in control.Controls) { addHoverEffect(child); }
                };
                addHoverEffect(itemPanel);
                flpFlores.Controls.Add(itemPanel);
            }
            cmbEnvoltura.Items.Clear();
            cmbEnvoltura.DisplayMember = "Text";
            var envolturas = new List<dynamic>
            {
               new { Text = "Seleccione una envoltura...", Price = 0m },
                new { Text = "Papel kraft", Price = 20m },
                new { Text = "Papel coreano (tela semi-transparente)", Price = 45m },
                new { Text = "Papel celofán (transparente o con diseño)", Price = 15m },
                new { Text = "Papel china", Price = 10m },
                new { Text = "Papel cartucho", Price = 25m }
            };
            cmbEnvoltura.Items.AddRange(envolturas.ToArray());
            cmbEnvoltura.SelectedIndex = 0;
        }

        private void PoblarExtras()
        {
            _listaDeExtras = new List<dynamic>
            {
                new { Text = "Caja de chocolates Ferrero", Price = 180m },
                new { Text = "Globo metálico con mensaje", Price = 120m },
                new { Text = "Peluche pequeño", Price = 150m },
                new { Text = "Tarjeta personalizada", Price = 30m }
            };

            flpExtras.Controls.Clear();
            foreach (var extra in _listaDeExtras)
            {
                CheckBox chk = new CheckBox
                {
                    Text = $"{extra.Text} ({extra.Price:C})",
                    Tag = extra,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = colorTexto,
                    Margin = new Padding(10, 5, 10, 5)
                };
                flpExtras.Controls.Add(chk);
            }
        }
        #endregion

        #region Lógica de Carrito y Pedido

        private void btnEliminarDelCarrito_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow?.DataBoundItem is VentaDetalle productoAEliminar)
            {
                _carrito.Remove(productoAEliminar);
                ActualizarCarrito();
            }
            else
            {
                CustomMessageBoxForm.Show("Por favor, selecciona un producto del carrito para eliminar.", "Ningún producto seleccionado", MessageBoxIcon.Warning);
            }
        }

        private void dgvCarrito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminarDelCarrito_Click(sender, e);
        }

        private void btnAgregarArregloPersonalizado_Click(object sender, EventArgs e)
        {
            decimal costoTotalArreglo = 0;
            var detallesArreglo = new List<string>();

            foreach (Control itemControl in flpFlores.Controls)
            {
                if (itemControl is Panel itemPanel)
                {
                    var numControl = itemPanel.Controls.OfType<Panel>().First().Controls.OfType<NumericUpDown>().FirstOrDefault();
                    if (numControl != null && numControl.Value > 0)
                    {
                        var flor = (Producto)numControl.Tag;
                        var cmbColor = itemPanel.Controls.OfType<Panel>().First().Controls.OfType<ComboBox>().FirstOrDefault();
                        string colorSeleccionado = (cmbColor != null && cmbColor.Enabled) ? cmbColor.SelectedItem.ToString() : "";

                        costoTotalArreglo += flor.PrecioVenta * numControl.Value;
                        detallesArreglo.Add($"{numControl.Value}x {flor.Nombre} {(string.IsNullOrEmpty(colorSeleccionado) || colorSeleccionado == "Único" ? "" : $"({colorSeleccionado})")}");
                    }
                }
            }

            if (cmbEnvoltura.SelectedIndex > 0)
            {
                var envoltura = (dynamic)cmbEnvoltura.SelectedItem;
                costoTotalArreglo += envoltura.Price;
                detallesArreglo.Add($"Envoltura: {envoltura.Text}");
            }

            foreach (CheckBox chk in flpExtras.Controls)
            {
                if (chk.Checked)
                {
                    var extra = (dynamic)chk.Tag;
                    costoTotalArreglo += extra.Price;
                    detallesArreglo.Add($"Extra: {extra.Text}");
                }
            }

            if (detallesArreglo.Count == 0)
            {
                CustomMessageBoxForm.Show("Debes seleccionar al menos una flor para crear tu arreglo.", "Arreglo Vacío", MessageBoxIcon.Warning);
                return;
            }

            var productoPersonalizado = new Producto { Id = -1, Nombre = "Arreglo Personalizado", PrecioVenta = costoTotalArreglo, Descripcion = string.Join(", ", detallesArreglo) };
            AgregarAlCarrito(productoPersonalizado, 1);
            LimpiarCreadorDeArreglos();
        }

        private void AgregarAlCarrito(Producto producto, int cantidad)
        {
            var itemExistente = _carrito.FirstOrDefault(i => i.ProductoId == producto.Id && producto.Id > 0);
            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                _carrito.Add(new VentaDetalle { ProductoId = producto.Id, NombreProducto = producto.Id > 0 ? producto.Nombre : producto.Descripcion, Cantidad = cantidad, PrecioUnitario = producto.PrecioVenta });
            }
            ActualizarCarrito();
        }

        private void LimpiarCreadorDeArreglos()
        {
            foreach (Control itemControl in flpFlores.Controls)
            {
                if (itemControl is Panel itemPanel)
                {
                    var numControl = itemPanel.Controls.OfType<Panel>().First().Controls.OfType<NumericUpDown>().FirstOrDefault();
                    if (numControl != null)
                    {
                        numControl.Value = 0;
                    }
                    var cmb = itemPanel.Controls.OfType<Panel>().First().Controls.OfType<ComboBox>().FirstOrDefault();
                    if (cmb != null && cmb.Items.Count > 0)
                    {
                        cmb.SelectedIndex = 0;
                    }
                }
            }
            cmbEnvoltura.SelectedIndex = 0;
            foreach (CheckBox chk in flpExtras.Controls) { chk.Checked = false; }
        }

        private void ActualizarCarrito()
        {
            foreach (var item in _carrito) { item.TotalLinea = item.Cantidad * item.PrecioUnitario; }
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = _carrito;

            if (dgvCarrito.Columns.Count > 0)
            {
                dgvCarrito.Columns["NombreProducto"].HeaderText = "Producto";
                dgvCarrito.Columns["Cantidad"].HeaderText = "Cant.";
                dgvCarrito.Columns["PrecioUnitario"].HeaderText = "Precio";
                dgvCarrito.Columns["TotalLinea"].HeaderText = "Total";
                dgvCarrito.Columns["Id"].Visible = false;
                dgvCarrito.Columns["VentaId"].Visible = false;
                dgvCarrito.Columns["ProductoId"].Visible = false;
                dgvCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Format = "c";
                dgvCarrito.Columns["TotalLinea"].DefaultCellStyle.Format = "c";
            }
            lblTotalValor.Text = _carrito.Sum(i => i.TotalLinea).ToString("C");
        }

        private async void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (_carrito.Count == 0)
            {
                CustomMessageBoxForm.Show("El carrito está vacío.", "Carrito Vacío", MessageBoxIcon.Warning);
                return;
            }

            using (var formDatos = new DatosClienteKioscoForm())
            {
                if (formDatos.ShowDialog() == DialogResult.OK)
                {
                    string productosStr = string.Join(", ", _carrito.Select(d => $"{d.Cantidad}x {d.NombreProducto}"));
                    decimal totalPedido = _carrito.Sum(i => i.TotalLinea);

                    var nuevoPedido = new Pedido
                    {
                        NombreCliente = formDatos.NombreCliente,
                        Productos = productosStr,
                        MensajeTarjeta = formDatos.MensajeTarjeta,
                        FechaEntrega = DateTime.Now,
                        DireccionEntrega = formDatos.Direccion,
                        Estado = "Recibido (Pendiente de Pago)",
                        RepartidorAsignado = "N/A",
                        Telefono = formDatos.Telefono,
                        Email = formDatos.Email,
                        Origen = "Kiosco"
                    };

                    try
                    {
                        await _pedidoRepository.GuardarAsync(nuevoPedido);
                        CustomMessageBoxForm.Show($"¡Gracias, {formDatos.NombreCliente}!\nTu pedido ha sido registrado con éxito.\nTotal: {totalPedido:C}", "Pedido Finalizado", MessageBoxIcon.Information);
                        _carrito.Clear();
                        ActualizarCarrito();
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBoxForm.Show($"No se pudo guardar el pedido: {ex.Message}", "Error al Guardar", MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
    }
}
