using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;

namespace App11_Mimica.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        private byte _palavraPontuacao;
        private string _palavra;
        private string _textoContagem;
        private bool _isVisibleContainerContagem;
        private bool _isVisibleContainerIniciar;
        private bool _isVisibleBtnMostrar;

        public byte PalavraPontuacao 
        { 
            get { return _palavraPontuacao; }
            set { _palavraPontuacao = value; OnPropertyChanged("PalavraPontuacao"); } 
        }
        public string Palavra 
        {
            get { return _palavra; } 
            set { _palavra = value; OnPropertyChanged("Palavra"); } 
        }
        public string TextoContagem 
        { 
            get { return _textoContagem; }
            set { _textoContagem = value; OnPropertyChanged("TextoContagem"); }
        }
        public bool IsVisibleContainerContagem 
        { 
            get { return _isVisibleContainerContagem; }
            set { _isVisibleContainerContagem = value; OnPropertyChanged("IsVisibleContainerContagem"); }
        }
        public bool IsVisibleContainerIniciar 
        { 
            get { return _isVisibleContainerIniciar; }
            set { _isVisibleContainerIniciar = value; OnPropertyChanged("IsVisibleContainerIniciar"); }
        }
        public bool IsVisibleBtnMostrar 
        { 
            get { return _isVisibleBtnMostrar; }
            set { _isVisibleBtnMostrar = value; OnPropertyChanged("IsVisibleBtnMostrar"); }
        }

        public Command MostarPalavra { get; set; }
        public Command Acertou { get; set; }
        public Command Errou { get; set; }
        public Command Iniciar { get; set; }

        public JogoViewModel()
        {
            IsVisibleContainerContagem = false;
            IsVisibleContainerIniciar = false;
            IsVisibleBtnMostrar = true;
            Palavra = "***********";
            PalavraPontuacao = 3;

            MostarPalavra = new Command(MostrarPalavraAction);
            //Acertou = new Command();
            //Errou = new Command();
            //Iniciar = new Command();
        }

        private void MostrarPalavraAction()
        {
            Palavra = "Sentar";
            IsVisibleBtnMostrar = false;
            IsVisibleContainerIniciar = true;
            // PropertyChanged(this, new PropertyChangedEventArgs("Palavra"));
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
