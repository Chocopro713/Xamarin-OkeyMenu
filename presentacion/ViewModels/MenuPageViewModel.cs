using System;
using System.Collections.ObjectModel;
using presentacion.Models;
using Prism.AppModel;
using Prism.Navigation;

namespace presentacion.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        #region Attributes
        private string _nameRestaurant;
        private ObservableCollection<MenuModel> _menus;
        #endregion Attributes

        #region Properties
        public string NameRestaurant
        {
            get { return _nameRestaurant; }
            set { SetProperty(ref _nameRestaurant, value); }
        }

        public ObservableCollection<MenuModel> Menus
        {
            get { return _menus; }
            set { SetProperty(ref _menus, value); }
        }
        #endregion Properties

        #region Constructor
        public MenuPageViewModel()
        {
        }
        #endregion Constructor

        #region Methods
        public void GetMenu()
        {

        }
        #endregion Methods

        #region Commands
        #endregion Commands

        #region Navegacion
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            this.NameRestaurant = parameters.GetValue<string>("nameRestaurant");
            Console.WriteLine(this.NameRestaurant);
        }
        #endregion Navegacion
    }
}
