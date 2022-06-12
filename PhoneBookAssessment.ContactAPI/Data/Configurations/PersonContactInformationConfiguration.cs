using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models.Enums;

namespace PhoneBookAssessment.ContactAPI.Data.Configurations
{
    public class PersonContactInformationConfiguration : IEntityTypeConfiguration<PersonContactInformation>
    {
        public void Configure(EntityTypeBuilder<PersonContactInformation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()").IsRequired();
            builder.Property(x => x.InformationContent).IsRequired().HasMaxLength(512);
            builder.Property(x => x.InformationType).IsRequired()
                                                .HasMaxLength(32)
                                                .HasConversion(x => x.ToString(), x => (InformationTypes)Enum.Parse(typeof(InformationTypes), x))
                                                .IsUnicode(false);
            builder.ToTable("PersonContactInformation");
        }
    }
}