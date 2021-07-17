using Invetory.Core.Domains.Productos;
using Invetory.Core.Interfaces;
using Invetory.Core.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invetory.Core.UseCase
{
    public class ProductoUseCase: IProductoUseCase
    {
        private readonly IProductosRepository repository;

        public ProductoUseCase(IProductosRepository productosRepository)
        {
            repository = productosRepository ?? throw new ArgumentNullException(nameof(productosRepository));
        }

        public async Task<List<ProductosResponse>> GetProducts()=> await repository.GetProducts();
        public async Task<ProductosResponse> GetProduct(int id) => await repository.GetProduct(id);
        public async Task<string> AddProduct(RegistrarProductoResponse producto) => await repository.AddProduct(producto);
        public async Task<ProductosResponse> PutProducto(UpdateProducto producto) => await repository.PutProducto(producto);

       

    }
}
