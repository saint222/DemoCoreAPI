using DemoCoreAPI.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.Data.SQLServer
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) { }
        
        public DbSet<UserDb> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>().HasData(
                new UserDb
                {
                    Id = 1,
                    FirstName = "Aleksandr",
                    LastName = "Kalyuganov",
                    Age = 29,
                    Email = "saint12maloj@gmail.com",
                    Password = "qqLQK/L5n5GqeiaCEkxVrUxlkbAWMmPUlOBSmlGXnPA=",
                    IsAdmin = true
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
