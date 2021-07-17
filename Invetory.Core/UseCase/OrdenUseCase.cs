using Invetory.Core.Domains.Ordenes;
using Invetory.Core.Interfaces;
using Invetory.Core.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invetory.Core.UseCase
{
    public class OrdenUseCase : IOrdenUseCase
    {
        private readonly IOrdenesRepository repository;

        public OrdenUseCase(IOrdenesRepository ordenesRepository)
        {
            repository = ordenesRepository ?? throw new ArgumentNullException(nameof(ordenesRepository));
        }

        public async Task<List<OrdenesResponse>> GetOrders()=> await repository.GetOrders();

    }
}
