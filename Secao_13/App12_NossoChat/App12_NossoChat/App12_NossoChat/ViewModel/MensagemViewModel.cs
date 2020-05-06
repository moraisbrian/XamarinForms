using App12_NossoChat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App12_NossoChat.Service;
using Xamarin.Forms;
using App12_NossoChat.Util;

namespace App12_NossoChat.ViewModel
{
    public class MensagemViewModel : INotifyPropertyChanged
    {
        private StackLayout _stackLayout;
        private List<Mensagem> _mensagens;

        public List<Mensagem> Mensagens
        {
            get { return _mensagens; }
            set 
            { 
                _mensagens = value; 
                OnPropertyChanged("Mensagens");
                if (_mensagens != null)
                    ShowOnScreen();
            }
        }

        public MensagemViewModel(Chat chat, StackLayout SLMensagemContainer)
        {
            _stackLayout = SLMensagemContainer;
            Mensagens = ServiceWS.GetMensagensChat(chat);
        }

        private void ShowOnScreen()
        {
            var usuario = UsuarioUtil.GetUsuarioLogado();
            _stackLayout.Children.Clear();
            {
                foreach (var msg in Mensagens)
                {
                    if (msg.usuario.id == usuario.id)
                    {
                        _stackLayout.Children.Add(CriarMensagemPropria(msg));
                    }
                    else
                    {
                        _stackLayout.Children.Add(CriarMensagemOutrosUsuarios(msg));
                    }
                }
            }
        }

        private Xamarin.Forms.View CriarMensagemPropria(Mensagem mensagem)
        {
            var layout = new StackLayout() { Padding = 5, BackgroundColor = Color.FromHex("#5ED055"), HorizontalOptions = LayoutOptions.End };
            var label = new Label() { TextColor = Color.White, Text = mensagem.mensagem };

            layout.Children.Add(label);

            return layout;
        }

        private Xamarin.Forms.View CriarMensagemOutrosUsuarios(Mensagem mensagem)
        {
            var frame = new Frame() { BorderColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.Start };
            var sl = new StackLayout();
            var labelNome = new Label() { Text = mensagem.usuario.nome, FontSize = 10, TextColor = Color.FromHex("#5ED055") };
            var labelMsg = new Label() { Text = mensagem.mensagem, TextColor = Color.FromHex("#5ED055") };

            sl.Children.Add(labelNome);
            sl.Children.Add(labelMsg);
            frame.Content = sl;

            return frame;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
