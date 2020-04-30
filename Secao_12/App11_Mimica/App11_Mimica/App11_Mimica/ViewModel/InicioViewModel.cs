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

        private string _msgErro;
        public string MsgErro 
        { 
            get { return _msgErro; }
            set { _msgErro = value; OnPropertyChanged("MsgErro"); }
        }


        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo();
            Jogo.Grupo1 = new Grupo();
            Jogo.Grupo2 = new Grupo();

            Jogo.TempoPalavra = 120;
            Jogo.Rodadas = 7;
        }

        private void IniciarJogo()
        {
            string erro = "";
            if (Jogo.TempoPalavra < 10)
                erro += "O tempo mínimo para o tempo da palavra é 10 segundos.\n";
            if (Jogo.Rodadas <= 0)
                erro += "O valor mínimo para a rodada é 1.";

            if (erro == "")
            {
                DataAccess.Jogo = this.Jogo;
                DataAccess.RodadaAtual = 1;
                App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
            }
            else
            {
                MsgErro = erro;
            }
            
            
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
