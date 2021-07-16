using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Inventory.Infraestructure.Models;
using Invetory.Core.Domains.Productos;

namespace Inventory.Infraestructure.Mapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Producto,ProductosResponse>();
        }
        
    }
}
