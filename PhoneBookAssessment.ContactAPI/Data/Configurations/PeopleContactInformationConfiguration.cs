using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookAssessment.ContactAPI.Data.Entities;

namespace PhoneBookAssessment.ContactAPI.Data.Configurations
{
    public class PeopleContactInformationConfiguration: IEntityTypeConfiguration<PeopleContactInformation>
    {
        public void Configure(EntityTypeBuilder<PeopleContactInformation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InformationContent).IsRequired().HasMaxLength(512);
            builder.Property(x => x.InformationType).IsRequired()
                                                .HasMaxLength(32)
                                                .HasConversion(x => x.ToString(), x => (InformationType)Enum.Parse(typeof(InformationType), x))
                                                .IsUnicode(false);
            builder.ToTable("PeopleContactInformation");
        }
    }
}