using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App07_Cell.Modelo;

namespace App07_Cell.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageCellPage : ContentPage
    {
        public ImageCellPage()
        {
            InitializeComponent();

            List<Funcionario> lista = new List<Funcionario>();

            lista.Add(new Funcionario() { Nome = "Anderson", Cargo = "Presidente", Foto = "https://cimentoitambe.com.br/wp-content/uploads/2010/04/Anderson-Belea.jpg" });
            lista.Add(new Funcionario() { Nome = "Maria", Cargo = "Analista", Foto = "https://www.nube.com.br/media/noticias/2018/05/16/14527/funcionario-perfil-expectativa-lealdade-emprego_400x600.jpg" });
            lista.Add(new Funcionario() { Nome = "João", Cargo = "Funileiro", Foto = "https://images.squarespace-cdn.com/content/v1/51435924e4b02285c8b9c92d/1435276997644-5WE6FAVOB6Y9HZH89Y7A/ke17ZwdGBToddI8pDm48kNBhxsR5AixTPaSt36FQjZRZw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIHEpb-MmdDNvFVgjmeoENIlexef176In2EgYPtI8R2-8KMshLAGzx4R3EDFOm1kBS/caiobraga-perfil.jpg" });
            lista.Add(new Funcionario() { Nome = "Ana", Cargo = "Secretária", Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQuSeCWeMIkl7UlPSQdOF9nMXQVhaNkmQ4tEqH8gAB1FClsGqhK&usqp=CAU" });
            lista.Add(new Funcionario() { Nome = "Claudio", Cargo = "Programador", Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSQmq12SVLJMb4EA1GkUE5lMIfWsLtR2UF4bgw-IqifYmDRjytR&usqp=CAU" });

            ListaFuncionario.ItemsSource = lista;
        }
    }
}