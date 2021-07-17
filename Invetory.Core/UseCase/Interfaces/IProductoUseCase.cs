using Invetory.Core.Domains.Productos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invetory.Core.UseCase.Interfaces
{
    public interface IProductoUseCase
    {
        Task<List<ProductosResponse>> GetProducts();
        Task<string> AddProduct(RegistrarProductoResponse producto);
        Task<ProductosResponse> PutProducto(UpdateProducto producto);
    }
}
