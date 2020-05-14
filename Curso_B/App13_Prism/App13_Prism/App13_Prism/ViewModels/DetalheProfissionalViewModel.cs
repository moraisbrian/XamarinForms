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
    public class DetalheProfissionalViewModel : BindableBase, INavigationAware
    {
        private Profissional _profissional;
        public Profissional Profissional
        {
            get { return _profissional; }
            set { SetProperty(ref _profissional, value); }
        }

        private List<Comentario> _comentarios;
        public List<Comentario> Comentarios
        {
            get { return _comentarios; }
            set { SetProperty(ref _comentarios, value); }
        }

        public DetalheProfissionalViewModel()
        {
            
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("profissional"))
            {
                Profissional = parameters.GetValue<Profissional>("profissional");

                Comentarios = ComentarioDB.GetListComentario(Profissional);
            }
        }
    }
}
