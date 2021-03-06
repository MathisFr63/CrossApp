﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Model
{
    public class Manager : INotifyPropertyChanged
    {
        #region Property changed
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Database context
        /// </summary>
        public ApplicationContext db { get; set; }

        /// <summary>
        /// Collection of accounts
        /// </summary>
        //public ObservableCollection<Account> Accounts { get; set; }

        /// <summary>
        /// The selected account.
        /// </summary>
        private Account currentAccount;
        public Account CurrentAccount
        {
            get { return currentAccount; }
            set { currentAccount = value; OnPropertyChanged(nameof(CurrentAccount)); UpdateCAPublications(); }
        }

        public ObservableCollection<Publication> CAPublications { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Model.Manager"/> class.
        /// </summary>
        public Manager()
        {
            db = new ApplicationContext();
            //db = new ApplicationContext(true);
            GetData();
            Test();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Put all the tests here
        /// </summary>
        private void Test()
        {
        }

        /// <summary>
        /// Get all the database data into properties of the Manager.
        /// </summary>
        private void GetData()
        {
        }

        /// <summary>
        /// Saves the changes on the database.
        /// </summary>
        private void SaveChanges()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// Try to connect to an account
        /// </summary>
        /// <param name="login">Login of the account</param>
        /// <param name="password">Password of the account</param>
        public bool TryConnection(string login, string password)
        {
            var tmp = db.Accounts.Where(item => item.Login == login).FirstOrDefault() as Account;
            if (tmp != null)
            {
                if (tmp.Password == password)
                {
                    CurrentAccount = tmp;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sign up to the application by creating a new account
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="dateOfBirth">Date of birth.</param>
        public void SignUp(string login, string password, string firstName, string lastName, DateTime dateOfBirth)
        {
            var newAccount = new Account(login, password, firstName, lastName, dateOfBirth);
            db.Accounts.Add(newAccount);
            SaveChanges();

            CurrentAccount = newAccount;
        }

        /// <summary>
        /// Modify the selected account
        /// </summary>
        /// <param name="account">Account modified</param>
        public void ModifyAccount(Account account)
        {
            CurrentAccount.ModifyAccount(account);
            SaveChanges();
        }

        #region Private methods
        /// <summary>
        /// Update the collection of publications with the publications of the current account.
        /// </summary>
        private void UpdateCAPublications()
        {
            this.CAPublications = new ObservableCollection<Publication>(db.Publications.Where(item => item.AccountId == CurrentAccount.Id));
        }
        #endregion

        #region Publications
        #region Add publications
        /// <summary>
        /// Adds an publication to the currentAccount.
        /// </summary>
        /// <param name="publication">Publication.</param>
        public void AddPublication(Publication publication)
        {
            // TO DO : il faudra prendre en compte plus de paramètres et faire plusieurs méthodes selon le type de publications (son / photo / date)
            db.Publications.Add(publication);
            SaveChanges();
        }

        /// <summary>
        /// Adds an image publication to the currentAccount.
        /// </summary>
        /// <param name="accountId">Account identifier.</param>
        /// <param name="message">Message.</param>
        /// <param name="uri">URI.</param>
        public void AddImagePublication(int accountId, string message, string imageSource)
        {
            AddPublication(new ImagePublication(accountId, message, imageSource));
        }
        #endregion
        #endregion
        #endregion
    }
}
