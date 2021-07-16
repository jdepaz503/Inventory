using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Invetory.Core.Domains.Productos
{
    public class RegistrarProductoResponse
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Descripcion { get; set; }
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "Por favor especifique solo números.")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Debe especificar como mínimo un dígito.")]
        public int Stock { get; set; }
    }
}
