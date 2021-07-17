using Invetory.Core.Domains.Ordenes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invetory.Core.Interfaces
{
    public interface IOrdenesRepository
    {
        Task<List<OrdenesResponse>> GetOrders();
    }
}
