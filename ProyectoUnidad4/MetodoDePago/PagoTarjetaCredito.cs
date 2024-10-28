using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Windows.Forms;

namespace ProyectoUnidad4
{
    public class PagoTarjetaCredito : IMetodo
    {
        public static bool borrar { get; set; }
        private string myEmai = "chetosflaminconsalsa@gmail.com";
        private string myPassword = "owjq nndv qkil xyic";
        private string myAlias = "ÑemuCorp";
        private string[] myAdjuntops;
        private MailMessage mCorreo;
        public void ProcesarPago(string pais, string nombre, int telefono, int postal, string estado, string municipo, string direccion,double total, string entrega, string correo )
        {
            mCorreo = new MailMessage();
            borrar = false;
            mCorreo.From = new MailAddress(myEmai, myAlias, System.Text.Encoding.UTF8);
            mCorreo.To.Add(correo.Trim());
            mCorreo.Subject = "Pago procesado".Trim();
            mCorreo.IsBodyHtml = true;
            mCorreo.Body = $"Su pedido de ${total} ha sido procesado exitosamente.<br/>Metodo de pago: Tarjeta de credito <br/> <br/>Datos personales <br/>Nombre: {nombre}." +
                $"Telefono: {telefono} <br/>{pais} {estado} {municipo} <br/>{direccion} <br/>Para destino en {entrega}. ".Trim();
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
                MessageBox.Show("Transacción finalizada");
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
