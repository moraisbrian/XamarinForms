using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App06
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                Container.Margin = new Thickness(0, 15, 0, 0);

                Label label = new Label()
                {
                    Text = "Projeto iOS",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };

                Container.Children.Add(label);
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                Label label = new Label()
                {
                    Text = "Projeto UWP",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };

                Container.Children.Add(label);              
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    Label label = new Label()
                    {
                        Text = "Projeto Android (Tablet)",
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    };

                    Container.Children.Add(label);
                }
                else
                {
                    Label label = new Label()
                    {
                        Text = "Projeto Android (Phone)",
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    };

                    Container.Children.Add(label);
                }
                
            }

            
        }
    }
}
