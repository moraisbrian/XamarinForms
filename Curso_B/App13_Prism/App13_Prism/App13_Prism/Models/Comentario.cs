using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace App13_Prism.Models
{
    public class Comentario : RealmObject
    {
        public Profissional Profissional { get; set; }
        public string Autor { get; set; }
        public DateTimeOffset Data { get; set; }
        public string Descricao { get; set; }
    }
}
