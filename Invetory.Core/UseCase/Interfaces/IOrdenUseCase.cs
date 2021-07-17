using Invetory.Core.Domains.Ordenes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invetory.Core.UseCase.Interfaces
{
    public interface IOrdenUseCase
    {
        Task<List<OrdenesResponse>> GetOrders();
    }
}
