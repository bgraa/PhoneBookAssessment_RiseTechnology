using System;
namespace PhoneBookAssessment.ContactAPI.Data.Entities
{
    public class PeopleContactInformation : BaseEntity
    {
        public InformationType? InformationType { get; set; }
        public string? InformationContent { get; set; }
        public int PeopleId { get; set; }
        public People? People { get; set; }
    }

    public enum InformationType
    {
        Email,
        Phone,
        Location
    }
}
