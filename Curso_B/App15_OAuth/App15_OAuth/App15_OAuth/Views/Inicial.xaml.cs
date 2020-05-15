using Xamarin.Forms;

namespace App15_OAuth.Views
{
    public partial class Inicial : ContentPage
    {
        public Inicial(params string[] parametros)
        {
            InitializeComponent();

            foreach (var param in parametros)
            {
                lblInformacao.Text += param + "\n";
            }
        }
    }
}
