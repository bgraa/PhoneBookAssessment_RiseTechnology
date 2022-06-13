using System.Collections.ObjectModel;

namespace PhoneBookAssessment.ContactAPI.Models
{
    public class PersonModel : BaseModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }

    }
}