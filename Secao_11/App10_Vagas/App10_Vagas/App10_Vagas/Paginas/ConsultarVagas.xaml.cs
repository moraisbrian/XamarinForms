using App10_Vagas.Banco;
using App10_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App10_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarVagas : ContentPage
    {
        public List<Vaga> Lista { get; set; }
        public ConsultarVagas()
        {
            InitializeComponent();

            Database database = new Database();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;

            lblCount.Text = string.Format("{0} vagas disponíveis", Lista.Count.ToString());
        }

        private void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void GoMinhasVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        private void MaisDetalheAction(object sender, EventArgs args)
        {
            Vaga vaga = (Vaga)((TapGestureRecognizer)((Label)sender).GestureRecognizers[0]).CommandParameter;
            Navigation.PushAsync(new DetalharVaga(vaga));
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