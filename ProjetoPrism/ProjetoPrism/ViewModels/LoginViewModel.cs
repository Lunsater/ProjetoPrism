using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoPrism.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
        public DelegateCommand IrParaMainPageCommand => new DelegateCommand(IrParaMainPage);

        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set { SetProperty(ref _texto, value); }
        }

        private Boolean _habilitado;
        public Boolean Habilitado
        {
            get { return _habilitado; }
            set { SetProperty(ref _habilitado, value); }
        }

        public LoginViewModel(INavigationService navigationService, IPageDialogService dialogService) :base(navigationService, dialogService)
        {
            Habilitado = false;
            //IrParaMainPageCommand = new DelegateCommand(IrParaMainPage);
        }

        private async void IrParaMainPage()
        {
            UserDialogs.Instance.Loading("Carregando");
            await Task.Delay(10000);
            UserDialogs.Instance.HideLoading();

            //var param = new NavigationParameters();
            //param.Add("Titulo1", "teste1");
            //param.Add("Titulo2", "teste2");
            //param.Add("Titulo3", "teste3");
            /*
            {
                {"Titulo1", "teste1"},
                {"Titulo2", "teste2"},
                {"Titulo3", "teste3"},
            };
            */
            //await NavigationService.NavigateAsync("MainPage", param);
            await NavigationService.NavigateAsync("MainPage");
        }

	}
}
