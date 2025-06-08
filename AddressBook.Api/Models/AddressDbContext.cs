using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AddressBook.Api.Models
{
    public class AddressDbContext : DbContext
    {
        public AddressDbContext(DbContextOptions<AddressDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Suburb> Suburb { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person { FirstName = "Khanyiso", LastName = "Luzipo", PhoneNumber = "063270866", Email = "khanyisoluzipo@gmail.com", PersonID = 1 });
            modelBuilder.Entity<Person>().HasData(
                new Person { FirstName = "Nelisa", LastName = "Mandla", PhoneNumber = "06798640938", Email = "nelisamandla@gmail.com", PersonID = 2 });

            modelBuilder.Entity<Suburb>().HasData(
                new Suburb { StreetName = "Kwazakhele", PostalCode = "6205", SuburbID = 1, CityID = 1});
            modelBuilder.Entity<Suburb>().HasData(
                new Suburb { StreetName = "Newton Park", PostalCode = "6200", SuburbID = 2, CityID = 1 });

            modelBuilder.Entity<City>().HasData(
                new City{ CityID = 1, CityName = "Port Elizabeth", ProvinceID = 1});
            modelBuilder.Entity<City>().HasData(
                new City { CityID = 2, CityName = "Durban", ProvinceID = 2 });

            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceID = 1, Name = "Eastern Cape", CountryID = 1 });
            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceID = 2, Name = "KwaZulu-Natal", CountryID = 1 });

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = 1, CountryName = "South Africa"});
        }
    }
}
