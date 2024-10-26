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
    }
}
