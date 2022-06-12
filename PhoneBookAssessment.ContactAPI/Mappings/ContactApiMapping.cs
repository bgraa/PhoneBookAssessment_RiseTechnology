using AutoMapper;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;

namespace PhoneBookAssessment.ContactAPI.Mappings
{
    public class ContactApiMapping : Profile
    {
        public ContactApiMapping()
        {
            CreateMap<Person, PersonModel>();
            CreateMap<PersonModel, Person>();
        }
    }
}