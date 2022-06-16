using PhoneBookAssessment.ContactAPI.Models.Enums;

namespace PhoneBookAssessment.ContactAPI.Models
{
    public class CreatePersonContactInformationModel : BaseModel
    {

        public string? InformationContent { get; set; }

        public InformationTypes InformationType { get; set; }
    }
}