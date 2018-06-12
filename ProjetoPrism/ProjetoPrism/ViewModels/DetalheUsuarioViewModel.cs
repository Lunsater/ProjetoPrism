using Acr.UserDialogs;
using Plugin.ExternalMaps;
using Plugin.ExternalMaps.Abstractions;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProjetoPrism.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPrism.ViewModels
{
	public class DetalheUsuarioViewModel : ViewModelBase
	{
        private Usuario _usuarioSelecionado;
        public DelegateCommand ObterLocalidadeCommand => new DelegateCommand(BuscarLocalidade);

        private String _localidade;
        public String Localidade
        {
            get { return _localidade; }
            set { SetProperty(ref _localidade, value); }
        }


        public Usuario UsuarioSelecionado
        {
            get { return _usuarioSelecionado; }
            set { SetProperty(ref _usuarioSelecionado, value); }
        }


        public DetalheUsuarioViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("Usuario"))
                UsuarioSelecionado = parameters.GetValue<Usuario>("Usuario");
        }

        private async void BuscarLocalidade()
        {
            try
            {
                var permission = CrossPermissions.Current;
                var status = await permission.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    var resultado = await permission.RequestPermissionsAsync(Permission.Location);
                    status = resultado[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    var localizador = CrossGeolocator.Current;
                    if (!localizador.IsGeolocationEnabled)
                    {
                        await DialogService.DisplayAlertAsync("Aviso", "Ative o GPS", "Ok");
                    }
                    else
                    {
                        UserDialogs.Instance.ShowLoading("Carregando...");
                        localizador.DesiredAccuracy = 30;
                        var coordenadas = await localizador.GetPositionAsync(null, null, true);
                        Localidade = coordenadas.Latitude + " --- " + coordenadas.Longitude;
                        UserDialogs.Instance.HideLoading();
                        await CrossExternalMaps.Current.NavigateTo("Marcador", coordenadas.Latitude, coordenadas.Longitude, NavigationType.Default);
                    }
                }
            }
            catch (Exception e)
            {

                
            }
        }

        private async void ConsumirServico()
        {
            try
            {

            }
            catch (Exception e)
            {

                
            }
        }
    }
}
