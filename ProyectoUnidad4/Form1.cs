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
            guna2TextBox2.Text = password;
            guna2TextBox2.ForeColor = Color.Gray; // Cambiar color del texto para diferenciar el placeholder
            txtUsuario.Text = user;
            txtUsuario.ForeColor = Color.Gray;
            // Suscribir los eventos Enter y Leave del TextBox
            guna2TextBox2.Enter += new EventHandler(txtContrasena_Enter);
            guna2TextBox2.Leave += new EventHandler(txtContrasena_Leave);
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
            if (guna2TextBox2.Text == password)
            {
                guna2TextBox2.Text = ""; // Limpiar el texto
                guna2TextBox2.ForeColor = Color.Black; // Cambiar el color del texto a negro
                guna2TextBox2.PasswordChar = '*'; // Activar el modo de contraseña
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
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                guna2TextBox2.PasswordChar = '\0';
                guna2TextBox2.Text = password; // Restaurar el placeholder
                guna2TextBox2.ForeColor = Color.Gray; // Cambiar el color del texto a gris

            }
        }
    }
}
