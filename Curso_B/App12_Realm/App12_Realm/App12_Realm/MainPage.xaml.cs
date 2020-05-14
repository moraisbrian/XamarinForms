using App12_Realm.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel.DataAnnotations;
using Realms;

namespace App12_Realm
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnAdicionar.Clicked += delegate
            {
                Produto produto = new Produto();
                produto.Item = txtItem.Text;
                produto.Quantidade = int.Parse(txtQuantidade.Text);

                var listRes = new List<ValidationResult>();
                var contexto = new ValidationContext(produto);
                bool valido = Validator.TryValidateObject(produto, contexto, listRes, true);

                if (!valido)
                {
                    string mensagem = string.Empty;

                    foreach (var res in listRes)
                    {
                        mensagem += res.ErrorMessage + "\n";
                    }
                    DisplayAlert("Erros", mensagem, "Ok");
                }
                else
                {
                    var realm = Realm.GetInstance();

                    if (lblId.Text == string.Empty)
                    {
                        #region Adicionar
                        var produtoFinal = realm.All<Produto>()
                            .OrderByDescending(x => x.Id)
                            .FirstOrDefault();

                        int novoId = 1;
                        if (produtoFinal != null)
                        {
                            novoId = produtoFinal.Id + 1;
                        }

                        produto.Id = novoId;

                        realm.Write(() =>
                        {
                            realm.Add(produto);
                        });
                        #endregion
                    }
                    else
                    {
                        #region Atualizar
                        produto.Id = int.Parse(lblId.Text);
                        realm.Write(() =>
                        {
                            realm.Add(produto, true);
                        });
                        #endregion
                    }

                    DisplayAlert("Salvo com sucesso",
                        string.Format("Itens no banco de dados: {0}", realm.All<Produto>().Count()),
                        "Ok");

                    txtItem.Text = "";
                    txtQuantidade.Text = "";
                    lblId.Text = "";

                    listaProdutos.ItemsSource = realm.All<Produto>();
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var realm = Realm.GetInstance();
            listaProdutos.ItemsSource = realm.All<Produto>();
        }

        private void MenuItemExcluir_Clicked(object sender, EventArgs e)
        {
            Produto produto = ((Produto)((MenuItem)sender).CommandParameter);
            var realm = Realm.GetInstance();

            realm.Write(() =>
            {
                realm.Remove(produto);
            });
            
            listaProdutos.ItemsSource = realm.All<Produto>();
        }

        private void MenuItemEditar_Clicked(object sender, EventArgs args)
        {
            Produto produto = ((Produto)((MenuItem)sender).CommandParameter);
            lblId.Text = produto.Id.ToString();
            txtItem.Text = produto.Item;
            txtQuantidade.Text = produto.Quantidade.ToString();
        }
    }
}
