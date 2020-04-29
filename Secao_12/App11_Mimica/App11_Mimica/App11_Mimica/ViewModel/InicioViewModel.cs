using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using App11_Mimica.Model;
using Xamarin.Forms;
using App11_Mimica.Armazenamento;

namespace App11_Mimica.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public Command IniciarCommand { get; set; }
        public Jogo Jogo { get; set; }

        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
        }

        private void IniciarJogo()
        {
            DataAccess.Jogo = this.Jogo;
            DataAccess.RodadaAtual = 1;
            App.Current.MainPage = new View.Jogo();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameProperty));
            }
        }
    }
}
