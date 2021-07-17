using System;
using System.Collections.Generic;
using System.Text;

namespace Invetory.Core.Domains.Ordenes
{
    public class OrdenesResponse
    {
        public int IdOrden { get; set; }
        public int Sku { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Status { get; set; }
    }
}
