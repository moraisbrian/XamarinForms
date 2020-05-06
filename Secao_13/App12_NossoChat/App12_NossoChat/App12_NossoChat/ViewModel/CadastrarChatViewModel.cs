using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using App12_NossoChat.Model;
using App12_NossoChat.Service;

namespace App12_NossoChat.ViewModel
{
    public class CadastrarChatViewModel : INotifyPropertyChanged
    {
        private string _mensagem;

        public string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; OnPropertyChanged("Mensagem"); }
        }

        public Command CadastrarCommand { get; set; }
        public string Nome { get; set; }

        public CadastrarChatViewModel()
        {
            CadastrarCommand = new Command(CadastrarAction);
        }

        private void CadastrarAction()
        {
            bool ok = ServiceWS.InsertChat(new Chat { nome = Nome });
            
            if (ok)
            {
                ((NavigationPage)App.Current.MainPage).Navigation.PopAsync();

                var nav = (NavigationPage)App.Current.MainPage;
                var chats = (View.Chats)nav.RootPage;
                var viewModel = (ChatsViewModel)chats.BindingContext;
                
                if (viewModel.AtualizarCommand.CanExecute(null))
                {
                    viewModel.AtualizarCommand.Execute(null);
                }
            }
            else
            {
                Mensagem = "Ocorreu um erro no cadastro!";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
