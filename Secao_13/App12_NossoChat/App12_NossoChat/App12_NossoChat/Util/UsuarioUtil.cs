using System;
using System.Collections.Generic;
using System.Text;
using App12_NossoChat.Model;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace App12_NossoChat.Util
{
    public class UsuarioUtil
    {
        public static void SetUsuarioLogado(Usuario usuario)
        {
            App.Current.Properties["Login"] = JsonConvert.SerializeObject(usuario);
        }

        public static Usuario GetUsuarioLogado()
        {
            if (App.Current.Properties.ContainsKey("Login"))
            {
                return JsonConvert.DeserializeObject<Usuario>((string)App.Current.Properties["Login"]);
            }
            else
                return null;
        }
    }
}
