using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using App10_Vagas.Banco;
using System.IO;
using App10_Vagas.Droid.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace App10_Vagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string nomeArquivoBanco)
        {
            string caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBanco = Path.Combine(caminhoPasta, nomeArquivoBanco);
            return caminhoBanco;
        }
    }
}