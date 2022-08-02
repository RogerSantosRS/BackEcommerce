using System;
using System.Collections.Generic;

namespace BackEcommerce.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string Estatus { get; set; } = null!;
        public string Imagen { get; set; } = null!;
        public DateTime FechaCreate { get; set; }
        public DateTime? FechaDelete { get; set; }
    }
}
