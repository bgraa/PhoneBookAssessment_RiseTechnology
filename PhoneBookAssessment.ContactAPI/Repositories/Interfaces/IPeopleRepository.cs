using PhoneBookAssessment.ContactAPI.Entities;

namespace PhoneBookAssessment.ContactAPI.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        List<People> GetAll();
        People? Get(int id);
        int Delete(int id);
    }
}