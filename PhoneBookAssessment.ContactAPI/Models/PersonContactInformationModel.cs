using PhoneBookAssessment.ContactAPI.Models.Enums;

namespace PhoneBookAssessment.ContactAPI.Models
{
    public class PersonContactInformationModel : BaseModel
    { 
        public string? InformationContent { get; set; }
        
        public InformationTypes InformationType { get; set; }

        public string? InformationTypeDescription { get; set; }

        public Guid PersonId { get; set; }
    }
}