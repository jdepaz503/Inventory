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

    }
}
