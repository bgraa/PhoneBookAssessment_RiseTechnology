using AutoMapper;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;

namespace PhoneBookAssessment.ContactAPI.Mappings
{
    public class ContactApiMapping : Profile
    {
        public ContactApiMapping()
        {
            CreateMap<Person, PersonModel>().ReverseMap();

            CreateMap<CreatePersonModel, Person>();
            
            CreateMap<Person, PersonDetailModel>().IncludeBase<Person, PersonModel>();

            CreateMap<PersonContactInformation, PersonContactInformationModel>()
            .ForMember(dst => dst.InformationTypeDescription, opt => opt.MapFrom(src => src.InformationType.ToString()))
            .ReverseMap();

            CreateMap<CreatePersonContactInformationModel, PersonContactInformation>();
        }
    }
}