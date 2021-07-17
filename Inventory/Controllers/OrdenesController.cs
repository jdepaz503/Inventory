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


        //[HttpGet]
        //[ApiVersion("1.0")]
        //[Route("~/api/v{version:ApiVersion}/ObtenerOrden")]
        //public async Task<ActionResult<Orden>> GetOrden(int id)
        //{
        //    var orden = await _context.Orden.FindAsync(id);

        //    if (orden == null)
        //    {
        //        return NotFound();
        //    }

        //    return orden;
        //}


        //[HttpPut]
        //[ApiVersion("1.0")]
        //[Route("~/api/v{version:ApiVersion}/AnularOrden")]
        //public async Task<IActionResult> ManageOrders(int id)
        //{
        //    if (id ==0)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(orden).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrdenExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //[HttpPost]
        //[ApiVersion("1.0")]
        //[Route("~/api/v{version:ApiVersion}/CrearOrden")]
        //public async Task<ActionResult<Orden>> MakeOrders(Orden orden)
        //{
        //    _context.Orden.Add(orden);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetOrden", new { id = orden.IdOrden }, orden);
        //}


        //private bool OrdenExists(int id)
        //{
        //    return _context.Orden.Any(e => e.IdOrden == id);
        //}
    }
}
