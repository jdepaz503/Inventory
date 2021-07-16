using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Invetory.Core.Domains.Productos
{
    public class ProductosResponse
    {
        public int Sku { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        
    }
}
