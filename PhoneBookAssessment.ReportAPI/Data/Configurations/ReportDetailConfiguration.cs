using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookAssessment.ReportAPI.Data.Entities;

namespace PhoneBookAssessment.ReportAPI.Data.Configurations
{
    public class ReportDetailConfiguration : IEntityTypeConfiguration<ReportDetail>
    {
        public void Configure(EntityTypeBuilder<ReportDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()").IsRequired();
            builder.Property(x => x.Location).IsRequired();
            builder.Property(x => x.PersonsCount).IsRequired();
            builder.Property(x => x.PhoneNumbersCount).IsRequired();
            builder.ToTable("ReportDetails");
        }

         
    }
}