using App13_Prism.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App13_Prism.Database
{
    public class ComentarioDB
    {
        public static List<Comentario> GetListComentario(Profissional p)
        {
            return new List<Comentario>(Realm.GetInstance()
                .All<Comentario>()
                .Where(x => x.Profissional == p));
        }
    }
}
