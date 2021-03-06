﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App07_Cell.Modelo;

namespace App07_Cell.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextCellPage : ContentPage
    {
        public TextCellPage()
        {
            InitializeComponent();

            List<Funcionario> lista = new List<Funcionario>();

            lista.Add(new Funcionario() { Nome = "Anderson", Cargo = "Presidente" });
            lista.Add(new Funcionario() { Nome = "Maria", Cargo = "Analista" });
            lista.Add(new Funcionario() { Nome = "João", Cargo = "Funileiro" });
            lista.Add(new Funcionario() { Nome = "Ana", Cargo = "Secretária" });
            lista.Add(new Funcionario() { Nome = "Claudio", Cargo = "Programador" });

            ListaFuncionario.ItemsSource = lista;
        }
    }
}