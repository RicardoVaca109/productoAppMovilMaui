using productoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productoApp.Utils
{
    internal class Utils
    {
        static public List<Producto> ListaProductos = new List<Producto>()
        {
            new Producto
            {
                ProductoId = 1,
                Nombre = "Procan",
                Descripcion = "Comida para perros",
                Precio = 54.99,
                CtdenStock = 45,
                ProveedorId = 1
            },
            new Producto
            {
                ProductoId = 2,
                Nombre = "Manicris",
                Descripcion = "Mani",
                Precio = 4.90,
                CtdenStock = 43,
                ProveedorId = 1
            }
        };
    }
}
