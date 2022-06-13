namespace PhoneBookAssessment.ContactAPI.Models
{
    public class PersonDetailModel : PersonModel
    {
        public List<PersonContactInformationModel>? ContactInformation { get; set; }
    }
}