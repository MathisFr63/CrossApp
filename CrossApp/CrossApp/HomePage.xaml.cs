using System;
using System.Collections.Generic;
using Model;
using Xamarin.Forms;

namespace CrossApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = this;
        }

        #region Public properties
        /// <summary>
        /// Data access
        /// </summary>
        public Manager Manager { get { return ((App)App.Current).Manager; } }
        #endregion
    }
}
