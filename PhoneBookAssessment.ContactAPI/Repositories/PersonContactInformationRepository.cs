using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ContactAPI.Data.Context;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Repositories.Common;

namespace PhoneBookAssessment.ContactAPI.Repositories
{
    public class PersonContactInformationRepository : GenericRepository<PersonContactInformation>, IPersonContactInformationRepository
    {
        public PersonContactInformationRepository(ContactDbContext dbContext) : base(dbContext)
        {

        } 
    }
}