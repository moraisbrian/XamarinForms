using App13_Prism.Database;
using App13_Prism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App13_Prism.ViewModels
{
    public class ListaProfissionaisViewModel : BindableBase
    {
        private INavigationService _navigationService;

        private List<Profissional> _listaProfissional;
        public List<Profissional> ListaProfissional
        {
            get { return _listaProfissional; }
            set { SetProperty(ref _listaProfissional, value); }
        }

        public DelegateCommand<Profissional> ItemProfissionalTappedCommand { get; set; }

        public ListaProfissionaisViewModel(INavigationService navigationService)
        {
            ListaProfissional = ProfissionalDB.GetListProfissional();
            ItemProfissionalTappedCommand = new DelegateCommand<Profissional>(ItemProfissional);
            _navigationService = navigationService;
        }

        private void ItemProfissional(Profissional profissional)
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("profissional", profissional);
            _navigationService.NavigateAsync("DetalheProfissional", param);
        }
    }
}
