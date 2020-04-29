using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App11_Mimica.View;

namespace App11_Mimica
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Inicio();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
