using System;
using System.Collections.Generic;


namespace TrenCR.Models
{
    public partial class Boleto
    {
        public int Id { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DisplayName("Horario")]
        public int IdHorario { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DisplayName("Usuario")]
        public int IdUsuario { get; set; }
        public int Asiento { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public bool? Estado { get; set; }

        [System.ComponentModel.DisplayName("Horario")]
        public virtual Horario IdHorarioNavigation { get; set; }

        [System.ComponentModel.DisplayName("Usuario")]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
