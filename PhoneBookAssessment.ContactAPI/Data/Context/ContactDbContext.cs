using System;
using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ContactAPI.Data.Configurations;
using PhoneBookAssessment.ContactAPI.Data.Entities;

namespace PhoneBookAssessment.ContactAPI.Data.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        
        public DbSet<PersonContactInformation> PersonContactInformation { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PersonContactInformationConfiguration()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
