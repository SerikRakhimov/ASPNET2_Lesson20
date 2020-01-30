using Microsoft.EntityFrameworkCore;
using SaveTimeCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveTimeCore
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DataContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //    modelBuilder.Entity<Car>().HasData(
            //        new Car { Id = 1, Brand = "Lamborgini", Kuzov = Kuzov.Cabrio, Color = "red" },
            //        new Car { Id = 2, Brand = "Maserati", Kuzov = Kuzov.Kupe, Color = "green" },
            //        new Car { Id = 3, Brand = "BMW", Kuzov = Kuzov.Sedan, Color = "blue" });
        }
    }
}
