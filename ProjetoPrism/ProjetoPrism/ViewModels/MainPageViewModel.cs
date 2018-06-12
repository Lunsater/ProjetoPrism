using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjetoPrism.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjetoPrism.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
        public ObservableCollection<Usuario> ListaUsuarios { get; set; }
        public DelegateCommand<Usuario> SelecionarUsuarioCommand => new DelegateCommand<Usuario>(navegarDetalhesUsuario);

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Title = "Main Page";

            ListaUsuarios = new ObservableCollection<Usuario>()
            {
                new Usuario() { Matricula = 001, Nome = "Alcenor", Sobrenome = "Almeida"},
                new Usuario() { Matricula = 002, Nome = "Opal", Sobrenome = "Lunsater"},
                new Usuario() { Matricula = 003, Nome = "Thayna", Sobrenome = "Martins"},
            };
        }

        private async void navegarDetalhesUsuario(Usuario usuarioSelecionado)
        {
            var param = new NavigationParameters();
            param.Add("Usuario", usuarioSelecionado);
            await NavigationService.NavigateAsync("DetalheUsuario", param);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            /*
            try
            {
                if (parameters.ContainsKey("Titulo1"))
                {
                    Title = parameters.GetValue<String>("Titulo1");
                }
                else
                {
                    DialogService.DisplayAlertAsync("Aviso", "Texto não encontrado", "Ok");
                }
            }
            catch (Exception e)
            {

            }
            */
        }
    }
}
