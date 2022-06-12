using System;
using System.Collections.Generic;

namespace PhoneBookAssessment.ContactAPI.Data.Entities
{
    public class Person : BaseEntity
    { 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
        public virtual List<PersonContactInformation> ContactInformation { get; set; } = new List<PersonContactInformation>();

    }
}
