using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUnidad4
{
    internal abstract class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int CantidadEnInventario { get; set; }

        public abstract void CalcularPrecioConImpuesto();
        public abstract void AplicarDescuento();
    }
}
