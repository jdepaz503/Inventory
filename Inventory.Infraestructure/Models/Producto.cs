using System;
using System.Collections.Generic;

namespace Inventory.Infraestructure.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Orden = new HashSet<Orden>();
        }

        public int Sku { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<Orden> Orden { get; set; }
    }
}
