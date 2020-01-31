using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCep;
            Cep.Text = "";
        }

        public void BuscarCep(object sender, EventArgs args)
        {
            try
            {
                string cep = Cep.Text.Trim();
                if (IsValidCEP(cep))
                {
                    Endereco endereco = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    Cep.Text = "";
                    if (!string.IsNullOrEmpty(endereco.cep))
                    {
                        Resultado.Text = string.Format(
                            "Endereço: {0}, {1}, {2} {3}",
                            endereco.logradouro,
                            endereco.bairro,
                            endereco.localidade,
                            endereco.uf
                        );
                    }
                    else
                    {
                        DisplayAlert("Erro", "CEP inválido", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }

        }

        private bool IsValidCEP(string cep)
        {
            string mensagem = "";
            if (cep.Length != 8)
            {
                mensagem += "O cep deve conter 8 caracteres\n";

            }

            int parse;
            if (!int.TryParse(cep, out parse))
            {
                mensagem += "O cep deve conter apenas números\n";
            }

            if (mensagem != "")
            {
                DisplayAlert("Erro", mensagem, "Ok");
                return false;
            }
            return true;
        }
    }
}
