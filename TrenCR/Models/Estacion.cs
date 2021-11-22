using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrenCR.Models
{
    public partial class Estacion
    {
        public Estacion()
        {
            EstacionRuta = new HashSet<EstacionRuta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool? Estado { get; set; } 
        public virtual ICollection<EstacionRuta> EstacionRuta { get; set; }
    }
}
