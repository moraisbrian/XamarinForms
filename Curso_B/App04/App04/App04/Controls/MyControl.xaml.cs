using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App04.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyControl : ContentView
    {
        public event EventHandler Tapped;

        #region Titulo
        public static readonly BindableProperty TituloProperty = BindableProperty.Create(
                propertyName: "Titulo",
                returnType: typeof(string),
                declaringType: typeof(MyControl),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TituloPropertyChanged
            );

        public string Titulo
        {
            get { return (string)GetValue(TituloProperty); }
            set { SetValue(TituloProperty, value); }
        }

        private static void TituloPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
        {
            var myControl = (MyControl)bindable;
            myControl.titulo.Text = (string)newValue;
        }
        #endregion

        #region TituloCor
        public static readonly BindableProperty TituloCorProperty = BindableProperty.Create(
                propertyName: "TituloCor",
                returnType: typeof(Color),
                declaringType: typeof(MyControl),
                defaultValue: Color.Black,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TituloCorPropertyChanged
            );

        public Color TituloCor
        {
            get { return (Color)GetValue(TituloCorProperty); }
            set { SetValue(TituloCorProperty, value); }
        }

        private static void TituloCorPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
        {
            var myControl = (MyControl)bindable;
            myControl.titulo.TextColor = (Color)newValue;
        }
        #endregion

        #region Imagem
        public static readonly BindableProperty ImagemProperty = BindableProperty.Create(
                propertyName: "Imagem",
                returnType: typeof(string),
                declaringType: typeof(MyControl),
                defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: ImagemPropertyChanged
            );

        public string Imagem
        {
            get { return (string)GetValue(ImagemProperty); }
            set { SetValue(ImagemProperty, value); }
        }

        private static void ImagemPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
        {
            var myControl = (MyControl)bindable;
            myControl.imagem.Source = ImageSource.FromFile((string)newValue);
        }
        #endregion

        public MyControl()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Tapped?.Invoke(sender, e);
        }
    }
}