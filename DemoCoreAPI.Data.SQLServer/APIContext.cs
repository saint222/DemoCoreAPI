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
        public DbSet<PrincipalDb> Principals { get; set; }
        public DbSet<VicePrincipalDb> VicePrincipals { get; set; }
        public DbSet<AdminDb> Admins { get; set; }
        public DbSet<TeacherDb> Teachers { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<PupilDb> Pupils { get; set; }
        public DbSet<SchoolPhoneNumberDb> SchoolPhoneNumbers { get; set; }
        public DbSet<SchoolAddressDb> SchoolAddresses { get; set; }
        public DbSet<ParentDb> Parents { get; set; }
        public DbSet<ClassTeacherDb> ClassTeachers { get; set; }
        public DbSet<ParentPupilDb> ParentPupils { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentPupilDb>()
                .HasKey(pp => new { pp.ParentDbId, pp.PupilDbId});
            modelBuilder.Entity<ParentPupilDb>()
                .HasOne(p => p.Parent)
                .WithMany(p => p.ParentPupils)
                .HasForeignKey(p =>p.ParentDbId);
            modelBuilder.Entity<ParentPupilDb>()
                .HasOne(p => p.Pupil)
                .WithMany(p => p.ParentPupils)
                .HasForeignKey(p => p.PupilDbId);

            modelBuilder.Entity<ClassTeacherDb>()
                .HasKey(ct => new { ct.ClassDbId, ct.TeacherDbId });
            modelBuilder.Entity<ClassTeacherDb>()
                .HasOne(c => c.Class)
                .WithMany(p => p.ClassTeachers)
                .HasForeignKey(p => p.ClassDbId);
            modelBuilder.Entity<ClassTeacherDb>()
                .HasOne(t => t.Teacher)
                .WithMany(p => p.ClassTeachers)
                .HasForeignKey(p => p.TeacherDbId);

            modelBuilder.Entity<AdminDb>().HasData(
                new AdminDb
                {
                    Id = 1,
                    FirstName = "Aleksandr",
                    LastName = "Kalyuganov",
                    Patronymic = "Anatoljevich",
                    DateOfBirth = DateTime.Parse("03/18/1990", CultureInfo.InvariantCulture),
                    Email = "saint12maloj@gmail.com",
                    Password = "qqLQK/L5n5GqeiaCEkxVrUxlkbAWMmPUlOBSmlGXnPA=",
                    Role = DomainModels.Enums.Roles.Admin
                }
                //new SchoolDb
                //{
                //    Id = 1
                //},
                //new PupilDb
                //{ 
                //    Id = 2,
                //    FirstName = "Aleksandr",
                //    LastName = "Kalyuganov",
                //    Patronymic = "Anatoljevich",
                //    DateOfBirth = DateTime.Parse("03/18/1990", CultureInfo.InvariantCulture),
                //    Email = "aleksandr.kalyuganov@gmail.com",
                //    Password = "qqLQK/L5n5GqeiaCEkxVrUxlkbAWMmPUlOBSmlGXnPA=",
                //    Role = DomainModels.Enums.Roles.Pupil
                //}
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
