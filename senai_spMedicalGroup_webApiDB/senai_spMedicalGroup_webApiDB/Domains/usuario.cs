using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Domains
{
    public partial class usuario
    {
        public usuario()
        {
            medicos = new HashSet<medico>();
            pacientes = new HashSet<paciente>();
        }

        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O ID do tipoUsuario é obrigatório")]
        public int? idTipo { get; set; }

        [Required(ErrorMessage = "O nome do usuario é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O email do usuario é obrigatório")]
        public string email { get; set; }

        [Required(ErrorMessage = "A data de nascimento do usuario é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string senha { get; set; }

        public virtual tiposUsuario idTipoNavigation { get; set; }
        public virtual ICollection<medico> medicos { get; set; }
        public virtual ICollection<paciente> pacientes { get; set; }
    }
}
