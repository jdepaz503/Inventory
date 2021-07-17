using Invetory.Core.Domains.Productos;
using Invetory.Core.UseCase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoUseCase useCase;

        public ProductosController(IProductoUseCase productoUseCase)
        { 
            useCase=productoUseCase ?? throw new ArgumentNullException(nameof(productoUseCase));
        }

        [HttpGet]
        [ApiVersion("1.0")]
        [Route("~/api/v{version:ApiVersion}/ObtenerProductos")]
        public async Task<List<ProductosResponse>> GetProducts()
        {
            var item = await useCase.GetProducts();
            return item;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        [Route("~/api/v{version:ApiVersion}/ObtenerProducto")]
        public async Task<ProductosResponse> GetProduct(int id)
        {
            var item = await useCase.GetProduct(id);
            return item;
        }


        [HttpPost]
        [ApiVersion("1.0")]
        [Route("~/api/v{version:ApiVersion}/AgregarProducto")]
        public async Task<string> AddProduct([FromBody] RegistrarProductoResponse producto)
        {
            var item = await useCase.AddProduct(producto);
            return item;
        }

        // PUT api/<ProductosController>/5
        [HttpPut]
        [ApiVersion("1.0")]
        [Route("~/api/v{version:ApiVersion}/ActualizarProducto")]
        public async Task<ProductosResponse> PutProduct([FromBody] UpdateProducto producto)
        {
            var item = await useCase.PutProducto(producto);
            return item;
        }


    }
}
