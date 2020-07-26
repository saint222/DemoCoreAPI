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
        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<VicePrincipal> VicePrincipals { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<PhoneNumber> SchoolPhoneNumbers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<SchoolSubject> SchoolSubjects { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<ParentPupil> ParentPupils { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentPupil>()
                .HasKey(pp => new { pp.ParentId, pp.PupilId});
            modelBuilder.Entity<ParentPupil>()
                .HasOne(p => p.Parent)
                .WithMany(p => p.ParentPupils)
                .HasForeignKey(p =>p.ParentId);
            modelBuilder.Entity<ParentPupil>()
                .HasOne(p => p.Pupil)
                .WithMany(p => p.ParentPupils)
                .HasForeignKey(p => p.PupilId);

            modelBuilder.Entity<ClassTeacher>()
                .HasKey(ct => new { ct.ClassId, ct.TeacherId });
            modelBuilder.Entity<ClassTeacher>()
                .HasOne(c => c.Class)
                .WithMany(p => p.ClassTeachers)
                .HasForeignKey(p => p.ClassId);
            modelBuilder.Entity<ClassTeacher>()
                .HasOne(t => t.Teacher)
                .WithMany(p => p.ClassTeachers)
                .HasForeignKey(p => p.TeacherId);

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    FirstName = "Aleksandr",
                    LastName = "Kalyuganov",
                    Patronymic = "Anatoljevich",
                    DateOfBirth = DateTime.Parse("03/18/1990", CultureInfo.InvariantCulture),
                    Email = "saint12maloj@gmail.com",
                    Password = "qqLQK/L5n5GqeiaCEkxVrUxlkbAWMmPUlOBSmlGXnPA=",
                    Role = 0
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
