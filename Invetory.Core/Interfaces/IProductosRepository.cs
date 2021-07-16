using Invetory.Core.Domains.Productos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invetory.Core.Interfaces
{
    public interface IProductosRepository
    {
        Task<List<ProductosResponse>> GetProducts();
        Task<ProductosResponse> PutProducto(UpdateProducto producto);
    }
}
