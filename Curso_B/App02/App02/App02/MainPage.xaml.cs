using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App02
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ListaFuncionarios.ItemsSource = GetFuncionarios();
        }

        private List<Grupo> GetFuncionarios()
        {
            return new List<Grupo>()
            {
                new Grupo("Presidente", "CEO")
                {
                    new Pessoa() { Nome = "José" }
                },
                new Grupo("Diretores", "Dir.")
                {
                    new Pessoa() { Nome = "Marcos" },
                    new Pessoa() { Nome = "Maria" }
                },
                new Grupo("Gerentes", "Ger.")
                {
                    new Pessoa() { Nome = "Antonio" },
                    new Pessoa() { Nome = "Ana" },
                    new Pessoa() { Nome = "Anderson" }
                }
            };
        }

        public class Grupo : List<Pessoa>
        {
            public string Titulo { get; set; }
            public string TituloCurto { get; set; }

            public Grupo(string titulo, string tituloCurto)
            {
                this.Titulo = titulo;
                this.TituloCurto = tituloCurto;
            }
        }

        public class Pessoa
        {
            public string Nome { get; set; }
        }
    }
}
