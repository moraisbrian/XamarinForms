using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App07_Cell.Modelo;

namespace App07_Cell.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageCellPage : ContentPage
    {
        public ImageCellPage()
        {
            InitializeComponent();

            List<Funcionario> lista = new List<Funcionario>();

            lista.Add(new Funcionario() { Nome = "Anderson", Cargo = "Presidente", Foto = "perfil.png" });
            lista.Add(new Funcionario() { Nome = "Maria", Cargo = "Analista", Foto = "perfil.png" });
            lista.Add(new Funcionario() { Nome = "João", Cargo = "Funileiro", Foto = "perfil.png" });
            lista.Add(new Funcionario() { Nome = "Ana", Cargo = "Secretária", Foto = "perfil.png" });
            lista.Add(new Funcionario() { Nome = "Claudio", Cargo = "Programador", Foto = "perfil.png" });

            ListaFuncionario.ItemsSource = lista;
        }
    }
}