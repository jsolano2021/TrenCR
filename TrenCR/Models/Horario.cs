using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TrenCR.Models
{
    public partial class Horario
    {
        public Horario()
        {
            Boleto = new HashSet<Boleto>();
        }

        public int Id { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DisplayName("Estacion en Ruta")]
        public int IdEstacionRuta { get; set; }
        public TimeSpan Hora { get; set; }
        public bool? Estado { get; set; }

        [System.ComponentModel.DisplayName("Estacion en Ruta")]
        public virtual EstacionRuta IdEstacionRutaNavigation { get; set; }
        public virtual ICollection<Boleto> Boleto { get; set; }


        [NotMapped]
        public int Asiento { get; set; }
    }
}
