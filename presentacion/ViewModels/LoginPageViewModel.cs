using System;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace presentacion.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Attributes
        private INavigationService _navigationService;
        #endregion Attributes

        #region Properties
        public ICommand BackCommand { get; set; }
        public ICommand RememberPassCommand { get; set; }
        #endregion Properties

        #region Constructor
        public LoginPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            this.BackCommand = new Command(OnBackCommand);
            this.RememberPassCommand = new Command(OnRememberPassCommand);
        }
        #endregion Constructor

        #region Methods
        #endregion Methods

        #region Commands
        /// <summary>
        /// Lo redirige a la página de recordar contraseña
        /// </summary>
        private async void OnRememberPassCommand()
        {
            if (this.IsBusy)
                return;

            this.IsBusy = true;

            var navigation = await this._navigationService.NavigateAsync(new Uri($"/RememberPassPage", UriKind.Relative));
            if (!navigation.Success)
                await PageDialog.AlertAsync(navigation.Exception.Message, "Recordar Contraseña", "Aceptar");
            this.IsBusy = false;
        }

        /// <summary>
        /// Lo devuelve a la página anterior
        /// </summary>
        private async void OnBackCommand()
        {
            await this._navigationService.GoBackAsync();
        }
        #endregion Commands

        #region Navegacion
        #endregion Navegacion
    }
}
