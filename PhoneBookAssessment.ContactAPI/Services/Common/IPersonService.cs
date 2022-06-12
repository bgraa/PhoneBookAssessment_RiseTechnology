using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;

namespace PhoneBookAssessment.ContactAPI.Services.Common
{
    public interface IPersonService
    {
        Task<ResponseModel<PersonModel>> GetAllPersonsAsync();
        Task<ResponseModel<PersonModel>> GetPersonByIdAsync(Guid Id);
        Task<ResponseModel<PersonModel>> CreatePersonAsync(PersonModel person);
        Task<ResponseModel<PersonModel>> UpdatePersonAsync(PersonModel person);
        void DeletePerson(PersonModel person);
    }
}