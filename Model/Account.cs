using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Account
    {
        #region Public properties
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime DoB { get; set; }
        #endregion

        #region Constructors
        public Account()
        {
        }

        /// <summary>
        /// Constructor of an account with some parameters
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="doB">Date of birth.</param>
        public Account(string login, string password, string firstName, string lastName, DateTime doB)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;
        }

        /// <summary>
        /// Constructor of an account with another account data
        /// </summary>
        /// <param name="account">Account.</param>
        public Account(Account account)
        {
            Id = account.Id;
            Login = account.Login;
            Password = account.Password;
            FirstName = account.FirstName;
            LastName = account.LastName;
            DoB = account.DoB;
        }

        /// <summary>
        /// Modify public information about an account
        /// </summary>
        /// <param name="account">Account containing the modified informations.</param>
        internal void ModifyAccount(Account account)
        {
            FirstName = account.FirstName;
            LastName = account.LastName;
            DoB = account.DoB;
        }
        #endregion
    }
}