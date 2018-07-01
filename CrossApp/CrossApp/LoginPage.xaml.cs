using System;
using System.Collections.Generic;
using Model;
using Xamarin.Forms;

namespace CrossApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        #region Public properties
        /// <summary>
        /// Data access
        /// </summary>
        public Manager Manager { get { return ((App)App.Current).Manager; } }

        #region Connection
        /// <summary>
        /// Login for the connection
        /// </summary>
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; OnPropertyChanged(nameof(Login)); }
        }
        /// <summary>
        /// Password for the connection
        /// </summary>
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }
        #endregion
        #endregion

        #region Events
        /// <summary>
        /// Click to connect
        /// </summary>
        void btnSignIn_Clicked(object sender, System.EventArgs e)
        {
            var result = Manager.TryConnection(Login, Password);
            if (result)
                Navigation.PushModalAsync(new HomePage());
            else
            {
                DisplayAlert("Erreur", "La connexion a échouée.", "Ok");
            }
        }

        void btnSignUp_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new SignUpPage());
        }
        #endregion
    }
}
