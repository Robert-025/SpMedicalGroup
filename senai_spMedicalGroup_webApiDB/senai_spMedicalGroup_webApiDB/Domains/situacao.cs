using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spMedicalGroup_webApiDB.Domains
{
    public partial class situacao
    {
        public situacao()
        {
            consulta = new HashSet<consulta>();
        }

        public int idSituacao { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string descricao { get; set; }

        public virtual ICollection<consulta> consulta { get; set; }
    }
}
