using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App05_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBarPage : ContentPage
    {
        private List<string> empresasTI;
        public SearchBarPage()
        {
            InitializeComponent();

            empresasTI = new List<string>();
            empresasTI.Add("Microsoft");
            empresasTI.Add("Apple");
            empresasTI.Add("Oracle");
            empresasTI.Add("SAP");
            empresasTI.Add("IBM");

            Peencher(empresasTI);
        }

        private void PesquisarButton(object sender, EventArgs args)
        {
            var resultado = empresasTI
                .Where(x => x.ToLower()
                    .Contains(((SearchBar)sender).Text
                    .ToLower()))
                .ToList();

            Peencher(resultado);
        }

        private void Pesquisar(object sender, TextChangedEventArgs args)
        {
            var resultado = empresasTI
                .Where(x => x.ToLower()
                .Contains(args.NewTextValue
                .ToLower()))
                .ToList();

            Peencher(resultado);
        }

        private void Peencher(List<string> empresasTI)
        {
            ListResult.Children.Clear();
            foreach (var emp in empresasTI)
            {
                ListResult.Children.Add(new Label { Text = emp });
            }
        }
    }
}