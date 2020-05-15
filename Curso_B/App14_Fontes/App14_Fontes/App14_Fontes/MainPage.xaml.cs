using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App14_Fontes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
                lblWelcom.FontFamily = "LilyoftheValley.ttf#Lily of the Valley_Personal_Use";
            else if (Device.RuntimePlatform == Device.iOS)
                lblWelcom.FontFamily = "Lily of the Valley_Personal_Use";

            /*
             * UWP
             * Inserir o arquivo ttf em Assets
             * Caminho para localização da fonte: Assets/LilyoftheValley.ttf#Lily of the Valley_Personal_Use
             * Pode-se criar uma pasta Fonts em Assets para organização. Exemplo: Assets/Fonts/LilyoftheValley.ttf#Lily of the Valley_Personal_Use
             */
             
        }
    }
}
