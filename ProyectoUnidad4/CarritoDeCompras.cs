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
    public partial class CarritoDeCompras : Form
    {
        public CarritoDeCompras()
        {
            InitializeComponent();
            ConfigurarTabla();
            CargarProductosCarrito();
            CalcularTotal();
            dgvCarritoDeCompras.RowHeadersVisible = false; // Eliminar primera columna vacía
        }
        public static string entrega;
        public static double totalProductos;
        private void ConfigurarTabla()
        {
            //agregar imagen a la columna
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "imagen";
            imgColumn.HeaderText = "Foto";
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvCarritoDeCompras.Columns.Add(imgColumn);

            //agregar columnas a dgvProductos
            dgvCarritoDeCompras.Columns.Add("Nombre", "Nombre");
            dgvCarritoDeCompras.Columns.Add("Categoria", "Categoria");
            dgvCarritoDeCompras.Columns.Add("Precio", "Precio");
            dgvCarritoDeCompras.Columns.Add("Cantidad", "Cantidad");

            // Columna para Eliminar
            DataGridViewImageColumn btnEliminar = new DataGridViewImageColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            btnEliminar.Image = Properties.Resources.carritoDeCompras__3_;
            dgvCarritoDeCompras.Columns.Add(btnEliminar);
        }
        private void CargarProductosCarrito()
        {
            dgvCarritoDeCompras.Rows.Clear(); //limpar las filas
            foreach (var producto in Producto.caritos)
            {
                Image img = Image.FromFile(producto.RutaImagen);
                dgvCarritoDeCompras.Rows.Add(
                    img,
                    producto.Nombre,
                    producto.Categoria,
                    producto.Precio,
                    producto.CantidadEnInventario
                    );
            }
        }

        private void dgvCarritoDeCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCarritoDeCompras.ClearSelection();
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvCarritoDeCompras.Columns["btnEliminar"].Index)
                {
                    EliminarProducto(e.RowIndex);
                }
            }
        }
        private void EliminarProducto(int index)
        {
            Producto.caritos.RemoveAt(index);
            CargarProductosCarrito();
        }
        double total = 0;
        private void CalcularTotal()
        {
            foreach (var precio in Producto.caritos)
            {
                total += (precio.Precio * precio.CantidadEnInventario);
            }
            lblTotalDeCostos.Text = total.ToString();
            totalProductos = total;
        }
        private void btnRealizarPedido_Click(object sender, EventArgs e)
        {
            if (rdbOnline.Checked)
            {
                entrega = "Entrega a domicilio";
                Proceder_al_pago pago = new Proceder_al_pago();
                pago.FormClosed += Form2_FormClosed;
                pago.Show();
                

            }
            else if (rdbTienda.Checked)
            {
                entrega = "Entrega a tienda";
                Proceder_al_pago pago = new Proceder_al_pago();
                pago.FormClosed += Form2_FormClosed;
                pago.Show();

            }
            else { MessageBox.Show("Seleccione un metodo de enterga"); }
            
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarProductosCarrito();
        }
        private void CarritoDeCompras_Load(object sender, EventArgs e)
        {
            
        }
    }
}
