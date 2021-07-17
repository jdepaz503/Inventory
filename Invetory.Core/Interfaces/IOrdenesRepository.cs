using Invetory.Core.Domains.Ordenes;
using Invetory.Core.Domains.Productos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invetory.Core.Interfaces
{
    public interface IOrdenesRepository
    {
        Task<List<OrdenesResponse>> GetOrders();

        Task<OrdenesResponse> GetOrder(int id);

        OrdenesResponse MakeOrder(RegistrarOrden orden);
    }
}
