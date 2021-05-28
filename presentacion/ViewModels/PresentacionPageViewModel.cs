using System;
using System.Collections.Generic;
using System.Windows.Input;
using FFImageLoading.Svg.Forms;
using presentacion.Models;
using Prism.Navigation;
using Xamarin.Forms;

namespace presentacion.ViewModels
{
    public class PresentacionPageViewModel : BaseViewModel
    {
        #region Attributes
        private INavigationService _navigationService;

        public bool _noFuturePresentation;
        private List<PresentacionModel> _presentations;
        #endregion Attributes

        #region Properties
        public bool NoFuturePresentation
        {
            get => _noFuturePresentation;
            set => SetProperty(ref _noFuturePresentation, value);
        }
        public List<PresentacionModel> Presentations
        {
            get => _presentations;
            set => SetProperty(ref _presentations, value);
        }

        public ICommand ChangeCheckCommand { get; set; }
        public ICommand CloseModalCommand { get; set; }
        public ICommand FinishPresentationCommand { get; set; }
        #endregion Properties

        #region Constructor
        public PresentacionPageViewModel(INavigationService navigationService)
        {
            // Variables
            this._navigationService = navigationService;
            this.NoFuturePresentation = false;

            // Commands
            this.ChangeCheckCommand = new Command(() => this.NoFuturePresentation = !this.NoFuturePresentation);
            this.CloseModalCommand = new Command(OnCloseModal);
            this.FinishPresentationCommand = new Command<int>(OnFinishPresentation);

            // Events
            InitWelcomeBoarding();
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Evento inicial de Welcome
        /// </summary>
        private void InitWelcomeBoarding()
        {
            this.Presentations = new List<PresentacionModel>()
            {
                new PresentacionModel{
                    Image = SvgImageSource.FromResource("presentacion.Resources.Images.pedir.svg"),
                    Title = "¡Menú!",
                    Description = "Puedes escanear el código QR para obtener el menú."
                },
                new PresentacionModel{
                    Image = SvgImageSource.FromResource("presentacion.Resources.Images.comida.svg"),
                    Title = "¡Comida!",
                    Description = "Puedes pedir lo que se te antoje."
                },
                new PresentacionModel{
                    Image = SvgImageSource.FromResource("presentacion.Resources.Images.login.svg"),
                    Title = "¡Iniciar Sesión!",
                    Description = "Tienes que iniciar sesión para poder pedir tu comida."
                },
                new PresentacionModel{
                    Image = SvgImageSource.FromResource("presentacion.Resources.Images.registrarse.svg"),
                    Title = "¡Registro!",
                    Description = "Puedes registrarte en cualquier momento."
                }
            };
        }
        #endregion Methods

        #region Commands
        /// <summary>
        /// Cierra ventana modal
        /// </summary>
        private void OnCloseModal()
        {
            NavigationParameters parameters = new NavigationParameters { };
            this._navigationService.GoBackAsync(parameters, useModalNavigation: true, animated: true);
        }

        /// <summary>
        /// Evento al finalizar las presentaciones, cierra el modal
        /// </summary>
        /// <param name="carouselPosition">Posición Carousel</param>
        private void OnFinishPresentation(int carouselPosition)
        {
            int totalItems = this.Presentations.Count - 1;
            if (totalItems == carouselPosition)
            {
                OnCloseModal();
            }
        }
        #endregion Commands
    }
}
