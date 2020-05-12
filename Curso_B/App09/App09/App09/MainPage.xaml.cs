using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App09.Modelo;
using System.ComponentModel.DataAnnotations;

namespace App09
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnSalvar.Clicked += delegate
            {
                Pessoa pessoa = new Pessoa()
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Cpf = txtCpf.Text
                };

                var listaRes = new List<ValidationResult>();
                var contexto = new ValidationContext(pessoa);
                var isValid = Validator.TryValidateObject(pessoa, contexto, listaRes);

                if (!isValid)
                {
                    lblMsg.Text = string.Empty;
                    lblMsg.TextColor = Color.Red;

                    foreach (var x in listaRes)
                    {
                        lblMsg.Text += string.Format(x.ErrorMessage, x.MemberNames) + "\n";
                    }
                }
                else
                {
                    lblMsg.TextColor = Color.Green;
                    lblMsg.Text = "Ok";
                }
            };
        }
    }
}
