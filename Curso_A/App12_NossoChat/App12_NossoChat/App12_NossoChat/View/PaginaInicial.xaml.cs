﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App12_NossoChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : ContentPage
    {
        public PaginaInicial()
        {
            InitializeComponent();

            BindingContext = new ViewModel.PaginaInicialViewModel();
        }
    }
}