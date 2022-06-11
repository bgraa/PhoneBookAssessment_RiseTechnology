using System;
namespace PhoneBookAssessment.ContactAPI.Data.Entities
{
    public class People
    {
        public int UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Firm { get; set; }
        public PeopleContactInformation ContactInformation { get; set; }

    }
}
