﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace App09.Modelo
{
    public class Pessoa
    {
        [Required(ErrorMessage = "Nome obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "Msg_E01", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Msg_E01", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        public string Cpf { get; set; }
    }
}
