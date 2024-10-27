using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUnidad4
{
    internal class ReporteVentas : IGenerarReporte
    {
        public static List<Producto> ventas = new List<Producto>();
        public void Generar()
        {
            foreach (var carrito in Producto.caritos)
            {
                // Crear una nueva instancia de ProductosCarrito con los datos de 'carrito'
                var copiaProducto = new ProductosCarrito(
                    carrito.Nombre,
                    carrito.Categoria,
                    carrito.Precio,
                    carrito.CantidadEnInventario,
                    carrito.RutaImagen
                );
                // Agregar la copia a 'ReporteVentas.ventas'
                ReporteVentas.ventas.Add(copiaProducto);
            }
        }
    }
}
