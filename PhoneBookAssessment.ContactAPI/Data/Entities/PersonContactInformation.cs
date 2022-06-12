using PhoneBookAssessment.ContactAPI.Models.Enums;

namespace PhoneBookAssessment.ContactAPI.Data.Entities
{
    public class PersonContactInformation : BaseEntity
    {
        public InformationTypes? InformationType { get; set; }
        public string? InformationContent { get; set; }
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
    }

    
}
