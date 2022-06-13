using PhoneBookAssessment.ContactAPI.Models.Enums;

namespace PhoneBookAssessment.ContactAPI.Models
{
    public class PersonContactInformationModel : BaseModel
    {
        public InformationTypes? InformationType { get; set; }
        
        public string? InformationContent { get; set; }

        public string? InformationTypeDescription { get; set; }
    }
}