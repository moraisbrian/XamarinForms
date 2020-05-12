using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App07
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        // int count = 0;

        public MainPage()
        {
            InitializeComponent();

            PanGestureRecognizer pan = new PanGestureRecognizer();
            pan.PanUpdated += PanGestureRecognizer_Pan;
            MyLabel.GestureRecognizers.Add(pan);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // count++;
            // DisplayAlert("Tapped", "Foi clicada: " + count, "Ok");

            MyBox.TranslateTo(200, 350, 1000, Easing.BounceOut);
            MyBox.ScaleTo(2, 5000);
            MyBox.FadeTo(0.5, 1000);
            MyBox.RotateTo(45, 1000, Easing.SpringOut);

            // var animation = new Animation(x => MyBox.WidthRequest = x, 50, 100);
            // animation.Commit(this, "animacao", 16, 1000);
        }

        private void PanGestureRecognizer_Pan(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Running)
            {
                Rectangle rect = new Rectangle(e.TotalX, e.TotalY, 200, 25);
                AbsoluteLayout.SetLayoutBounds(MyLabel, rect);
                AbsoluteLayout.SetLayoutFlags(MyLabel, AbsoluteLayoutFlags.None);
            }
        }
    }
}
