using PhoneBookAssessment.ContactAPI.Data.Entities;

namespace PhoneBookAssessment.ContactAPI.Repositories.Common
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<Person> GetPersonWithContactInformationAsync(Guid id);
    }
}