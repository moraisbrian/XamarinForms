using Prism;
using Prism.Ioc;
using App13_Prism.ViewModels;
using App13_Prism.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App13_Prism.Database;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App13_Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            Massa.CriarMassaDados();

            await NavigationService.NavigateAsync("NavigationPage/ListaProfissionais");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ListaProfissionais, ListaProfissionaisViewModel>();
            containerRegistry.RegisterForNavigation<DetalheProfissional, DetalheProfissionalViewModel>();
        }
    }
}
