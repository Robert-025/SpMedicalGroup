using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Domains
{
    public partial class medico
    {
        public medico()
        {
            consulta = new HashSet<consulta>();
        }

        //[Required(ErrorMessage = "O ID do usuario é obrigatório")]
        public int? idUsuario { get; set; }
        public int idMedico { get; set; }

        [Required(ErrorMessage = "O CRM do médico é obrigatório")]
        public string crm { get; set; }

        //[Required(ErrorMessage = "O ID da especialidade é obrigatório")]
        public int? idEspecialidade { get; set; }

        //[Required(ErrorMessage = "O ID da clínica é obrigatório")]
        public int? idClinica { get; set; }

        public virtual clinica idClinicaNavigation { get; set; }
        public virtual especialidade idEspecialidadeNavigation { get; set; }
        public virtual usuario idUsuarioNavigation { get; set; }
        public virtual ICollection<consulta> consulta { get; set; }
    }
}
