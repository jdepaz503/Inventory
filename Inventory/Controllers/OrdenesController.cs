using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Infraestructure.Models;
using Invetory.Core.Domains.Ordenes;
using Invetory.Core.UseCase.Interfaces;
using Invetory.Core.Domains.Productos;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenUseCase useCase;

        public OrdenesController(IOrdenUseCase ordenUseCase)
        {
            useCase = ordenUseCase ?? throw new ArgumentNullException(nameof(ordenUseCase));
        }


        [HttpGet]
        [ApiVersion("1.0")]
        [Route("~/api/v{version:ApiVersion}/ObtenerOrdenes")]
        public async Task<List<OrdenesResponse>> GetOrders()
        {
            var item = await useCase.GetOrders();
            return item;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        [Route("~/api/v{version:ApiVersion}/ObtenerOrden")]
        public async Task<OrdenesResponse> GetOrder([FromBody] int id)
        {
            var item = await useCase.GetOrder(id);
            return item;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("~/api/v{version:ApiVersion}/CrearOrden")]
        public OrdenesResponse MakeOrder([FromBody] RegistrarOrden orden)
        {
            var item = useCase.MakeOrder(orden);
            return item;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        [Route("~/api/v{version:ApiVersion}/AnularOrden")]
        public OrdenesResponse ManageOrders([FromBody] int idOrder)
        {
            var item = useCase.ManageOrder(idOrder);
            return item;
        }
    }
}
