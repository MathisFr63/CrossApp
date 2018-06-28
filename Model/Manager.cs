using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Manager
    {
        #region Public Properties
        public ApplicationContext db { get; set; }
        #endregion

        #region Constructor
        public Manager()
        {
            db = new ApplicationContext();

            db.Accounts.Add(new Account("Enzo.DaCosta", "enzodacosta", "Enzo", "DA COSTA", new DateTime(2000, 3, 7)));
            db.SaveChanges();
        }
        #endregion
    }
}
