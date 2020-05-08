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
    public partial class CadastrarVaga : ContentPage
    {
        public CadastrarVaga()
        {
            InitializeComponent();

        }

        private void SalvarAction(object sender, EventArgs args)
        {
            Vaga vaga = new Vaga();
            vaga.NomeVaga = NomeVaga.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;
            vaga.Cidade = Cidade.Text;
            vaga.Descricao = Descricao.Text;
            vaga.Empresa = Empresa.Text;
            vaga.TipoContratacao = TipoCotratacao.IsToggled ? "PJ" : "CLT";

            Database database = new Database();
            database.Cadastro(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultarVagas());
        }
    }
}