using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Models;

namespace PhoneBookAssessment.ContactAPI.Services.Common
{
    public interface IPersonContactInformationService
    {
        Task<ResponseModel> AddContactInformation(Guid personId, CreatePersonContactInformationModel contactInformationModel);
        Task<ResponseModel> DeleteContactInformation(Guid id);
        Task<ResponseModel<IReadOnlyList<PersonContactInformationModel>>> GetAllContactInformations();
    }
}