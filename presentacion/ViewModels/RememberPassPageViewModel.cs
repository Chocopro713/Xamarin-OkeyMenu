using System;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace presentacion.ViewModels
{
    public class RememberPassPageViewModel
    {
        #region Attributes
        private INavigationService _navigationService;
        #endregion Attributes

        #region Properties
        public ICommand BackCommand { get; set; }
        #endregion Properties

        #region Constructor
        public RememberPassPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;

            this.BackCommand = new Command(OnBackCommand);
        }
        #endregion Constructor

        #region Methods
        #endregion Methods

        #region Commands
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
