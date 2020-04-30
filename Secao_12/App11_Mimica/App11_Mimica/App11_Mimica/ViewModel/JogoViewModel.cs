using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using App11_Mimica.Armazenamento;
using App11_Mimica.Model;

namespace App11_Mimica.ViewModel
{
    public class JogoViewModel : INotifyPropertyChanged
    {
        public Grupo Grupo { get; set; }
        public string NomeGrupo { get; set; }
        public string NumeroGrupo { get; set; }

        private byte _palavraPontuacao;
        private string _palavra;
        private string _textoContagem;
        private bool _isVisibleContainerContagem;
        private bool _isVisibleBtnIniciar;
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
        public bool IsVisibleBtnIniciar
        {
            get { return _isVisibleBtnIniciar; }
            set { _isVisibleBtnIniciar = value; OnPropertyChanged("IsVisibleBtnIniciar"); }
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

        public JogoViewModel(Grupo grupo)
        {
            Grupo = grupo;
            NomeGrupo = grupo.Nome;
            if (grupo == DataAccess.Jogo.Grupo1)
                NumeroGrupo = "Grupo 1 ";
            else
                NumeroGrupo = "Grupo 2 ";

            IsVisibleContainerContagem = false;
            IsVisibleBtnIniciar = false;
            IsVisibleBtnMostrar = true;
            Palavra = "***********";
            PalavraPontuacao = 3;

            MostarPalavra = new Command(MostrarPalavraAction);
            Acertou = new Command(AcertouAction);
            Errou = new Command(ErrouAction);
            Iniciar = new Command(IniciarAction);
        }

        private void AcertouAction()
        {
            Grupo.Pontuacao += PalavraPontuacao;

            GoProximoGrupo();
        }

        private void ErrouAction()
        {
            GoProximoGrupo();
        }

        private void GoProximoGrupo()
        {
            Grupo grupo;
            if (DataAccess.Jogo.Grupo1 == Grupo)
            {
                grupo = DataAccess.Jogo.Grupo2;
            }
            else
            {
                grupo = DataAccess.Jogo.Grupo1;
                DataAccess.RodadaAtual++;
            }

            if (DataAccess.RodadaAtual > DataAccess.Jogo.Rodadas)
            {
                App.Current.MainPage = new View.Resultado();
            }
            else
            {
                App.Current.MainPage = new View.Jogo(grupo);
            }
        }

        private void IniciarAction()
        {
            IsVisibleBtnIniciar = false;
            IsVisibleContainerContagem = true;

            int i = DataAccess.Jogo.TempoPalavra;
            TextoContagem = i.ToString();
            i--;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TextoContagem = i.ToString();
                i--;
                if (i < 0)
                {
                    TextoContagem = "Esgotou o tempo";
                }
                return true;
            });
        }

        private void MostrarPalavraAction()
        {
            int numNivel = DataAccess.Jogo.NivelNumerico;
            if (numNivel == 0)
            {
                Random rd = new Random();
                int nivel = rd.Next(0, 3);
                int index = rd.Next(0, DataAccess.Palavras[nivel].Length);
                Palavra = DataAccess.Palavras[nivel][index];
                PalavraPontuacao = (byte)(nivel == 0 ? 1 : nivel == 1 ? 3 : 5);
            }
            else if (numNivel == 1)
            {
                Random rd = new Random();
                int index = rd.Next(0, DataAccess.Palavras[numNivel - 1].Length);
                Palavra = DataAccess.Palavras[numNivel - 1][index];
                PalavraPontuacao = 1;
            }
            else if (numNivel == 2)
            {
                Random rd = new Random();
                int index = rd.Next(0, DataAccess.Palavras[numNivel - 1].Length);
                Palavra = DataAccess.Palavras[numNivel - 1][index];
                PalavraPontuacao = 3;
            }
            else if (numNivel == 3)
            {
                Random rd = new Random();
                int index = rd.Next(0, DataAccess.Palavras[numNivel - 1].Length);
                Palavra = DataAccess.Palavras[numNivel - 1][index];
                PalavraPontuacao = 5;
            }

            IsVisibleBtnMostrar = false;
            IsVisibleBtnIniciar = true;
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
