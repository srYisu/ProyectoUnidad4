using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoUnidad4
{
    public interface IMetodo
    {

        void ProcesarPago(string pais, string nombre, int telefono, int postal, string estado, string municipo, string direccion, double total, string entrega, string correo);
    }
}
