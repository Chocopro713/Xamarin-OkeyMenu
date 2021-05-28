using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace presentacion.Views
{
    public partial class PresentacionPage : ContentPage
    {
        private string _nextTxt;
        private ImageSource _nextIcon;
        private FontImageSource _finishIcon;

        public PresentacionPage()
        {
            InitializeComponent();

            this._nextTxt = NextPresentation.Text;
            this._nextIcon = NextPresentation.ImageSource;
            this._finishIcon = new FontImageSource { Color = (Color)Application.Current.Resources["PrimaryColor"], FontFamily = "LineIcons", Glyph = LineAwesomeFont.CheckCircle, Size = 15 };
            carousel.PositionChanged += Carousel_PositionChanged;
            PreviousPresentation.Clicked += PreviousPresentation_Clicked;
            NextPresentation.Clicked += NextPresentation_Clicked;
        }

        #region Events
        /// <summary>
        /// Cambiar la posición de la presentación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Carousel_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            if (carousel.Position < 3)
            {
                NextPresentation.Text = this._nextTxt;
                NextPresentation.ImageSource = this._nextIcon;
            }
            else
            {
                NextPresentation.Text = "Finalizar";
                NextPresentation.ImageSource = this._finishIcon;
            }
        }

        /// <summary>
        /// Retrocede la presentación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousPresentation_Clicked(object sender, System.EventArgs e)
        {
            if (carousel.Position == 0)
                return;

            var newPosition = carousel.Position - 1;
            carousel.ScrollTo(newPosition);
        }

        /// <summary>
        /// Continúa la presentación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NextPresentation_Clicked(object sender, System.EventArgs e)
        {
            if (carousel.Position == 3)
                return;

            int newPosition = carousel.Position + 1;
            carousel.ScrollTo(newPosition);
        }
        #endregion Events
    }
}
