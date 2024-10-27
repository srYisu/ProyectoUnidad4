using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoUnidad4
{
    public partial class ComprasPrincipal : Form
    {
        public ComprasPrincipal()
        {
            InitializeComponent();
            // Configura el rango del scroll
            scbFormPrincipal.Minimum = 0;
            scbFormPrincipal.Maximum = pnlFondoGeneral.DisplayRectangle.Height - pnlFondoGeneral.ClientSize.Height;
            scbFormPrincipal.SmallChange = 10;
            scbFormPrincipal.LargeChange = 50;

            // Suscríbete al evento Scroll de la barra de desplazamiento
            scbFormPrincipal.Scroll += scbFormPrincipal_Scroll;

            pnlFondoGeneral.MouseWheel += pnlFondoGeneral_MouseWheel;
            pnlFondoGeneral.Focus();
            cargarProductos();
            if (Producto.caritos.Count > 0)
            {
                picBtnCarrito.Image = Properties.Resources.carritoDeCompras__1_;
            }
        }

        int inicio = 0;
        int tamano = 4;

        List<string> productos = new List<string>();
        List<double> precios = new List<double>();
        List<string> rutas = new List<string>();
        List<int> cantidades = new List<int>();
        List<string> categorias = new List<string>();

        private void picBtnCarrito_Click(object sender, EventArgs e)
        {
            CarritoDeCompras carrito = new CarritoDeCompras();
            carrito.Show();
            this.Close();
        }

        public void cargarProductos()
        {
            //referencia a los pictureBox
            PictureBox[] pictureBoxes = {picProducto1, picProducto2, picProducto3, picProducto4 };
            Label[] nombre = {lblProducto1, lblProducto2, lblProducto3, lblProducto4 };
            Label[] precio = {lblPrecioProducto1, lblPrecioProducto2, lblPrecioProducto3, lblPrecioProducto4 };
            ComboBox[] cantidades = {cmbCantidadComprar1, cmbCantidadCompra2, cmbCantidadCompra3, cmbCantidadCompra4 };

            //limpia los pictureBox
            foreach (var pb in pictureBoxes)
            {
                pb.Image = null;
            }       
            for (int i=0; i<tamano; i++)
            {
                int indiceActual = inicio + i;
                if (indiceActual < Producto.productos.Count)
                {
                    // Agrega cada propiedad a la lista correspondiente
                    productos.Add(Producto.productos[indiceActual].Nombre);
                    precios.Add(Producto.productos[indiceActual].Precio);
                    rutas.Add(Producto.productos[indiceActual].RutaImagen);
                    //cantidades.Add(Producto.productos[indiceActual].CantidadEnInventario);
                    categorias.Add(Producto.productos[indiceActual].Categoria);

                    string rutaImagen = Producto.productos[indiceActual].RutaImagen;
                    pictureBoxes[i].Image = Image.FromFile(rutaImagen);
                    nombre[i].Text = Producto.productos [indiceActual].Nombre;
                    precio[i].Text = Convert.ToString(Producto.productos[indiceActual].Precio);
                    cantidades[i].Items.Add(Producto.productos[indiceActual].CantidadEnInventario);
                }
                else { break; }
            }
        }

        private void ComprasPrincipal_Load(object sender, EventArgs e)
        {
            btnAnteriorPag.Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Asereje");
        }

        private void scbFormPrincipal_Scroll(object sender, ScrollEventArgs e)
        {
            // Cambia la posición de desplazamiento del Panel según el valor de la barra de desplazamiento
            pnlFondoGeneral.AutoScrollPosition = new System.Drawing.Point(0, scbFormPrincipal.Value);
        }
        private void pnlFondoGeneral_MouseWheel(object sender, MouseEventArgs e)
        {
            // Ajusta el valor de desplazamiento del VScrollBar según el movimiento de la rueda del ratón
            int newScrollValue = scbFormPrincipal.Value - e.Delta / 4; // Divide Delta para ajustar la sensibilidad
            newScrollValue = Math.Max(scbFormPrincipal.Minimum, Math.Min(scbFormPrincipal.Maximum, newScrollValue));

            scbFormPrincipal.Value = newScrollValue;
            pnlFondoGeneral.AutoScrollPosition = new System.Drawing.Point(0, newScrollValue);
        }

        private void btnSiguientePag_Click(object sender, EventArgs e)
        {
            inicio += tamano;
            cargarProductos();
            btnAnteriorPag.Visible = true;
        }

        private void btnAnteriorPag_Click(object sender, EventArgs e)
        {
            inicio -= tamano;
            cargarProductos();
            if (inicio == 0)
            {
                btnAnteriorPag.Visible = false;
            }
        }
        Producto pedido;
        private void picBtnAgregarAlCarrito1_Click(object sender, EventArgs e)
        {
            // Asegúrate de que hay datos en la lista de productos temporales
            if (productos.Count > 0 && precios.Count > 0 && rutas.Count > 0 && categorias.Count > 0)
            {
                // Usamos el índice 0 para el primer producto visible en la página actual
                string nombreProducto = productos[0];
                double precioProducto = precios[0];
                string rutaImagen = rutas[0];
                string categoria = categorias[0];

                // Obtén la cantidad seleccionada en el ComboBox correspondiente
                int cantidadSeleccionada = Convert.ToInt32(cmbCantidadComprar1.SelectedItem ?? 1);

                // Crea un nuevo objeto de carrito con los datos obtenidos
                ProductosCarrito pedido = new ProductosCarrito(nombreProducto, categoria, precioProducto, cantidadSeleccionada, rutaImagen);

                // Agrega el producto al carrito
                Producto.caritos.Add(pedido);

                // Cambia la imagen del botón del carrito para reflejar que se agregó un producto
                picBtnCarrito.Image = Properties.Resources.carritoDeCompras__1_;

                MessageBox.Show($"Producto '{nombreProducto}' agregado al carrito con éxito.");
            }
            else
            {
                MessageBox.Show("No se pudo agregar el producto al carrito. Verifica los datos.");
            }
        }
        private void picBtnAgregarAlCarrito2_Click(object sender, EventArgs e)
        {
            // Asegúrate de que hay datos en la lista de productos temporales
            if (productos.Count > 0 && precios.Count > 0 && rutas.Count > 0 && categorias.Count > 0)
            {
                // Usamos el índice 0 para el primer producto visible en la página actual
                string nombreProducto = productos[1];
                double precioProducto = precios[1];
                string rutaImagen = rutas[1];
                string categoria = categorias[1];

                // Obtén la cantidad seleccionada en el ComboBox correspondiente
                int cantidadSeleccionada = Convert.ToInt32(cmbCantidadComprar1.SelectedItem ?? 1);

                // Crea un nuevo objeto de carrito con los datos obtenidos
                ProductosCarrito pedido = new ProductosCarrito(nombreProducto, categoria, precioProducto, cantidadSeleccionada, rutaImagen);

                // Agrega el producto al carrito
                Producto.caritos.Add(pedido);

                // Cambia la imagen del botón del carrito para reflejar que se agregó un producto
                picBtnCarrito.Image = Properties.Resources.carritoDeCompras__1_;

                MessageBox.Show($"Producto '{nombreProducto}' agregado al carrito con éxito.");
            }
            else
            {
                MessageBox.Show("No se pudo agregar el producto al carrito. Verifica los datos.");
            }
        }
        private void picBtnAgreagarAlCarrito3_Click(object sender, EventArgs e)
        {
            // Asegúrate de que hay datos en la lista de productos temporales
            if (productos.Count > 0 && precios.Count > 0 && rutas.Count > 0 && categorias.Count > 0)
            {
                // Usamos el índice 0 para el primer producto visible en la página actual
                string nombreProducto = productos[2];
                double precioProducto = precios[2];
                string rutaImagen = rutas[2];
                string categoria = categorias[2];

                // Obtén la cantidad seleccionada en el ComboBox correspondiente
                int cantidadSeleccionada = Convert.ToInt32(cmbCantidadComprar1.SelectedItem ?? 1);

                // Crea un nuevo objeto de carrito con los datos obtenidos
                ProductosCarrito pedido = new ProductosCarrito(nombreProducto, categoria, precioProducto, cantidadSeleccionada, rutaImagen);

                // Agrega el producto al carrito
                Producto.caritos.Add(pedido);

                // Cambia la imagen del botón del carrito para reflejar que se agregó un producto
                picBtnCarrito.Image = Properties.Resources.carritoDeCompras__1_;

                MessageBox.Show($"Producto '{nombreProducto}' agregado al carrito con éxito.");
            }
            else
            {
                MessageBox.Show("No se pudo agregar el producto al carrito. Verifica los datos.");
            }
        }
        private void picBtnAgregarAlCarrito4_Click(object sender, EventArgs e)
        {
            // Asegúrate de que hay datos en la lista de productos temporales
            if (productos.Count > 0 && precios.Count > 0 && rutas.Count > 0 && categorias.Count > 0)
            {
                // Usamos el índice 0 para el primer producto visible en la página actual
                string nombreProducto = productos[3];
                double precioProducto = precios[3];
                string rutaImagen = rutas[3];
                string categoria = categorias[3];

                // Obtén la cantidad seleccionada en el ComboBox correspondiente
                int cantidadSeleccionada = Convert.ToInt32(cmbCantidadComprar1.SelectedItem ?? 1);

                // Crea un nuevo objeto de carrito con los datos obtenidos
                ProductosCarrito pedido = new ProductosCarrito(nombreProducto, categoria, precioProducto, cantidadSeleccionada, rutaImagen);

                // Agrega el producto al carrito
                Producto.caritos.Add(pedido);

                // Cambia la imagen del botón del carrito para reflejar que se agregó un producto
                picBtnCarrito.Image = Properties.Resources.carritoDeCompras__1_;

                MessageBox.Show($"Producto '{nombreProducto}' agregado al carrito con éxito.");
            }
            else
            {
                MessageBox.Show("No se pudo agregar el producto al carrito. Verifica los datos.");
            }
        }
    }
}
