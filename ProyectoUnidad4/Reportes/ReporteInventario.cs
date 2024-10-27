using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUnidad4
{
    internal class ReporteInventario : IGenerarReporte
    {
        public static List<Producto> inventario = new List<Producto>();
        public void Generar()
        {
            foreach (var agregar in Producto.productos)
            {
                // Crear una nueva instancia de ProductosCarrito con los datos de 'carrito'
                var copiaProducto = new ProductoElectronico(
                    agregar.Nombre,
                    agregar.Categoria,
                    agregar.Precio,
                    agregar.CantidadEnInventario,
                    agregar.RutaImagen
                );
                // Agregar la copia a 'ReporteVentas.ventas'
                ReporteInventario.inventario.Add(copiaProducto);
            }
        }
    }
}
