using PhoneBookAssessment.ContactAPI.Data.Entities;

namespace PhoneBookAssessment.ContactAPI.Services.Common
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetAllPeoples();
        Task<People> GetPeopleByIdAsync(Guid Id);
        Task<People> CreatePeople(People people);
        Task<People> UpdatePeople(People people);
        void DeletePeople(People people);

    }
}