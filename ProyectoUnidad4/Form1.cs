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
            txtContrasena.Text = password;
            txtContrasena.ForeColor = Color.Gray; // Cambiar color del texto para diferenciar el placeholder
            txtUsuario.Text = user;
            txtUsuario.ForeColor = Color.Gray;
            // Suscribir los eventos Enter y Leave del TextBox
            txtContrasena.Enter += new EventHandler(txtContrasena_Enter);
            txtContrasena.Leave += new EventHandler(txtContrasena_Leave);
            txtUsuario.Enter += new EventHandler(txtUsuario_Enter);
            txtUsuario.Leave += new EventHandler(txtUsuario_Leave);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = invisiblePanel;
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == user)
            {
                txtUsuario.Text = ""; // Limpiar el texto
                txtUsuario.ForeColor = Color.Black; // Cambiar el color del texto a negro
            }
        }
        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == password)
            {
                txtContrasena.Text = ""; // Limpiar el texto
                txtContrasena.ForeColor = Color.Black; // Cambiar el color del texto a negro
                txtContrasena.PasswordChar = '*'; // Activar el modo de contraseña
            }
        }
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = user; // Restaurar el placeholder
                txtUsuario.ForeColor = Color.Gray; // Cambiar el color del texto a gris
            }
        }
        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                txtContrasena.PasswordChar = '\0';
                txtContrasena.Text = password; // Restaurar el placeholder
                txtContrasena.ForeColor = Color.Gray; // Cambiar el color del texto a gris

            }
        }

        private void btnInicarSesion_Click(object sender, EventArgs e)
        {
            string usuario = "asereje";
            string contrasena = "123";
            if (txtUsuario.Text == usuario && txtContrasena.Text == contrasena)
            {
                ComprasPrincipal p = new ComprasPrincipal();
                this.Visible = false;
                p.Show();
                
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
