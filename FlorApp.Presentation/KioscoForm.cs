using FlorApp.DataAccess;
using FlorApp.Presentation;
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
        // --- Paleta de Colores ---
        private readonly Color colorPrincipal = Color.FromArgb(46, 139, 87);
        private readonly Color colorAcento = Color.FromArgb(255, 99, 132);
        private readonly Color colorAcentoHover = Color.FromArgb(255, 70, 102);
        private readonly Color colorFondo = Color.FromArgb(249, 249, 249);
        private readonly Color colorTextoPrincipal = Color.FromArgb(64, 64, 64);
        private readonly Color colorEliminar = Color.FromArgb(127, 140, 141);
        private readonly Color colorEliminarHover = Color.FromArgb(108, 122, 137);
        private readonly Color colorSeparador = Color.FromArgb(230, 230, 230);
        private readonly Color colorHoverFila = Color.FromArgb(240, 240, 240);

        private readonly ProductoRepository _productoRepository;
        private readonly VentaRepository _ventaRepository;
        private BindingList<VentaDetalle> _carrito;
        private List<Producto> _productosCatalogo;
        private List<Producto> _floresIndividuales;
        private List<dynamic> _listaDeExtras;

        public KioscoForm()
        {
            InitializeComponent();
            AplicarEstilosBase();
            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _productoRepository = new ProductoRepository(connectionString);
            _ventaRepository = new VentaRepository(connectionString);
            this.Load += new EventHandler(KioscoForm_Load);
        }

        private void AplicarEstilosBase()
        {
            this.BackColor = colorFondo;
            groupBox1.Text = "🌿 Catálogo de Arreglos";
            groupBox2.Text = "🎁 Arma tu propio Arreglo";
            groupBox3.Text = "✨ Añade un Extra";
            btnAgregarArregloPersonalizado.BackColor = colorAcento;
            btnFinalizarPedido.BackColor = colorAcento;
            btnEliminarDelCarrito.BackColor = colorEliminar;

            btnAgregarArregloPersonalizado.MouseEnter += (s, e) => ((Button)s).BackColor = colorAcentoHover;
            btnAgregarArregloPersonalizado.MouseLeave += (s, e) => ((Button)s).BackColor = colorAcento;
            btnFinalizarPedido.MouseEnter += (s, e) => ((Button)s).BackColor = colorAcentoHover;
            btnFinalizarPedido.MouseLeave += (s, e) => ((Button)s).BackColor = colorAcento;
            btnEliminarDelCarrito.MouseEnter += (s, e) => ((Button)s).BackColor = colorEliminarHover;
            btnEliminarDelCarrito.MouseLeave += (s, e) => ((Button)s).BackColor = colorEliminar;
        }

        private async void KioscoForm_Load(object sender, EventArgs e)
        {
            _carrito = new BindingList<VentaDetalle>();
            dgvCarrito.DataSource = _carrito;
            await CargarDatosIniciales();

            btnAgregarArregloPersonalizado.Click += new EventHandler(btnAgregarArregloPersonalizado_Click);
            btnFinalizarPedido.Click += new EventHandler(btnFinalizarPedido_Click);
            btnEliminarDelCarrito.Click += new EventHandler(btnEliminarDelCarrito_Click);
            dgvCarrito.CellDoubleClick += new DataGridViewCellEventHandler(dgvCarrito_CellDoubleClick);
        }

        private async Task CargarDatosIniciales()
        {
            try
            {
                var todosLosProductos = await _productoRepository.ObtenerTodosAsync();

                // --- CORRECCIÓN IMPORTANTE APLICADA AQUÍ ---
                // Volvemos a poner los filtros para separar los productos correctamente.
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

        #region Poblar Controles (Sin cambios en esta región)
        private void PoblarCatalogo()
        {
            flpCatalogo.Controls.Clear();
            foreach (var producto in _productosCatalogo)
            {
                Panel cardShadow = new Panel { Width = 230, Height = 330, Margin = new Padding(10), BackColor = Color.FromArgb(220, 220, 220) };
                Panel card = new Panel { Width = 226, Height = 326, Location = new Point(2, 2), BackColor = Color.White };

                PictureBox pic = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, Dock = DockStyle.Top, Height = 170, Padding = new Padding(5) };

                if (producto.Foto != null && producto.Foto.Length > 0)
                {
                    using (var ms = new MemoryStream(producto.Foto))
                    {
                        pic.Image = Image.FromStream(ms);
                    }
                }

                Label name = new Label { Text = producto.Nombre, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = colorTextoPrincipal, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, AutoSize = false, Height = 50, Padding = new Padding(5) };
                Label price = new Label { Text = producto.PrecioVenta.ToString("C"), Font = new Font("Segoe UI", 12F, FontStyle.Regular), ForeColor = colorPrincipal, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Height = 30 };

                Button btn = new Button { Text = "Agregar", Dock = DockStyle.Bottom, BackColor = colorPrincipal, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Height = 40, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Tag = producto };
                btn.FlatAppearance.BorderSize = 0;
                btn.MouseEnter += (s, e) => ((Button)s).BackColor = colorAcento;
                btn.MouseLeave += (s, e) => ((Button)s).BackColor = colorPrincipal;
                btn.Click += (s, e) => AgregarAlCarrito((Producto)((Button)s).Tag, 1);

                card.Controls.AddRange(new Control[] { name, pic, price, btn });
                cardShadow.Controls.Add(card);
                flpCatalogo.Controls.Add(cardShadow);
            }
        }

        private void PoblarSeccionCreaTuArreglo()
        {
            flpFlores.Controls.Clear();
            foreach (var flor in _floresIndividuales)
            {
                Panel itemPanel = new Panel { Width = flpFlores.Width - 30, Height = 70, Margin = new Padding(5), BackColor = Color.White };

                Label lblNombre = new Label { Text = $"{flor.Nombre} ({flor.PrecioVenta:C})", Dock = DockStyle.Top, Font = new Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold), ForeColor = colorTextoPrincipal, Height = 30, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(10, 5, 0, 0) };

                Panel pnlBottom = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10, 0, 10, 5) };

                NumericUpDown numCantidad = new NumericUpDown { Minimum = 0, Maximum = 100, Width = 60, Dock = DockStyle.Right, Tag = flor, Font = new Font("Segoe UI", 11F) };

                ComboBox cmbColor = new ComboBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10F), DropDownStyle = ComboBoxStyle.DropDownList };

                if (!string.IsNullOrWhiteSpace(flor.ColoresDisponibles))
                {
                    string[] colores = flor.ColoresDisponibles.Split(',').Select(c => c.Trim()).ToArray();
                    cmbColor.Items.AddRange(colores);
                    cmbColor.SelectedIndex = 0;
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
                new { Text = "Papel cartucho", Price = 25m },
                new { Text = "Papel metálico", Price = 35m },
                new { Text = "Papel satinado", Price = 40m },
                new { Text = "Tela tipo yute", Price = 50m },
                new { Text = "Tela organza", Price = 55m },
                new { Text = "Tela arpillera", Price = 50m },
                new { Text = "Tela non-woven (tela floral sintética)", Price = 30m },
                new { Text = "Malla decorativa", Price = 25m },
                new { Text = "Fieltro delgado", Price = 20m },
                new { Text = "Cartulina floral rígida", Price = 30m },
                new { Text = "Conos de cartón decorativo", Price = 40m },
                new { Text = "Cajas florales con tapa (box bouquet)", Price = 120m },
                new { Text = "Envoltura tipo abanico", Price = 60m },
                new { Text = "Bolsa plástica con asas decorativa", Price = 35m },
                new { Text = "Papel perlado o brillante", Price = 40m },
                new { Text = "Envoltura transparente con figuras", Price = 25m }
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
                new { Text = "Globo de helio (temático)", Price = 150m },
                new { Text = "Peluche pequeño", Price = 150m },
                new { Text = "Peluche mediano", Price = 250m },
                new { Text = "Tarjeta personalizada", Price = 30m },
                new { Text = "Moño decorativo grande", Price = 40m },
                new { Text = "Listón personalizado", Price = 60m },
                new { Text = "Luces LED (batería)", Price = 80m },
                new { Text = "Bolsita de dulces o gomitas", Price = 50m },
                new { Text = "Botella mini de vino", Price = 200m },
                new { Text = "Perfume pequeño", Price = 300m },
                new { Text = "Caja decorativa de madera", Price = 150m },
                new { Text = "Vela aromática pequeña", Price = 90m },
                new { Text = "Sobre con dinero o vale", Price = 20m },
                new { Text = "Decoración temática", Price = 100m },
                new { Text = "Flor preservada (rosa eterna)", Price = 350m },
                new { Text = "Glitter o spray aromático", Price = 40m },
                new { Text = "Collar o accesorio especial", Price = 250m }
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
                    ForeColor = colorTextoPrincipal,
                    Margin = new Padding(10, 5, 10, 5)
                };
                flpExtras.Controls.Add(chk);
            }
        }
        #endregion

        #region Lógica de Carrito y Venta (Sin cambios en esta región)
        private void btnEliminarDelCarrito_Click(object sender, EventArgs e)
        {
            EliminarProductoSeleccionado();
        }

        private void dgvCarrito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EliminarProductoSeleccionado();
        }

        private void EliminarProductoSeleccionado()
        {
            if (dgvCarrito.CurrentRow == null)
            {
                CustomMessageBoxForm.Show("Por favor, selecciona un producto del carrito para eliminar.", "Ningún producto seleccionado", MessageBoxIcon.Warning);
                return;
            }
            var productoAEliminar = dgvCarrito.CurrentRow.DataBoundItem as VentaDetalle;
            if (productoAEliminar != null)
            {
                _carrito.Remove(productoAEliminar);
                ActualizarCarrito();
            }
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

            decimal subtotal = _carrito.Sum(i => i.TotalLinea);
            var nuevaVenta = new Venta { Fecha = DateTime.Now, Cliente = "Público General", Subtotal = subtotal, Impuestos = 0, Total = subtotal, MetodoPago = "Efectivo", Vendedor = "Kiosco", Detalles = _carrito.ToList() };

            try
            {
                await _ventaRepository.GuardarVentaAsync(nuevaVenta);
                CustomMessageBoxForm.Show($"¡Pedido #{nuevaVenta.Id} creado con éxito!\nTotal: {nuevaVenta.Total:C}", "Pedido Finalizado", MessageBoxIcon.Information);
                _carrito.Clear();
                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"No se pudo guardar el pedido: {ex.Message}", "Error al Guardar", MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}