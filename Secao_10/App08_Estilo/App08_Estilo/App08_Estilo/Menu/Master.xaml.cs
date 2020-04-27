using App08_Estilo.Pagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App08_Estilo.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void GoImplicitiStylePage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ImplicitiStylePage());
            IsPresented = false;
        }

        private void GoExplicitiStylePage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ExplicitiStylePage());
            IsPresented = false;
        }

        private void GoGlobalStylePage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new GlobalStylePage());
            IsPresented = false;
        }

        private void GoInheritStylePage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new InheritStylePage());
            IsPresented = false;
        }
    }
}