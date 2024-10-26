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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();

            // Agregar columnas a los DataGridView
            dgvVentas.Columns.Add("Prueba1", "Prueba1");
            dgvInventarioo.Columns.Add("Prueba2", "Prueba2");
            dgvClientes.Columns.Add("Prueba3", "Prueba3");

            // Asignar eventos CheckedChanged a los RadioButtons
            rdbVentas.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rdbInventario.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rdbClientes.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);

            // Ocultar todos los paneles al inicio
            pnlVentas.Visible = false;
            pnlInventarioo.Visible = false;
            pnlClientes.Visible = false;
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
