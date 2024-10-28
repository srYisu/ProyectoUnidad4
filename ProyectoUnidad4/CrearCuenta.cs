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
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }
        CodigoVerificacion verificar = new CodigoVerificacion();
        public static string usuario, correo, contrasena;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtContrasena.Text == txtConfirmarContrasena.Text)
            {
                usuario = txtUsuario.Text;
                correo = txtCorreo.Text;
                contrasena = txtContrasena.Text;

                CodigoConfirmacion confi = new CodigoConfirmacion();
                confi.Visible = true;
                this.Close();
                verificar.CodigoDeVerificación(usuario, correo, contrasena);
            }
        }
    }
}
