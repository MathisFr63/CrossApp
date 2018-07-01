using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossApp
{
    public partial class TmpPage : ContentPage
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CrossApp.MainPage"/> class.
        /// </summary>
        public TmpPage()
        {
            InitializeComponent();

            BindingContext = this;
        }
        #endregion

        #region Public Proerties
        /// <summary>
        /// Data access
        /// </summary>
        public Manager Manager { get { return ((App)App.Current).Manager; } }

        /// <summary>
        /// The last item taped --> allows double tap action on an item
        /// </summary>
        Account lastItemTaped { get; set; }

        /// <summary>
        /// Boolean indicating if the item taped as been taped during the last <see cref="seconds"/>
        /// </summary>
        bool firstTappedAccountItem { get; set; }

        /// <summary>
        /// Seconds between wich double tap is available
        /// </summary>
        const double seconds = 0.250;
        #endregion

        #region Events
        /// <summary>
        /// Click the add button to add an account to the list
        /// </summary>
        void btnAdd_Clicked(object sender, System.EventArgs e)
        {
            //Manager.AddAccount(new Account());
        }

        /// <summary>
        /// Double click an account in the list to modifiy it
        /// </summary>
        void listAccount_DoubleClicked(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            // If the action is a double on an item --> Show a new window to modifiy the selected account
            if (e.Item == lastItemTaped && firstTappedAccountItem)
            {
                Navigation.PushModalAsync(new ModifyAccount());
            }
            else
            {
                lastItemTaped = e.Item as Account;
                introduceFirstTap();
            }
        }

        /// <summary>
        /// Introduces the first tap on an account --> double tap to modify
        /// </summary>
        void introduceFirstTap()
        {
            Task.Factory.StartNew(() =>
            {
                firstTappedAccountItem = true;
                System.Threading.Thread.Sleep((int)(seconds * 1000));
            }).ContinueWith((antecedent) => firstTappedAccountItem = false);
        }
        #endregion
    }
}
