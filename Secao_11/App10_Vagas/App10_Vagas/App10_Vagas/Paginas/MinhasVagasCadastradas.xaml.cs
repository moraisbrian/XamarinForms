using App10_Vagas.Banco;
using App10_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace App10_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinhasVagasCadastradas : ContentPage
    {
        public List<Vaga> Lista { get; set; }
        public MinhasVagasCadastradas()
        {
            InitializeComponent();

            ConsultarVagas();
        }

        private void ConsultarVagas()
        {
            Database database = new Database();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;

            lblCount.Text = string.Format("{0} vagas disponíveis", Lista.Count.ToString());
        }

        private void EditarAction(object sender, EventArgs args)
        {
            Vaga vaga = (Vaga)((TapGestureRecognizer)((Label)sender).GestureRecognizers[0]).CommandParameter;
            Navigation.PushAsync(new EditarVaga(vaga));
        }

        private void ExcluirAction(object sender, EventArgs args)
        {
            Vaga vaga = (Vaga)((TapGestureRecognizer)((Label)sender).GestureRecognizers[0]).CommandParameter;

            Database database = new Database();
            database.Deletar(vaga);

            ConsultarVagas();
        }

        private void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaVagas.ItemsSource = Lista
                .Where(x => x.NomeVaga
                .ToLower()
                .Contains(args.NewTextValue
                .ToLower()))
                .ToList();
        }
    }
}