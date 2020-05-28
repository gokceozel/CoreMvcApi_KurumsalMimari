using Microsoft.EntityFrameworkCore;
using NorthwindKurumsalMimari.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindKurumsalMimari.DataAccess.Concrete.EntityFramework.Contexts
{
   public class NorthwindContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
