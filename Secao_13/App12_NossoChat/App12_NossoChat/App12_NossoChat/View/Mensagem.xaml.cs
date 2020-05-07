using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App12_NossoChat.Model;

namespace App12_NossoChat.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mensagem : ContentPage
	{
		public Mensagem (Chat chat)
		{
			InitializeComponent ();

            BindingContext = new ViewModel.MensagemViewModel(chat);
		}
	}
}