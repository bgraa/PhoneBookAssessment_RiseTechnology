using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ReportAPI.Data.Configurations;
using PhoneBookAssessment.ReportAPI.Data.Entities;

namespace PhoneBookAssessment.ReportAPI.Data.Context
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options) { }

        public DbSet<Report> Reports { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new ReportConfiguration()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
