using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookAssessment.ReportAPI.Data.Entities;

namespace PhoneBookAssessment.ReportAPI.Data.Configurations
{
    public class ReportConfiguration: IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()").IsRequired();
            builder.Property(x => x.RequestedDate).IsRequired();
            builder.Property(x => x.ReportStatus).IsRequired();
            builder.ToTable("Reports");
        }

         
    }
}