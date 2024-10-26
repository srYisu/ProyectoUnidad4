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
    public partial class Form1 : Form
    {
        Panel invisiblePanel = new Panel();
        private string password = "Contraseña";
        private string user = "Usuario";
        public Form1()
        {
            InitializeComponent();
            // Agregar un control invisible que reciba el foco
            invisiblePanel.Size = new Size(0, 0); // Hacerlo invisible
            invisiblePanel.TabStop = false; // No es parte del orden de tabulación
            this.Controls.Add(invisiblePanel);

            // Al cargar el formulario, enfocar al panel invisible
            this.Load += new EventHandler(Form1_Load);

            // Asignar el texto de placeholder inicialmente
            txtContrasenaReal.Text = password;
            txtContrasenaReal.ForeColor = Color.WhiteSmoke; // Cambiar color del texto para diferenciar el placeholder
            txtUsuarioReal.Text = user;
            txtUsuarioReal.ForeColor = Color.WhiteSmoke;
            // Suscribir los eventos Enter y Leave del TextBox
            txtContrasenaReal.Enter += new EventHandler(txtContrasena_Enter);
            txtContrasenaReal.Leave += new EventHandler(txtContrasena_Leave);
            txtUsuarioReal.Enter += new EventHandler(txtUsuario_Enter);
            txtUsuarioReal.Leave += new EventHandler(txtUsuario_Leave);

            btnInciarSesionReal.Click += new EventHandler(btnInicarSesion_Click);

            tgsMostrarContraseña1.CheckedChanged += new EventHandler(tgsMostrarContraseña_CheckedChanged);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = invisiblePanel;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuarioReal.Text == user)
            {
                txtUsuarioReal.Text = ""; // Limpiar el texto
                txtUsuarioReal.ForeColor = Color.White; // Cambiar el color del texto a negro
            }
        }
        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasenaReal.Text == password)
            {
                txtContrasenaReal.Text = ""; // Limpiar el texto
                txtContrasenaReal.ForeColor = Color.White; // Cambiar el color del texto a negro
                txtContrasenaReal.PasswordChar = '*'; // Activar el modo de contraseña
            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuarioReal.Text))
            {
                txtUsuarioReal.Text = user; // Restaurar el placeholder
                txtUsuarioReal.ForeColor = Color.WhiteSmoke; // Cambiar el color del texto a gris
            }
        }
        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasenaReal.Text))
            {
                txtContrasenaReal.PasswordChar = '\0';
                txtContrasenaReal.Text = password; // Restaurar el placeholder
                txtContrasenaReal.ForeColor = Color.WhiteSmoke; // Cambiar el color del texto a gris

            }
        }

        private void btnInicarSesion_Click(object sender, EventArgs e)
        {
            string usuario = "asereje";
            string contrasena = "123";
            if (txtUsuarioReal.Text == usuario && txtContrasenaReal.Text == contrasena)
            {
                ComprasPrincipal p = new ComprasPrincipal();
                this.Visible = false;
                p.Show();

            }
        }

        private void tgsMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (tgsMostrarContraseña1.Checked)
            {
                // Si el CheckBox está marcado, mostrar la contraseña
                txtContrasenaReal.PasswordChar = '\0'; // Mostrar el texto sin ocultarlo
            }
            else
            {
                // Si el CheckBox no está marcado, ocultar la contraseña
                txtContrasenaReal.PasswordChar = '*'; // Ocultar la contraseña con asteriscos
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
