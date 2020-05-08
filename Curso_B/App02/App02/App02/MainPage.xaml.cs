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
                new Grupo("Presidente", "CEO", "Presidente da empresa")
                {
                    new Pessoa() { Nome = "José", Obrigatorio = true, Eficiencia = 8 }
                },
                new Grupo("Diretores", "Dir.", "Diretor da empresa")
                {
                    new Pessoa() { Nome = "Marcos", Obrigatorio = true, Eficiencia = 8 },
                    new Pessoa() { Nome = "Maria", Obrigatorio = false }
                },
                new Grupo("Gerentes", "Ger.", "Gerente da empresa")
                {
                    new Pessoa() { Nome = "Antonio", Obrigatorio = false },
                    new Pessoa() { Nome = "Ana", Obrigatorio = true, Eficiencia = 9 }
                },
                new Grupo("Funcionarios", "Func.", "Funcionario da empresa")
                {
                    new Pessoa() { Nome = "Antonio", Obrigatorio = false },
                    new Pessoa() { Nome = "Ana", Obrigatorio = false },
                    new Pessoa() { Nome = "Anderson", Obrigatorio = false },
                    new Pessoa() { Nome = "Marcos", Obrigatorio = false },
                    new Pessoa() { Nome = "Maria", Obrigatorio = true, Eficiencia = 6 },
                    new Pessoa() { Nome = "José", Obrigatorio = false },
                    new Pessoa() { Nome = "Debora", Obrigatorio = false },
                    new Pessoa() { Nome = "Marcio", Obrigatorio = false },
                    new Pessoa() { Nome = "Jessica", Obrigatorio = false },
                    new Pessoa() { Nome = "Roseli", Obrigatorio = false },
                    new Pessoa() { Nome = "Fernando", Obrigatorio = false },
                    new Pessoa() { Nome = "Viviane", Obrigatorio = false }
                }
            };
        }

        public class Grupo : List<Pessoa>
        {
            public string Titulo { get; set; }
            public string TituloCurto { get; set; }
            public string Descricao { get; set; }

            public Grupo(string titulo, string tituloCurto, string descricao)
            {
                this.Titulo = titulo;
                this.TituloCurto = tituloCurto;
                this.Descricao = descricao;
            }
        }

        public class Pessoa
        {
            public string Nome { get; set; }
            public int Eficiencia { get; set; }
            public bool Obrigatorio { get; set; }
        }
    }
}
