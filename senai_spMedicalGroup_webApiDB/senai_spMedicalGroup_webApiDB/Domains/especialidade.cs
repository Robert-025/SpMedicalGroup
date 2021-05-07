using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Domains
{
    public partial class especialidade
    {
        public especialidade()
        {
            medicos = new HashSet<medico>();
        }

        public int idEspecialidade { get; set; }

        [Required(ErrorMessage = "O nome da especialidade é obrigatória")]
        public string nome { get; set; }

        public virtual ICollection<medico> medicos { get; set; }
    }
}
