using System;
using System.Collections.Generic;

namespace Model
{
    internal class ApplicationInitializer
    {
        public static void Seed(ApplicationContext context)
        {
            var accounts = new List<Account>
            {
                new Account("Mathis.FRIZOT", "admin", "Mathis", "FRIZOT", new DateTime(1998, 11, 9)),
                new Account("Alexis.FRIZOT", "alexisfrizot", "Alexis", "FRIZOT", new DateTime(2000, 9, 21)),
                new Account("Colin.FRIZOT", "colinfrizot", "Colin", "FRIZOT", new DateTime(2003, 8, 25)),
                new Account("Enzo.DACOSTA", "enzodacosta", "Enzo", "Da Costa", new DateTime(2000, 3, 7)),
            };
            accounts.ForEach(item => context.Accounts.Add(item));

            var publications = new List<Publication>
            {

            };
            publications.ForEach(item => context.Publications.Add(item));


            // Save the changes before quitting
            context.SaveChanges();
        }
    }
}