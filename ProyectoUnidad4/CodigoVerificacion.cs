using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoUnidad4
{
    internal class CodigoVerificacion
    {
        public static bool borrar { get; set; }
        private string myEmai = "chetosflaminconsalsa@gmail.com";
        private string myPassword = "owjq nndv qkil xyic";
        private string myAlias = "ÑemuCorp";
        private string[] myAdjuntops;
        private MailMessage mCorreo;
        public static int Codigo { get; set; }
        public void CodigoDeVerificación(string usuario, string correo, string contrasena)
        {
            Random rand = new Random();
            Codigo = rand.Next(100000, 1000000);

            mCorreo = new MailMessage();
            borrar = false;
            mCorreo.From = new MailAddress(myEmai, myAlias, System.Text.Encoding.UTF8);
            mCorreo.To.Add(correo.Trim());
            mCorreo.Subject = "Codigo de verificación para ÑEMU".Trim();
            mCorreo.IsBodyHtml = true;
            mCorreo.Body = $"{Codigo} <br/>NO COMPARTA ESTE CODIGO CON NADIE".Trim();
            mCorreo.Priority = MailPriority.High;

            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential(myEmai, myPassword);
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate,
                    X509Chain chain, SslPolicyErrors errors)
                { return true; };
                borrar = true;
                smtp.EnableSsl = true;
                smtp.Send(mCorreo);
                MessageBox.Show("Codigo de verificación enviado al correo");
                int restante;
                foreach (var producto in Producto.productos)
                {
                    foreach (var carrito in Producto.caritos)
                    {
                        if (producto.Nombre == carrito.Nombre && producto.Categoria == carrito.Categoria)
                        {
                            restante = producto.CantidadEnInventario - carrito.CantidadEnInventario;
                            producto.CantidadEnInventario = restante;
                            ReporteVentas ventas = new ReporteVentas();
                            ventas.Generar();
                            Producto.caritos.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
    }
}
