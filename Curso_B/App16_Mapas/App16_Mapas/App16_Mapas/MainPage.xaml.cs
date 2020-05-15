using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App16_Mapas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-23.205427, -46.8920322), Distance.FromKilometers(1)));
            mapa.MapType = MapType.Street;
            mapa.IsShowingUser = true;

            var posicao = new Pin()
            {
                Position = new Position(-23.205427, -46.8920322),
                Label = "Posição marcada",
                Address = "Endereço"
            };

            mapa.Pins.Add(posicao);

            MapContainer.Children.Add(mapa);
        }
    }
}
