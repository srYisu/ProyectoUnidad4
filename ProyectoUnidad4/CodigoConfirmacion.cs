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
using System.Web.UI.WebControls;

namespace ProyectoUnidad4
{
    public partial class CodigoConfirmacion : Form
    {
        System.Windows.Forms.Panel invisiblePanel = new System.Windows.Forms.Panel();
        public CodigoConfirmacion()
        {
            InitializeComponent();
            InitializeComponent();
            // Agregar un control invisible que reciba el foco
            invisiblePanel.Size = new Size(0, 0); // Hacerlo invisible
            invisiblePanel.TabStop = false; // No es parte del orden de tabulación
            this.Controls.Add(invisiblePanel);

            // Al cargar el formulario, enfocar al panel invisible
            this.Load += new EventHandler(CodigoConfirmacion_Load);
        }
        
        private string cod = "Ingrese el codigo de confirmación";
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

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Dispose();
        }

        private void txtCodigoConfirmacion_Enter(object sender, EventArgs e)
        {
            if (txtCodigoConfirmacion.Text == cod)
            {
                txtCodigoConfirmacion.Text = ""; // Limpiar el texto
                txtCodigoConfirmacion.ForeColor = Color.Black; // Cambiar el color del texto a negro
            }
        }

        private void txtCodigoConfirmacion_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoConfirmacion.Text))
            {
                txtCodigoConfirmacion.Text = cod; // Restaurar el placeholder
                txtCodigoConfirmacion.ForeColor = Color.WhiteSmoke; // Cambiar el color del texto a gris
            }
        }

        private void CodigoConfirmacion_Load(object sender, EventArgs e)
        {
            this.ActiveControl = invisiblePanel;
        }
    }
}
