using AutoMapper;
using Inventory.Infraestructure.Models;
using Invetory.Core.Domains.Productos;
using Invetory.Core.Interfaces;
using Invetory.Core.Models.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventory.Infraestructure.Repositories
{
    public class ProductosRepository: IProductosRepository
    {
        private readonly inventorydbContext db;
        private readonly IMapper map;

        public ProductosRepository(inventorydbContext _db, IMapper mapper)
        {
            db = _db ?? throw new ArgumentNullException(nameof(_db));
            map = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ProductosResponse>> GetProducts()
        {
            List<ProductosResponse> response = new List<ProductosResponse>();

            try
            {
                IList<Producto> product = await db.Producto.ToListAsync();
                if (product != null && product.Count != 0)
                    response = map.Map<List<ProductosResponse>>(product.ToList());
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.InnerException?.Message}");
                throw;
            }
        }


        public async Task<ProductosResponse> PutProducto(UpdateProducto producto)
        {
            ProductosResponse response = new ProductosResponse(); ;

            if (producto.Sku != 0)
            {
                    await db.Database.ExecuteSqlRawAsync("UPDATE PRODUCTO SET Descripcion='"+producto.Descripcion+"' WHERE Sku="+producto.Sku);

                try
                {
                    await db.SaveChangesAsync();
                    var productolist = await db.Producto.FindAsync(producto.Sku);
                    response = map.Map<ProductosResponse>(productolist);

                    return response;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return response;
        }
    }
}
