using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrenCR.Models
{
    public partial class EstacionRuta
    {
        public EstacionRuta()
        {
            Horario = new HashSet<Horario>();
        }

        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DisplayName("Ruta")]
        public int IdRuta { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DisplayName("Estacion")]
        public int IdEstacion { get; set; }
        public bool? Estado { get; set; }


        [System.ComponentModel.DisplayName("Estacion")]
        public virtual Estacion IdEstacionNavigation { get; set; }

        [System.ComponentModel.DisplayName("Estacion")]
        public virtual Ruta IdRutaNavigation { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
