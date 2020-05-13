using PCLStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App11_PCLStorage.Util;

namespace App11_PCLStorage
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnEscrever.Clicked += (sender, args) =>
            {
                StorageManager.SalvarArquivo("file.txt", txtConteudo.Text);
            };

            btnLerArquivo.Clicked += async (sender, args) =>
            {
                lblConteudoArquivo.Text = await StorageManager.LerArquivo("file.txt");
            };
        }
    }
}
