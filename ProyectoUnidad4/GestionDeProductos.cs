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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ProyectoUnidad4
{
    public partial class GestionDeProductos : Form
    {
        string rutaArchivo;
        private Producto productoTemporal = null;
        public GestionDeProductos()
        {
            InitializeComponent();
            ConfigurarTabla();
            CargarComboBox();
            CargarDataGridView();
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        
        private void ConfigurarTabla()
        {
            //agregar imagen a la columna
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "imagen";
            imgColumn.HeaderText = "Foto";
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvProductos.Columns.Add(imgColumn);

            //agregar columnas a dgvProductos
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Categoria", "Categoria");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Cantidad", "Cantidad");
            // Columna para Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dgvProductos.Columns.Add(btnEditar);

            // Columna para Eliminar
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvProductos.Columns.Add(btnEliminar);
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
                Image img = Image.FromFile(producto.RutaImagen);
                dgvProductos.Rows.Add(
                    img,
                    producto.Nombre,
                    producto.Categoria,
                    producto.Precio,
                    producto.CantidadEnInventario
                    );
            }   
        }
        int indiceProductoActual;
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProductos.Columns["btnEditar"].Index && e.RowIndex >= 0)
            {
                // Obtén el producto seleccionado desde la lista de productos
                Producto productoSeleccionado = Producto.productos[e.RowIndex];

                // Carga los valores en los controles para su edición
                txtNombre.Text = productoSeleccionado.Nombre;
                txtCantidad.Text = productoSeleccionado.CantidadEnInventario.ToString();
                txtPrecio.Text = productoSeleccionado.Precio.ToString();
                cmbCategoria.SelectedItem = productoSeleccionado.Categoria;

                // Guarda el índice del producto que estamos editando
                indiceProductoActual = e.RowIndex;
            }
            if (e.ColumnIndex == dgvProductos.Columns["btnEliminar"].Index && e.RowIndex >= 0)
            {
                EliminarProducto(e.RowIndex);
            }
        }
        private void EliminarProducto(int index)
        {
            Producto.productos.RemoveAt(index);
            CargarDataGridView();
        }
        private void LimpiarCampos()
        {
            txtCantidad.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            cmbCategoria.SelectedIndex = 0;
        }
        private void GestionDeProductos_Load(object sender, EventArgs e)
        {
            CargarDataGridView();
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
                lblArchivoSeleccionado.Text = rutaArchivo;
            }
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) ||
       string.IsNullOrWhiteSpace(txtPrecio.Text) || cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los datos", "Advertencia");
                return;
            }

            string categoria = cmbCategoria.SelectedItem.ToString();
            Producto producto;

            // Crear o editar producto según el valor de indiceProductoActual
            if (indiceProductoActual >= 0 && indiceProductoActual < Producto.productos.Count)  // Estamos editando un producto existente
            {
                // Editar los valores del producto existente en la lista
                producto = Producto.productos[indiceProductoActual];
                producto.Nombre = txtNombre.Text;
                producto.Categoria = categoria;
                producto.Precio = Convert.ToDouble(txtPrecio.Text);
                producto.CantidadEnInventario = Convert.ToInt32(txtCantidad.Text);
            }
            else  // Es un nuevo producto, agregarlo a la lista
            {
                // Crear un nuevo producto basado en la categoría seleccionada
                switch (categoria)
                {
                    case "Alimentario":
                        producto = new ProductoAlimentario(txtNombre.Text, categoria, Convert.ToDouble(txtPrecio.Text),
                                                           Convert.ToInt32(txtCantidad.Text), rutaArchivo);
                        break;
                    case "Electrónico":
                        producto = new ProductoElectronico(txtNombre.Text, categoria, Convert.ToDouble(txtPrecio.Text),
                                                           Convert.ToInt32(txtCantidad.Text), rutaArchivo);
                        break;
                    case "Ropa":
                        producto = new ProductoRopa(txtNombre.Text, categoria, Convert.ToDouble(txtPrecio.Text),
                                                    Convert.ToInt32(txtCantidad.Text), rutaArchivo);
                        break;
                    default:
                        return;
                }
                // Agregar el nuevo producto a la lista
                Producto.productos.Add(producto);
            }

            // Resetear el índice después de guardar los cambios
            indiceProductoActual = -1;

            // Limpiar los campos y recargar el DataGridView
            LimpiarCampos();
            CargarDataGridView();
        }
        
    }
}