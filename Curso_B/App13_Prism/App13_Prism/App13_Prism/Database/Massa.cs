using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App13_Prism.Models;
using Realms;

namespace App13_Prism.Database
{
    public class Massa
    {
        public static void CriarMassaDados()
        {
            var realm = Realm.GetInstance();

            if (realm.All<Profissional>().Count() == 0)
            {
                realm.Write(() =>
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Profissional profissional = new Profissional()
                        {
                            Nome = string.Format("Prof{0}", i),
                            Descricao = string.Format("Descri{0}", i),
                            Especialidade = string.Format("Especialidade{0}", i),
                            Img = "https://static.vecteezy.com/system/resources/previews/000/550/980/non_2x/user-icon-vector.jpg"
                        };

                        realm.Add<Profissional>(profissional);

                        for (int j = 0; j < 3; j++)
                        {
                            Comentario comentario = new Comentario()
                            {
                                Profissional = profissional,
                                Autor = string.Format("Autor {0} {1}", i, j),
                                Data = DateTimeOffset.Now,
                                Descricao = string.Format("Descricao {0} {1}", i, j)
                            };

                            realm.Add<Comentario>(comentario);
                        }
                    }
                });
            }
        }
    }
}
