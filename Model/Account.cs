using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Account
    {
        //[Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DoB { get; set; }

        #region Constructors
        public Account()
        {
        }

        public Account(string login, string password, string firstName, string lastName, DateTime doB)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;
        }
        #endregion
    }
}