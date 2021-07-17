using AutoMapper;
using Inventory.Infraestructure.Models;
using Invetory.Core.Domains.Ordenes;
using Invetory.Core.Domains.Productos;
using Invetory.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
                IList<Orden> Orders = await db.Orden.ToListAsync();
                if (Orders != null && Orders.Count != 0)
                    response = map.Map<List<OrdenesResponse>>(Orders.ToList());
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.InnerException?.Message}");
                throw;
            }
        }

        public async Task<OrdenesResponse> GetOrder(int id)
        {
            OrdenesResponse response = new OrdenesResponse();
            if (id != 0)
            {
                try
                {
                    var order = await db.Orden.FindAsync(id);
                    response = map.Map<OrdenesResponse>(order);
                    return response;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} {ex.InnerException?.Message}");
                    throw;
                }
            }
            return response;

        }

        public OrdenesResponse MakeOrder(RegistrarOrden orden)
        {
            //ProductosResponse response = new ProductosResponse();
            OrdenesResponse OrderResponse = new OrdenesResponse();
            int noOrden = 0;

            if (orden.Cantidad !=0 && orden.Sku != 0 && orden.Estatus!=null)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = db.Database.GetDbConnection().ConnectionString;
                    MySqlCommand cmd = new MySqlCommand();
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "MAKEORDERS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SKU_IN", orden.Sku);
                    cmd.Parameters.AddWithValue("@CANTIDAD_IN", orden.Cantidad);
                    cmd.Parameters.AddWithValue("@STATUS_IN", orden.Estatus);
                    cmd.Parameters.Add("@IdOrden", MySqlDbType.Int32);
                    cmd.Parameters["@IdOrden"].Direction = ParameterDirection.Output;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderResponse.IdOrden= Int32.Parse(reader["IdOrden"].ToString());
                            OrderResponse.Sku= Int32.Parse(reader["SKU"].ToString());
                            OrderResponse.Cantidad= Int32.Parse(reader["Cantidad"].ToString());
                            OrderResponse.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"].ToString());
                            OrderResponse.Estado = reader["Estado"].ToString();
                            noOrden = Int32.Parse(reader["IdOrden"].ToString());
                        }
                    }
                    conn.Close();
                    return OrderResponse;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return OrderResponse;
            }

        }
    }
}
