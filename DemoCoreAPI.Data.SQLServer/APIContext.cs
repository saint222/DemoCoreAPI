using DemoCoreAPI.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace DemoCoreAPI.Data.SQLServer
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                Database.Migrate(); // Applies any pending migrations for the context to the database. 
                                    // Will create the database if it does not already exist.
                                    // This API is exclusive with Database.EnsureCreated().
            }
        }

        public DbSet<SchoolDb> Schools { get; set; }
        public DbSet<ClassDb> Classes { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<PupilDb> Pupils { get; set; }
        public DbSet<TeacherDb> Teachers { get; set; }
        public DbSet<SchoolPhoneNumberDb> SchoolPhoneNumbers { get; set; }
        public DbSet<SchoolAddressDb> SchoolAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>().HasData(
                new UserDb
                {
                    Id = 1,
                    FirstName = "Aleksandr",
                    LastName = "Kalyuganov",
                    Patronymic = "Anatoljevich",
                    DateOfBirth = DateTime.Parse("03/18/1990", CultureInfo.InvariantCulture),
                    Email = "saint12maloj@gmail.com",
                    Password = "qqLQK/L5n5GqeiaCEkxVrUxlkbAWMmPUlOBSmlGXnPA=",
                    Role = DomainModels.Enums.Roles.Admin
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
