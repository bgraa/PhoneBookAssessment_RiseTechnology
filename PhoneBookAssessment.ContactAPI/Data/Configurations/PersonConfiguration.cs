using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBookAssessment.ContactAPI.Data.Entities;

namespace PhoneBookAssessment.ContactAPI.Data.Configurations
{
    public class PersonConfiguration: IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()").IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(32);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(32);
            builder.Property(x => x.Company).IsRequired().HasMaxLength(256);
            builder.ToTable("Person");
        }
    }
}