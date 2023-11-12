using BasicWebApi_Exam1.Model;
using BasicWebApi_Exam1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using System.Diagnostics.Metrics;


namespace BasicWebApi_Exam1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Country> Country { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>()
                .HasMany(c => c.Contacts)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Contact>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Country>()
                .HasMany(c => c.Contacts)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Contact>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Company>().HasData(
               new Company { CompanyId = 1, CompanyName = "Aspekt" },
               new Company { CompanyId = 2, CompanyName = "ITLabs" },
               new Company { CompanyId = 3, CompanyName = "Netcetera" }
            );

            builder.Entity<Contact>().HasData(
                new Contact { ContactId = 1, ContactName = "Aleksandar" },
                new Contact { ContactId = 2, ContactName = "Darko" },
                new Contact { ContactId = 3, ContactName = "Petre" }
            );

            builder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "Macedonia" },
                new Country { CountryId = 2, CountryName = "Macedonia" },
                new Country { CountryId = 3, CountryName = "Macedonia" }
                );
           


        }
    }   

}

