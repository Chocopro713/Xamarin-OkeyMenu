using System;
using GoogleVisionBarCodeScanner;
using Prism.Navigation;
using Xamarin.Forms;

namespace presentacion.ViewModels
{
    public class ScannerPageViewModel : BaseViewModel
    {
        #region Attributes
        private INavigationService _navigationService;
        #endregion Attributes

        #region Properties
        public string Barcode { get; set; }
        #endregion Properties

        #region Constructor
        public ScannerPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }
        #endregion Constructor

        #region Methods
        private void InitMessaginCenter()
        {
            MessagingCenter.Subscribe<string>("", MessagingKeys.GetInfoBarcode, (arg) =>
            {
                GoToMenu(arg);
            });
        }

        #endregion Methods

        #region Commands
        public async void GoToMenu(string nameRestaurant)
        {
            if (this.IsBusy)
                return;

            this.IsBusy = true;

            var parameters = new NavigationParameters { { "nameRestaurant", nameRestaurant} };

            var navigation = await this._navigationService.NavigateAsync(new Uri($"/MenuPage", UriKind.Relative), parameters);
            if (!navigation.Success)
                await PageDialog.AlertAsync(navigation.Exception.Message, "Escanear Codigo", "Aceptar");
            this.IsBusy = false;
        }
        #endregion Commands

        #region Navegacion
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            InitMessaginCenter();
        }
        #endregion Navegacion
    }
}
