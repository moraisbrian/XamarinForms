using App07_Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App07_Cell.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            List<Funcionario> lista = new List<Funcionario>();

            lista.Add(new Funcionario() { Nome = "Anderson", Cargo = "Presidente" });
            lista.Add(new Funcionario() { Nome = "Maria", Cargo = "Analista" });
            lista.Add(new Funcionario() { Nome = "João", Cargo = "Funileiro" });
            lista.Add(new Funcionario() { Nome = "Ana", Cargo = "Secretária" });
            lista.Add(new Funcionario() { Nome = "Claudio", Cargo = "Programador" });

            ListaFuncionario.ItemsSource = lista;
        }

        private void ItemSelecionadoAction(object sender, SelectedItemChangedEventArgs args)
        {
            Funcionario func = (Funcionario)args.SelectedItem;

            Navigation.PushAsync(new Detalhe.DetailPage(func));
        }

        private void FeriasAction(object sender, EventArgs args)
        {
            Funcionario func = (Funcionario)((MenuItem)sender).CommandParameter;

            DisplayAlert(string.Format("Titulo: {0}", func.Nome),
                        string.Format("Mensagem: {0} - {1}", func.Nome, func.Cargo),
                        "Ok");
        }

        private void AbonoAction(object sender, EventArgs args)
        {

        }
    }
}