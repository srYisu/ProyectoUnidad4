using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUnidad4
{
    public abstract class Producto
    {
        public static List<Producto> productos = new List<Producto>();
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int CantidadEnInventario { get; set; }
        public string Categoria { get; set; }
        public string RutaImagen { get; set; }
        public Producto(string nombre, string categoria, double precio, int cantidad, string imagen)
        {
            Nombre = nombre; Categoria = categoria; Precio = precio; CantidadEnInventario = cantidad; RutaImagen = imagen;
        }
        public abstract void CalcularPrecioConImpuesto();
        public abstract void AplicarDescuento();
    }
}
