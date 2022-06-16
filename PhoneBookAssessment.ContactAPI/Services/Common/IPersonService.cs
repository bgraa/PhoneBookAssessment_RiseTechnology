using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;

namespace PhoneBookAssessment.ContactAPI.Services.Common
{
    public interface IPersonService
    {
        Task<IReadOnlyList<PersonModel>> GetAllPersonsAsync();
        Task<ResponseModel<PersonModel>> GetPersonByIdAsync(Guid id);
        Task<ResponseModel<PersonDetailModel>> GetPersonByIdWithDetailAsync(Guid id);
        Task<ResponseModel<Guid>> CreatePersonAsync(CreatePersonModel person); 
        Task<ResponseModel> DeletePerson(Guid id);
    }
}