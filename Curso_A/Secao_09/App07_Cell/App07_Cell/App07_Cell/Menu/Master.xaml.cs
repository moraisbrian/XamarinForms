using App07_Cell.Pagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App07_Cell.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
        }

        public void GoTextCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new TextCellPage());
            IsPresented = false;
        }

        public void GoImageCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ImageCellPage());
            IsPresented = false;
        }

        public void GoEntryCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new EntryCellPage());
            IsPresented = false;
        }

        public void GoSwichCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new SwichCellPage());
            IsPresented = false;
        }

        public void GoViewCellPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ViewCellPage());
            IsPresented = false;
        }

        public void GoListViewPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ListViewPage());
            IsPresented = false;
        }

        public void GoListViewButtonPage(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new ListViewButtonPage());
            IsPresented = false;
        }
    }
}