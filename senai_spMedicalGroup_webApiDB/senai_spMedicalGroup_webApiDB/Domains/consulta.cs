using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Domains
{
    public partial class consulta
    {
        public int idConsulta { get; set; }
        public int? idPaciente { get; set; }

        [Required(ErrorMessage = "O ID do médico precisa ser informado")]
        public int? idMedico { get; set; }

        [Required(ErrorMessage = "A data e a hora da consulta são obrigatórias")]
        public DateTime dataConsulta { get; set; }
        public int? idSituacao { get; set; }

        public virtual medico idMedicoNavigation { get; set; }
        public virtual paciente idPacienteNavigation { get; set; }
        public virtual situacao idSituacaoNavigation { get; set; }
    }
}
