using System;
using Acr.UserDialogs;
using Prism.Mvvm;
using Prism.Navigation;

namespace presentacion.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        #region Attributes
        private bool _isBusy;
        private string _version;
        #endregion Attributes

        #region Properties
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public string Version
        {
            get { return _version; }
            set { SetProperty(ref _version, value); }
        }
        public IUserDialogs PageDialog = UserDialogs.Instance;
        #endregion Properties

        #region Construsctor
        public BaseViewModel()
        {
            // Info Device
            this.Version = GlobalSetting.AppVersion;
        }
        #endregion Construsctor

        #region Navegacion
        /**
         * <summary>Navegación Prism, cuando inicia la página.</summary>
         * <param name="parameters">Navigation</param>
         * @autor Anderson Barbosa, a.barbosa@waplicaciones.co
         */
        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        /**
         * <summary>Navegación, Sale del formulario.</summary>
         * <param name="parameters">Parametros en la navegación en el sistema.</param>
         * @autor Anderson Barbosa, a.barbosa@waplicaciones.co
         */
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /**
         * <summary>Navegación, Cuando Ingresa Al Formulario.</summary>
         * <param name="parameters">Parametros en la navegación en el sistema.</param>
         * @autor Anderson Barbosa, a.barbosa@waplicaciones.co
         */
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        /**
         * <summary>Navegación, Antes De Ingresar Al formulario.</summary>
         * <param name="parameters">Parametros en la navegación en el sistema.</param>
         * @autor Anderson Barbosa, a.barbosa@waplicaciones.co
         */
        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        /**
         * <summary>Navegación, Finaliza Ventana Formulario.</summary>
         * @autor Anderson Barbosa, a.barbosa@waplicaciones.co
         */
        public virtual void Destroy()
        {

        }
        #endregion Navegacion
    }
}
