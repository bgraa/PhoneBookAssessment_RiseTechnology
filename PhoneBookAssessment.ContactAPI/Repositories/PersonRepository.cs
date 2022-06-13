using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ContactAPI.Data.Context;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Repositories.Common;

namespace PhoneBookAssessment.ContactAPI.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ContactDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Person> GetPersonWithContactInformationAsync(Guid id)
        {
            return await _dbContext.Persons.Include(x => x.ContactInformation).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}