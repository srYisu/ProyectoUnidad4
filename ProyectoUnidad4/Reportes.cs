using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoUnidad4
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
            ConfigurarTablaInventario();
            ConfigurarTablaVentas();
            ConfigurarTablaClientes();
            CargarTablaVentas();
            CargarTablaInventario();
            CargartablaClientes();

            // Asignar eventos CheckedChanged a los RadioButtons
            rdbVentas.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rdbInventario.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rdbClientes.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);

            // Ocultar todos los paneles al inicio
            pnlVentas.Visible = false;
            pnlInventarioo.Visible = false;
            pnlClientes.Visible = false;

            dgvClientes.RowHeadersVisible = false; // Eliminar primera columna vacía
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToResizeColumns = false;
            dgvClientes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvInventarioo.RowHeadersVisible = false; // Eliminar primera columna vacía
            dgvInventarioo.AllowUserToAddRows = false;
            dgvInventarioo.AllowUserToResizeColumns = false;
            dgvInventarioo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventarioo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvVentas.RowHeadersVisible = false; // Eliminar primera columna vacía
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToResizeColumns = false;
            dgvVentas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void CargarTablaVentas()
        {
            foreach (var ventas in ReporteVentas.ventas)
            {
                Image img = Image.FromFile(ventas.RutaImagen);
                dgvVentas.Rows.Add(
                    img,
                    ventas.Nombre,
                    ventas.Categoria,
                    ventas.Precio,
                    ventas.CantidadEnInventario
                    );
            }
        }
        public void CargarTablaInventario()
        {
            ReporteInventario invt = new ReporteInventario();
            ReporteInventario.inventario.Clear();
            invt.Generar();
            foreach(var inv in ReporteInventario.inventario)
            {
                Image img = Image.FromFile(inv.RutaImagen);
                dgvInventarioo.Rows.Add(
                    img,
                    inv.Nombre,
                    inv.Categoria,
                    inv.Precio,
                    inv.CantidadEnInventario
                    );
            }
        }
        private static string archivoUsuarios = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.txt");
        private void CargartablaClientes()
        {
            //verifica si existe el archivo
            if (File.Exists(archivoUsuarios))
            {
                var lineas = File.ReadAllLines(archivoUsuarios);
                foreach (var linea in lineas)
                {   //lee las lineas del txt y checa los elemtos que estan separados por ,
                    var datos = linea.Split(',');
                    dgvClientes.Rows.Add(datos[0], datos[1]);
                    
                }
            }
        }
        private void ConfigurarTablaVentas()
        {
            //agregar imagen a la columna
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "imagen";
            imgColumn.HeaderText = "Foto";
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvVentas.Columns.Add(imgColumn);

            //agregar columnas a dgvProductos
            dgvVentas.Columns.Add("Nombre", "Nombre");
            dgvVentas.Columns.Add("Categoria", "Categoria");
            dgvVentas.Columns.Add("Precio", "Precio");
            dgvVentas.Columns.Add("Cantidad", "Cantidad");
        }
        private void ConfigurarTablaClientes()
        {
            //agregar columnas a dgvProductos
            dgvClientes.Columns.Add("Usuario", "Usuario");
            dgvClientes.Columns.Add("Correo", "Correo");

        }

        private void ConfigurarTablaInventario()
        {
            //agregar imagen a la columna
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "imagen";
            imgColumn.HeaderText = "Foto";
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvInventarioo.Columns.Add(imgColumn);

            //agregar columnas a dgvProductos
            dgvInventarioo.Columns.Add("Nombre", "Nombre");
            dgvInventarioo.Columns.Add("Categoria", "Categoria");
            dgvInventarioo.Columns.Add("Precio", "Precio");
            dgvInventarioo.Columns.Add("Cantidad", "Cantidad");
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MostrarPanelSeleccionado();
        }

        private void MostrarPanelSeleccionado()
        {
            // Mostrar/ocultar paneles según el RadioButton seleccionado
            pnlVentas.Visible = rdbVentas.Checked;
            pnlInventarioo.Visible = rdbInventario.Checked;
            pnlClientes.Visible = rdbClientes.Checked;
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
