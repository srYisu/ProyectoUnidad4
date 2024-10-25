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
    public partial class InicioAplicacion : Form
    {
        public InicioAplicacion()
        {
            InitializeComponent();
        }

        private void InicioAplicacion_Load(object sender, EventArgs e)
        {
            guna2ProgressBar1.Value = 0;
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            guna2ProgressBar1.Value += 1; // Aumenta el progreso cada tick

            // Verifica si la barra de progreso ha alcanzado el máximo
            if (guna2ProgressBar1.Value >= guna2ProgressBar1.Maximum)
            {
                timer1.Stop(); // Detén el temporizador
                this.Hide(); // Oculta el formulario actual

                Form1 f = new Form1(); // Crea una instancia de Form2
                f.Show(); // Muestra el nuevo formulario
            }

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
