using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App10_Vagas.Banco;
using Xamarin.Forms;
using App10_Vagas.UWP.Banco;
using System.IO;
using Windows.Storage;

[assembly:Dependency(typeof(Caminho))]
namespace App10_Vagas.UWP.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string nomeArquivoBanco)
        {
            string caminhoPasta = ApplicationData.Current.LocalFolder.Path;
            string caminhoBanco = Path.Combine(caminhoPasta, nomeArquivoBanco);
            return caminhoBanco;
        }
    }
}
