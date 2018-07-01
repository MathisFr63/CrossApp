using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(bool recreate = false)
        {
            if (recreate)
                Database.EnsureDeleted();
            Database.EnsureCreated();
            if (recreate)
                ApplicationInitializer.Seed(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost;port=3306;userid=root;password=mathis36;database=mysqltest;";
            optionsBuilder.UseMySQL(connectionString);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<ImagePublication> ImagePublications { get; set; }
    }
}
