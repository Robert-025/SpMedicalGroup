using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Domains
{
    public partial class tiposUsuario
    {
        public tiposUsuario()
        {
            usuarios = new HashSet<usuario>();
        }

        public int idTipo { get; set; }

        [Required(ErrorMessage = "O título do tipo do usuario é obrigatório")]
        public string tituloTipo { get; set; }

        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
