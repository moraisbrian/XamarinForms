using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using App12_NossoChat.Model;
using App12_NossoChat.Service;
using Newtonsoft.Json;
using App12_NossoChat.Util;

namespace App12_NossoChat.ViewModel
{
    public class PaginaInicialViewModel : INotifyPropertyChanged
    {
        private string _nome;
        private string _senha;
        private string _mensagem;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; OnPropertyChanged("Nome"); }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; OnPropertyChanged("Senha"); }
        }

        public string Mensagem
        {
            get { return _mensagem; }
            set { _mensagem = value; OnPropertyChanged("Mensagem"); }
        }

        public Command AcessarCommand { get; set; }

        public PaginaInicialViewModel()
        {
            AcessarCommand = new Command(AcessarAction);
        }

        private void AcessarAction()
        {
            Usuario usuario = new Usuario();
            usuario.nome = Nome;
            usuario.password = Senha;

            var usuarioLogado = ServiceWS.GetUsuario(usuario);
            if (usuarioLogado == null)
            {
                Mensagem = "Senha incorreta!";
            }
            else
            {
                UsuarioUtil.SetUsuarioLogado(usuarioLogado);
                App.Current.MainPage = new NavigationPage(new View.Chats()) { BarBackgroundColor = Color.FromHex("#5ED055"), BarTextColor = Color.White };
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
