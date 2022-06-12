using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ContactAPI.Data.Entities;
using PhoneBookAssessment.ContactAPI.Repositories.Common;

namespace PhoneBookAssessment.ContactAPI.Repositories
{
    public class PeopleRepository : GenericRepository<People>, IPeopleRepository
    {
        public PeopleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}