using System;
using System.Collections.Generic;


namespace TrenCR.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Boleto = new HashSet<Boleto>();
        }

        public int Id { get; set; }


        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DisplayName("Perfil")]
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Estado { get; set; }

        [System.ComponentModel.DisplayName("Perfil")]
        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual ICollection<Boleto> Boleto { get; set; }
    }
}
