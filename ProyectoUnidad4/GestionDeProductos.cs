using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoUnidad4
{
    public partial class GestionDeProductos : Form
    {
        string rutaArchivo;
        public GestionDeProductos()
        {
            InitializeComponent();
            ConfigurarTabla();
            CargarComboBox();
            CargarDataGridView();
        }
        
        private void ConfigurarTabla()
        {
            //agregar columnas a dgvProductos
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Categoria", "Categoria");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Cantidad", "Cantidad");
        }

        private void CargarComboBox()
        {
            //Agregar opciones a combobox
            cmbCategoria.Items.Add("Alimentario");
            cmbCategoria.Items.Add("Electrónico");
            cmbCategoria.Items.Add("Ropa");
        }
        private void CargarDataGridView()
        {
            dgvProductos.Rows.Clear(); //limpar las filas

            foreach (var producto in Producto.productos)
            {
                dgvProductos.Rows.Add(
                    producto.Nombre,
                    producto.Categoria,
                    producto.Precio,
                    producto.CantidadEnInventario
                    );
            }

            
        }

        private void GestionDeProductos_Load(object sender, EventArgs e)
        {
            CargarDataGridView();
            CargarComboBox();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Adjuntar archivo al correo";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = ofd.FileName;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                cmbCategoria.SelectedIndex == -1 || cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los datos", "Advertencia");
                return;
            }
            Producto producto = null;
            string categoria= cmbCategoria.SelectedItem.ToString();
            switch (categoria)
            {
                case "Alimentario":
                    producto = new ProductoAlimentario(
                        txtNombre.Text,
                        categoria,
                        Convert.ToDouble(txtPrecio.Text),
                        Convert.ToInt32(txtCantidad.Text),
                        rutaArchivo
                        );
                    break;

                case "Electrónico":
                    producto = new ProductoElectronico(
                        txtNombre.Text,
                        categoria,
                        Convert.ToDouble(txtPrecio.Text),
                        Convert.ToInt32(txtCantidad.Text),
                        rutaArchivo);
                    break;

                case "Ropa":
                    producto = new ProductoRopa(
                        txtNombre.Text,
                        categoria,
                        Convert.ToDouble(txtPrecio.Text),
                        Convert.ToInt32(txtCantidad.Text),
                        rutaArchivo);
                    break;
            }
            Producto.productos.Add(producto);
            CargarDataGridView();
        }
    }
}
