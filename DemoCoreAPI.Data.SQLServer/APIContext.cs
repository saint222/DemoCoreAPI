using DemoCoreAPI.DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCoreAPI.Data.SQLServer
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) 
        {
            Database.Migrate(); // Applies any pending migrations for the context to the database. 
                                // Will create the database if it does not already exist.
                                // This API is exclusive with Database.EnsureCreated().
        }

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
