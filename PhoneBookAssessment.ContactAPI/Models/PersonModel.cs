namespace PhoneBookAssessment.ContactAPI.Models
{
    public class PersonModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
        public List<PersonContactInformationModel> ContactInformation { get; set; } = new List<PersonContactInformationModel>();

    }
}