using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App15_OAuth.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DelegateCommand LoginFacebookCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Login";
            _navigationService = navigationService;
            LoginFacebookCommand = new DelegateCommand(LoginFacebook);
        }

        private void LoginFacebook()
        {
            _navigationService.NavigateAsync("LoginFacebook");
        }
    }
}
