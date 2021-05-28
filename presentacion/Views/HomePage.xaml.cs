using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace presentacion.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
