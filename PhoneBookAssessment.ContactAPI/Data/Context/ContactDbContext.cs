using System;
using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ContactAPI.Data.Configurations;
using PhoneBookAssessment.ContactAPI.Data.Entities;

namespace PhoneBookAssessment.ContactAPI.Data.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

        public DbSet<People> Peoples { get; set; }
        public DbSet<PeopleContactInformation> PeopleContactInformation { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            modelBuilder.ApplyConfiguration(new PeopleContactInformationConfiguration()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
