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

            // Asignar eventos CheckedChanged a los RadioButtons
            rdbTarjetaDeCredito.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rdbEfectivo.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            rdbPaypal.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
        }
        string destino = CarritoDeCompras.entrega;
        double total = CarritoDeCompras.totalProductos;
        private void pnlPagoEnLinea_Paint(object sender, PaintEventArgs e)
        {

        }
        string pais, nombreCompleto, estado, municipio, dirección;
        int telefono, postal;
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mostrarPanel();
        }
        private void mostrarPanel()
        {
            pnlPagoEnLinea.Visible = rdbTarjetaDeCredito.Checked;
            pnlPagoEnEfectivo.Visible = rdbEfectivo.Checked;
            pnlPaypal.Visible = rdbPaypal.Checked;
        }
        PagoTarjetaCredito tarjetaCredito = new PagoTarjetaCredito();
        PagoEfectivon efectivo = new PagoEfectivon();
        PagoPaypal paypal = new PagoPaypal();
        private void btnRealizarPedido_Click(object sender, EventArgs e)
        {
            pais = txtPaisDestino.Text; nombreCompleto = txtNombreCompleto.Text; estado = txtEstado.Text;
            municipio = txtMunicipio.Text; dirección = txtDireccion.Text;

            telefono = Convert.ToInt32(txtNumeroTelefono.Text); postal = Convert.ToInt32(txtCodigoPostal.Text); 

            if (rdbTarjetaDeCredito.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtPaisDestino.Text) || string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                    string.IsNullOrWhiteSpace(txtNumeroTelefono.Text) || string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ||
                    string.IsNullOrWhiteSpace(txtEstado.Text) || string.IsNullOrWhiteSpace(txtMunicipio.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtNumeroTarjeta.Text) ||
                    string.IsNullOrWhiteSpace(txtFechaDeVencimiento.Text) || string.IsNullOrWhiteSpace(txtCVV.Text))
                {
                    MessageBox.Show("Rellene todos los datos por favor");
                    
                }
                tarjetaCredito.ProcesarPago(pais, nombreCompleto, telefono, postal, estado, municipio, dirección, total, destino);
            }
            if (rdbEfectivo.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtPaisDestino.Text) || string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                    string.IsNullOrWhiteSpace(txtNumeroTelefono.Text) || string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ||
                    string.IsNullOrWhiteSpace(txtEstado.Text) || string.IsNullOrWhiteSpace(txtMunicipio.Text) || 
                    string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    MessageBox.Show("Rellene todos los datos por favor");
                    
                }
                efectivo.ProcesarPago(pais, nombreCompleto, telefono, postal, estado, municipio, dirección, total, destino);

            }
            if (rdbPaypal.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtPaisDestino.Text) || string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                    string.IsNullOrWhiteSpace(txtNumeroTelefono.Text) || string.IsNullOrWhiteSpace(txtCodigoPostal.Text) ||
                    string.IsNullOrWhiteSpace(txtEstado.Text) || string.IsNullOrWhiteSpace(txtMunicipio.Text) || 
                    string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) ||
                    string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    MessageBox.Show("Rellene todos los datos por favor");
                    
                }
                paypal.ProcesarPago(pais, nombreCompleto, telefono, postal, estado, municipio, dirección, total, destino);

            }
        }
    }
}
