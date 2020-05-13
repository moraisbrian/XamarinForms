using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App02_ListView
{
    public class SeletorTemplate : DataTemplateSelector
    {
        DataTemplate itemPessoaObrigatoria;
        DataTemplate itemPessoaNaoObrigatoria;

        public SeletorTemplate()
        {
            itemPessoaObrigatoria = new DataTemplate(typeof(Templates.ItemPessoaObrigatorioViewCell));
            itemPessoaNaoObrigatoria = new DataTemplate(typeof(Templates.ItemPessoaNaoObrigatorioViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            MainPage.Pessoa pessoa = item as MainPage.Pessoa;
            
            if (pessoa.Obrigatorio)
            {
                return itemPessoaObrigatoria;
            }
            else
            {
                return itemPessoaNaoObrigatoria;
            }
        }
    }
}
