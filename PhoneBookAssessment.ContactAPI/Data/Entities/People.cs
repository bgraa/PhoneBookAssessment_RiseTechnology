using System;
using System.Collections.Generic;

namespace PhoneBookAssessment.ContactAPI.Data.Entities
{
    public class People : BaseEntity
    { 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
        public List<PeopleContactInformation> ContactInformation { get; set; } = new List<PeopleContactInformation>();

    }
}
