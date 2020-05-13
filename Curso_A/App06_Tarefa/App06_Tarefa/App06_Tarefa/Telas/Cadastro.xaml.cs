using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App06_Tarefa.Modelos;

namespace App06_Tarefa.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private byte Prioridade { get; set; }

        public void PrioridadeSelectAction(object sender, EventArgs args)
        {
            var stacks = SLPrioridades.Children;

            foreach (var linha in stacks)
            {
                Label lblPrioridade = ((StackLayout)linha).Children[1] as Label;
                lblPrioridade.TextColor = Color.Gray;
            }

            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource source = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;

            string prioridade = source.File.ToString().Replace("Resources/", "").Replace(".png", "").Substring(1);
            Prioridade = byte.Parse(prioridade);
        }

        public void SalvarAction(object sender, EventArgs args)
        {
            bool hasError = false;
            if (TxtNome.Text == null || TxtNome.Text.Trim().Length <= 0)
            {
                hasError = true;
                DisplayAlert("Erro", "Tarefa não digitada", "Ok");
            }
            
            if (Prioridade <= 0)
            {
                hasError = true;
                DisplayAlert("Erro", "Prioridade não selecionada", "Ok");
            }

            if (!hasError)
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = TxtNome.Text.Trim();
                tarefa.Prioridade = Prioridade;

                new GerenciadorTarefa().Salvar(tarefa);
                App.Current.MainPage = new NavigationPage(new Inicio());
            }
        }
    }
}