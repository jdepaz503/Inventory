using AutoMapper;
using Inventory.Infraestructure.Models;
using Invetory.Core.Domains.Ordenes;
using Invetory.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infraestructure.Repositories
{
    public class OrdenesRepository : IOrdenesRepository
    {
        private readonly inventorydbContext db;
        private readonly IMapper map;

        public OrdenesRepository(inventorydbContext _db, IMapper mapper)
        {
            db = _db ?? throw new ArgumentNullException(nameof(_db));
            map = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrdenesResponse>> GetOrders()
        {
            List<OrdenesResponse> response = new List<OrdenesResponse>();

            try
            {
                IList<Orden> Order = await db.Orden.ToListAsync();
                if (Order != null && Order.Count != 0)
                    response = map.Map<List<OrdenesResponse>>(Order.ToList());
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.InnerException?.Message}");
                throw;
            }
        }
    }
}
