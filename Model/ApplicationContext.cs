using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;port=3306;userid=root;password=mathis36;database=mysqltest;";
            optionsBuilder.UseMySQL(connectionString);
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
