using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Invetory.Core.Domains.Ordenes
{
    public class RegistrarOrden
    {
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "Por favor especifique solo números.")]
        public int Sku { get; set; }
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "Por favor especifique solo números.")]
        public int Cantidad { get; set; }
        [Required]
        [StringLength(45, MinimumLength = 5)]
        public string Estatus { get; set; }
    }
}
