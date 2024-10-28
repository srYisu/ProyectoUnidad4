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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnGestionDeProductos_Click(object sender, EventArgs e)
        {
            GestionDeProductos gestionDeProductos = new GestionDeProductos();
            gestionDeProductos.Show();
            this.Close();
        }

        private void btnGestionDeClientes_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
            this.Close();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnPaginaPrincipal_Click(object sender, EventArgs e)
        {
            ComprasPrincipal principal = new ComprasPrincipal();
            principal.Show();
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
