using System;
using System.Collections.Generic;
using Model;
using Xamarin.Forms;

namespace CrossApp
{
    public partial class ModifyAccount : ContentPage
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CrossApp.ModifyAccount"/> class.
        /// </summary>
        public ModifyAccount()
        {
            InitializeComponent();

            AccountToModify = new Account(Manager.CurrentAccount);

            BindingContext = this;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Data access
        /// </summary>
        public Manager Manager { get { return ((App)App.Current).Manager; } }

        public Account AccountToModify { get; set; }
        #endregion

        #region Events
        /// <summary>
        /// Click the save button save the modifications done on the account
        /// </summary>
        void btnSave_Clicked(object sender, System.EventArgs e)
        {
            Manager.ModifyAccount(AccountToModify);
        }
        #endregion
    }
}
