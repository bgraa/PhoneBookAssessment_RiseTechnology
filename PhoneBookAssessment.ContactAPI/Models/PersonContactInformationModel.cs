using PhoneBookAssessment.ContactAPI.Models.Enums;

namespace PhoneBookAssessment.ContactAPI.Models
{
    public class PersonContactInformationModel
    {
        public InformationTypes? InformationType { get; set; }
        public string? InformationContent { get; set; }
        public Guid PersonId { get; set; }
        public virtual PersonModel? Person { get; set; }
    }
}