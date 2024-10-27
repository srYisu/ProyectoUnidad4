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
    public partial class Proceder_al_pago : Form
    {
        public Proceder_al_pago()
        {
            InitializeComponent();
        }

        private void pnlPagoEnLinea_Paint(object sender, PaintEventArgs e)
        {

        }
        string pais, nombreCompleto, estado, municipio, dirección;
        int telefono, postal;
        double total;

        private void btnRealizarPedido_Click(object sender, EventArgs e)
        {
            PagoTarjetaCredito tarjetaCredito = new PagoTarjetaCredito();
            tarjetaCredito.ProcesarPago("pais", "nombre", 10, 20, "estado", "municipo", "direccion", 200, "en la casa");
        }
    }
}
