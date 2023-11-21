using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productoApp.Models
{
        public class Producto
       {
        public int ProductoId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int CtdenStock { get; set; }

        public int ProveedorId { get; set; }
    }
}
