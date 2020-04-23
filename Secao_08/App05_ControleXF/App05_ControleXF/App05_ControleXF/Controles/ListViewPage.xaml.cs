using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App05_ControleXF.Modelo;

namespace App05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa { Nome = "Marcos", Idade = "25" });
            lista.Add(new Pessoa { Nome = "Fulano", Idade = "26" });
            lista.Add(new Pessoa { Nome = "Maria", Idade = "19" });
            lista.Add(new Pessoa { Nome = "Anderson", Idade = "30" });

            ListaPessoas.ItemsSource = lista;
        }
    }
}