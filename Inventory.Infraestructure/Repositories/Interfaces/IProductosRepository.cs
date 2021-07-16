using Inventory.Infraestructure.Models;
using Invetory.Core.Domains.Productos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infraestructure.Repositories.Interfaces
{
    public interface IProductosRepository
    {
        Task<List<ProductosResponse>> GetProducts();
        Task<ProductosResponse> PutProducto(int id, Producto producto);
    }
}
