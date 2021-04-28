using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace presentacion.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
