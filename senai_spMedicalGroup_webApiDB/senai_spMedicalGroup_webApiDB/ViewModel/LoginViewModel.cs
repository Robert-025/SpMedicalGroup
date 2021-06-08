using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.ViewModel
{
    /// <summary>
    /// Responsável pelo modelo de login
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email do usuario")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuario")]
        public string senha { get; set; }
    }
}
