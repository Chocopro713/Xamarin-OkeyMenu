using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace presentacion.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Attributes
        private INavigationService _navigationService;
        private bool _isVideoVisible;
        #endregion Attributes

        #region Properties
        public bool IsVideoVisible
        {
            get { return _isVideoVisible; }
            set { SetProperty(ref _isVideoVisible, value); }
        }

        public ICommand GoLoginCommand { get; set; }
        public ICommand ScannerMenuCommand { get; set; }
        #endregion Properties

        #region Constructor
        public HomePageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            this.ScannerMenuCommand = new Command(OnScannerMenuCommand);
            this.GoLoginCommand = new Command(OnGoLoginCommand);

            // Events
            ShowPresentacion();
        }
        #endregion Constructor

        #region Methods
        private async void ShowPresentacion()
        {
            /*
            await Task.Delay(500);
            var navegation = await this._navigationService.NavigateAsync("WelcomeBoardingPage", new NavigationParameters(), useModalNavigation: true, animated: true);
            if (!navegation.Success)
                PageDialog.Alert("No fue posible ingresar a la ventana de bienvenida.", "Error", "Aceptar");
            */
        }
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
        /// <summary>
        /// Se ejecuta cuando sale de la pagina
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            this.IsVideoVisible = false;
        }

        /// <summary>
        /// Se ejecuta cada vez que ingrese o se devuelva a la pagina
        /// </summary>
        /// <param name="parameters"></param>
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            this.IsVideoVisible = true;
        }
        #endregion Navegacion
    }
}
