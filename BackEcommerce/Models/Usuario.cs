using System;
using System.Collections.Generic;

namespace BackEcommerce.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; } 
        public string? Apellidos { get; set; } 
        public int? IdPerfil { get; set; }
        public string? Usuario1 { get; set; } 
        public string? Contrasenia { get; set; }
        public string? Estatus { get; set; } = null!;
        public DateTime FechaCreate { get; set; }
        public DateTime? FechaDelete { get; set; }

        public virtual Perfil? IdPerfilNavigation { get; set; } = null!;
    }
}
