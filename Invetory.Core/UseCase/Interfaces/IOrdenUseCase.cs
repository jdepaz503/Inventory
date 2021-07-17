using Invetory.Core.Domains.Ordenes;
using Invetory.Core.Domains.Productos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invetory.Core.UseCase.Interfaces
{
    public interface IOrdenUseCase
    {
        Task<List<OrdenesResponse>> GetOrders();
        Task<OrdenesResponse> GetOrder(int id);
        OrdenesResponse MakeOrder(RegistrarOrden orden);
    }
}
