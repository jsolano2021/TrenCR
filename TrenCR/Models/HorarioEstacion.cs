using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrenCR.Models
{
    public class HorarioEstacion
    {
        public int idEstacionRuta {get; set;}
        public int idRuta {get; set;}
        public string EstacionRuta { get; set; }
        public TimeSpan Hora { get; set; }
        public Horario horario { get; set; }
    }
}
