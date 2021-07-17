using System;
using System.Collections.Generic;

namespace Inventory.Infraestructure.Models
{
    public partial class Orden
    {
        public int IdOrden { get; set; }
        public int Sku { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; }

        public virtual Producto SkuNavigation { get; set; }
    }
}
