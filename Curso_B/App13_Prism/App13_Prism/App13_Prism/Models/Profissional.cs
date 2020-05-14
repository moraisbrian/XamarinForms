using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace App13_Prism.Models
{
    public class Profissional : RealmObject
    {
        [PrimaryKey]
        public string Nome { get; set; }
        public string Img { get; set; }
        public string Descricao { get; set; }
        public string Especialidade { get; set; }
        public IList<Comentario> Comentarios { get; }
    }
}
