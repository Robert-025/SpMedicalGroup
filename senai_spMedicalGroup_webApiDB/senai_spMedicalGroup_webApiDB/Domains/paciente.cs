using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Domains
{
    public partial class paciente
    {
        public paciente()
        {
            consulta = new HashSet<consulta>();
        }

        public int idPaciente { get; set; }

        [Required(ErrorMessage = "O ID do usuario é obrigatório")]
        public int? idUsuario { get; set; }
        public long? telefone { get; set; }

        [Required(ErrorMessage = "O RG é obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O RG precisa ter 9 digitos")]
        public string rg { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O CPF precisa ter 11 digitos")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string endereco { get; set; }

        public virtual usuario idUsuarioNavigation { get; set; }
        public virtual ICollection<consulta> consulta { get; set; }
    }
}
