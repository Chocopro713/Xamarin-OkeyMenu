using System;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace presentacion.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Attributes
        private INavigationService _navigationService;
        #endregion Attributes

        #region Properties
        public ICommand GoLoginCommand { get; set; }
        public ICommand ScannerMenuCommand { get; set; }
        #endregion Properties

        #region Constructor
        public HomePageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            this.ScannerMenuCommand = new Command(OnScannerMenuCommand);
            this.GoLoginCommand = new Command(OnGoLoginCommand);
        }
        #endregion Constructor

        #region Methods
        #endregion Methods

        #region Commands
        /// <summary>
        /// Lo redirige al Login
        /// </summary>
        private async void OnGoLoginCommand()
        {
            if (this.IsBusy)
                return;

            this.IsBusy = true;

            var navigation = await this._navigationService.NavigateAsync(new Uri($"/LoginPage", UriKind.Relative));
            if (!navigation.Success)
                await PageDialog.AlertAsync(navigation.Exception.Message, "Iniciar Sesión", "Aceptar");
            this.IsBusy = false;
        }

        /// <summary>
        /// Lo dirigue a la pagina de escanear codigos
        /// </summary>
        private async void OnScannerMenuCommand()
        {
            if (this.IsBusy)
                return;

            this.IsBusy = true;

            bool permission = await GoogleVisionBarCodeScanner.Methods.AskForRequiredPermission();
            if (!permission)
            {
                this.PageDialog.Toast("Debes activar los permisos para poder seguir.");
                this.IsBusy = false;
                return;
            }

            var navigation = await this._navigationService.NavigateAsync(new Uri($"/ScannerPage", UriKind.Relative));
            if (!navigation.Success)
                await PageDialog.AlertAsync(navigation.Exception.Message, "Escanear Codigo", "Aceptar");
            this.IsBusy = false;
        }
        #endregion Commands

        #region Navegacion
        #endregion Navegacion
    }
}
