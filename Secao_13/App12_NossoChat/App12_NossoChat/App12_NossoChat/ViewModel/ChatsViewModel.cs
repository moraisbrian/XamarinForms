using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using App12_NossoChat.Model;
using App12_NossoChat.Service;
using System.Linq;

namespace App12_NossoChat.ViewModel
{
    public class ChatsViewModel : INotifyPropertyChanged
    {
        private List<Chat> _chats;
        private Chat _selectedItemChat;

        public Chat SelectedItemChat 
        { 
            get { return _selectedItemChat; }
            set 
            { 
                _selectedItemChat = value; 
                OnPropertyChanged("SelectedItemChat");
                GoPaginaMensagem(value);
            }
        }

        private void GoPaginaMensagem(Chat chat)
        {
            if (chat != null)
            {
                SelectedItemChat = null;
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));
            }
        }

        public List<Chat> Chats
        {
            get { return _chats; }
            set { _chats = value; OnPropertyChanged("Chats"); }
        }

        public Command AdicionarCommand { get; set; }
        public Command OrdenarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public ChatsViewModel()
        {
            Chats = ServiceWS.GetChats();

            AdicionarCommand = new Command(AdicionarAction);
            OrdenarCommand = new Command(OrdenarAction);
            AtualizarCommand = new Command(AtualizarAction);
        }

        private void AdicionarAction()
        {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }
        
        private void OrdenarAction()
        {
            Chats = Chats.OrderBy(x => x.nome).ToList();
        }

        private void AtualizarAction()
        {
            Chats = ServiceWS.GetChats();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
