using System;
using System.Collections.Generic;
using Model;
using Xamarin.Forms;

namespace CrossApp
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        #region Public properties
        /// <summary>
        /// Data access
        /// </summary>
        public Manager Manager { get { return ((App)App.Current).Manager; } }

        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        #endregion

        #region Events
        /// <summary>
        /// Click to sign up
        /// </summary>
        void btnSignUp_Clicked(object sender, System.EventArgs e)
        {
            if (Password.Equals(PasswordConfirmation))
            {
                Manager.SignUp(Login, Password, FirstName, LastName, DateOfBirth);
                Navigation.PushModalAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Erreur", "Password and its confirmation must be the same", "Ok");
            }
        }

        /// <summary>
        /// Click on the back button to return on the login page
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void btnBack_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }
        #endregion
    }
}
