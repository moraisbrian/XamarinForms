using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace App09_DataAnnotations.Modelo
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Nome obrigatório", AllowEmptyStrings = false)]
        [StringLength(60, MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "Msg_E01", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        [EmailAddress(ErrorMessageResourceName = "Msg_E02", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Msg_E01", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        [CPF(ErrorMessageResourceName = "Msg_E02", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        public string CPF { get; set; }
    }
}
