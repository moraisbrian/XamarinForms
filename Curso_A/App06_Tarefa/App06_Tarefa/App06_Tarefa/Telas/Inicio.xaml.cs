using App06_Tarefa.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App06_Tarefa.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();

            DataHoje.Text = DateTime.Now.ToString("dddd, dd/MM", CultureInfo.CreateSpecificCulture("pt-BR"));

            CarregarTarefas();
        }

        public void ActionGoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());       
        }

        private void CarregarTarefas()
        {
            SLTarefas.Children.Clear();

            List<Tarefa> lista = new GerenciadorTarefa().Listagem();

            int index = 0;
            foreach (var tarefa in lista)
            {
                LinhaStackLayout(tarefa, index);
                index++;
            }
        }

        public void LinhaStackLayout(Tarefa tarefa, int index)
        {
            Image delete = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = Device.RuntimePlatform == Device.UWP ?
                    ImageSource.FromFile("Resources/Delete.png") :
                    ImageSource.FromFile("Delete.png")
            };

            TapGestureRecognizer deleteTap = new TapGestureRecognizer();
            deleteTap.Tapped += delegate
            {
                new GerenciadorTarefa().Deletar(index);
                CarregarTarefas();
            };

            delete.GestureRecognizers.Add(deleteTap);

            Image prioridade = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = Device.RuntimePlatform == Device.UWP ?
                    ImageSource.FromFile("Resources/p" + tarefa.Prioridade + ".png") :
                    ImageSource.FromFile("p" + tarefa.Prioridade + ".png")
            };

            View stackCentral = null;
            if (tarefa.DataFinalizacao == null)
            {
                stackCentral = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Text = tarefa.Nome
                };
            }
            else
            {
                stackCentral = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 0,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                ((StackLayout)stackCentral).Children.Add(new Label()
                {
                    Text = tarefa.Nome,
                    TextColor = Color.Gray
                });

                ((StackLayout)stackCentral).Children.Add(new Label()
                {
                    Text = "Finalizado em " + tarefa.DataFinalizacao.Value.ToString("dd/MM/yyyy - hh:mm") + "h",
                    TextColor = Color.Gray,
                    FontSize = 10
                });
            }
            

            Image check = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = Device.RuntimePlatform == Device.UWP ? 
                    ImageSource.FromFile("Resources/CheckOff.png") : 
                    ImageSource.FromFile("CheckOff.png")
            };

            if (tarefa.DataFinalizacao != null)
            {
                check.Source = Device.RuntimePlatform == Device.UWP ?
                    ImageSource.FromFile("Resources/CheckOn.png") :
                    ImageSource.FromFile("CheckOn.png");
            }

            TapGestureRecognizer checkTap = new TapGestureRecognizer();
            checkTap.Tapped += delegate
            {
                new GerenciadorTarefa().Finalizar(tarefa, index);
                CarregarTarefas();
            };

            check.GestureRecognizers.Add(checkTap);

            StackLayout linha = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 15
            };

            linha.Children.Add(check);
            linha.Children.Add(stackCentral);
            linha.Children.Add(prioridade);
            linha.Children.Add(delete);

            SLTarefas.Children.Add(linha);
        }
    }
}