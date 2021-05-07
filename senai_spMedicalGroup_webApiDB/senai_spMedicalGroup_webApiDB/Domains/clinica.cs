using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Domains
{
    public partial class clinica
    {
        public clinica()
        {
            medicos = new HashSet<medico>();
        }

        public int idClinica { get; set; }
        public string razaoSocial { get; set; }

        [Required(ErrorMessage = "O nome da clínica é obrigatório")]
        public string nomeClinica { get; set; }

        [Required(ErrorMessage = "O endereço da clínica é obrigatório")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "O CNPJ da clínica é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve conter 14 dígitos")]
        public string cnpj { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? horarioAbertura { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? horarioFechamento { get; set; }

        public virtual ICollection<medico> medicos { get; set; }
    }
}
