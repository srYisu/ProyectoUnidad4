using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoUnidad4
{
    public partial class CodigoConfirmacion : Form
    {
        public CodigoConfirmacion()
        {
            InitializeComponent();
        }
        int codigo;
        private static string archivoUsuarios = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios.txt");
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            codigo = Convert.ToInt32(txtCodigoConfirmacion.Text);
            if (CodigoVerificacion.Codigo == codigo)
            {
                using (StreamWriter sw = File.AppendText(archivoUsuarios))
                {
                    sw.WriteLine($"{CrearCuenta.usuario},{CrearCuenta.correo},{CrearCuenta.contrasena}");
                }
                MessageBox.Show("Registro exitoso");
                Form1 f1 = new Form1();
                f1.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Codigo incorrecto", "Error");
            }

        }
    }
}
