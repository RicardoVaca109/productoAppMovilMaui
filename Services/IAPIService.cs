using productoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productoApp.Services
{
    public interface IAPIService
    {
        public Task<List<Producto>> GetProductos();
        public Task<Producto> GetProducto(int ProveedorId);
        public Task<Producto> PostProducto(Producto producto);
        public Task<Producto> PutProducto(int ProductoId, Producto producto);
        public Task<Boolean> DeleteProducto(int ProductoId);
    }
}
