using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamFirstProject.Models
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SamProjectDemo;Integrated Security=True");

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}