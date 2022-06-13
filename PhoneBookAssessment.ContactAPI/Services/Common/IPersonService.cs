using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;

namespace PhoneBookAssessment.ContactAPI.Services.Common
{
    public interface IPersonService
    {
        Task<IReadOnlyList<PersonModel>> GetAllPersonsAsync();
        Task<ResponseModel<PersonModel>> GetPersonByIdAsync(Guid Id);
        Task<ResponseModel<PersonDetailModel>> GetPersonByIdWithDetailAsync(Guid Id);
        Task<ResponseModel<Guid>> CreatePersonAsync(CreatePersonModel person);
        Task<ResponseModel<PersonModel>> UpdatePersonAsync(PersonModel person);
        Task DeletePerson(Guid id);
    }
}