using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Invetory.Core.Domains.Productos
{
    public class UpdateProducto
    {
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "Por favor especifique solo números.")]
        public int Sku { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Descripcion { get; set; }
       
    }
}
