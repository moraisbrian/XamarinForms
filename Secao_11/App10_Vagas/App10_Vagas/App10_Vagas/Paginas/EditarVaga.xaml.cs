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
    public partial class EditarVaga : ContentPage
    {
        private Vaga Vaga { get; set; }
        public EditarVaga(Vaga vaga)
        {
            InitializeComponent();

            this.Vaga = vaga;

            NomeVaga.Text = vaga.NomeVaga;
            Empresa.Text = vaga.Empresa;
            Quantidade.Text = vaga.Quantidade.ToString();
            Cidade.Text = vaga.Cidade;
            Salario.Text = vaga.Salario.ToString();
            Descricao.Text = vaga.Descricao;
            TipoCotratacao.IsToggled = vaga.TipoContratacao == "PJ" ? true : false;
            Telefone.Text = vaga.Telefone;
            Email.Text = vaga.Email;
        }

        private void SalvarAction(object sender, EventArgs args)
        {
            Vaga.NomeVaga = NomeVaga.Text;
            Vaga.Quantidade = short.Parse(Quantidade.Text);
            Vaga.Salario = double.Parse(Salario.Text);
            Vaga.Telefone = Telefone.Text;
            Vaga.Email = Email.Text;
            Vaga.Cidade = Cidade.Text;
            Vaga.Descricao = Descricao.Text;
            Vaga.Empresa = Empresa.Text;
            Vaga.TipoContratacao = TipoCotratacao.IsToggled ? "PJ" : "CLT";

            Database database = new Database();
            database.Atualizar(Vaga);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
        }
    }
}