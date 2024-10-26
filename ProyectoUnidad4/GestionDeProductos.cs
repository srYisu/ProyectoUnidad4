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
        public GestionDeProductos()
        {
            InitializeComponent();
        }
        //agregas un producto "objeto" a la lista correspondiente

        //agregas el "objeto" a la lista universal

        //foeach();
        //imprimes la lista de dicha categoria

        //foreach(); para la lista universal al filtar por nombre

        private void GestionDeProductos_Load(object sender, EventArgs e)
        {
            //Agregar opciones a combobox
            cmbCategoria.Items.Add("Alimentario");
            cmbCategoria.Items.Add("Electrónico");
            cmbCategoria.Items.Add("Ropa");

            //agregar columnas a dgvProductos
            dgvProductos.Columns.Add("Nombre","Nombre");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Cantidad", "Cantidad");
            dgvProductos.Columns.Add("Categoría", "Categoría");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }
    }
}
