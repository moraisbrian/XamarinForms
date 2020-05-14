using System;
using System.Collections.Generic;
using System.Text;
using App13_Prism.Models;
using Realms;

namespace App13_Prism.Database
{
    public class ProfissionalDB
    {
        public static List<Profissional> GetListProfissional()
        {
            return new List<Profissional>(Realm.GetInstance().All<Profissional>());
        }
    }
}
