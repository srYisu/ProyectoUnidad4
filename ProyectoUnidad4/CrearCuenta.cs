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
        Panel invisiblePanel = new Panel();
        public CrearCuenta()
        {
            InitializeComponent();

            // Agregar un control invisible que reciba el foco
            invisiblePanel.Size = new Size(0, 0); // Hacerlo invisible
            invisiblePanel.TabStop = false; // No es parte del orden de tabulación
            this.Controls.Add(invisiblePanel);

            // Al cargar el formulario, enfocar al panel invisible
            this.Load += new EventHandler(CrearCuenta_Load);

            txtUsuario.Text = usuarioText;
            txtUsuario.ForeColor = Color.Gray;
            txtCorreo.Text = correoText;
            txtCorreo.ForeColor = Color.Gray;
            txtContrasena.Text = contrasenaText;
            txtContrasena.ForeColor = Color.Gray;
            txtConfirmarContrasena.Text = Contrasena2text;
            txtConfirmarContrasena.ForeColor = Color.Gray;
        }
        private string usuarioText = "Usuario", correoText = "Correo @gmail.com", contrasenaText = "Contraseña", Contrasena2text = "Confirmar Contraseña";
        CodigoVerificacion verificar = new CodigoVerificacion();

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == usuarioText)
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == correoText)
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.Black;
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == contrasenaText)
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.Black;
            }
        }

        private void txtConfirmarContrasena_Enter(object sender, EventArgs e)
        {
            if (txtConfirmarContrasena.Text == Contrasena2text)
            {
                txtConfirmarContrasena.Text = "";
                txtConfirmarContrasena.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = usuarioText; // Restaurar el placeholder
                txtUsuario.ForeColor = Color.Gray; // Cambiar el color del texto a gris
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                txtCorreo.Text = correoText; // Restaurar el placeholder
                txtCorreo.ForeColor = Color.Gray; // Cambiar el color del texto a gris
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                txtContrasena.Text = contrasenaText; // Restaurar el placeholder
                txtContrasena.ForeColor = Color.Gray; // Cambiar el color del texto a gris
            }
        }

        private void txtConfirmarContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                txtConfirmarContrasena.Text = Contrasena2text; // Restaurar el placeholder
                txtConfirmarContrasena.ForeColor = Color.Gray; // Cambiar el color del texto a gris
            }
        }

        private void CrearCuenta_Load(object sender, EventArgs e)
        {
            this.ActiveControl = invisiblePanel;
        }

        public static string usuario, correo, contrasena;

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Dispose();
        }

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
