using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUnidad4
{
    public class ProductoRopa : Producto
    {

        public ProductoRopa(string nombre, string categoria, double precio,  int cantidad, string imagen) : base(nombre, categoria, precio, cantidad ,imagen)
        {
            Nombre = nombre; Categoria = categoria; Precio = precio; CantidadEnInventario = cantidad; RutaImagen = imagen;
        }
        public override double AplicarDescuento()
        {
            return Precio = Precio - (Precio * 0.12);
        }
        public override double CalcularPrecioConImpuesto()
        {
            throw new NotImplementedException();
        }

    }
}
