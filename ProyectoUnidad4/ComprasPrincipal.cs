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
        }

        private void ComprasPrincipal_Load(object sender, EventArgs e)
        {

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
    }
}
