using PhoneBookAssessment.ContactAPI.Data.Context;
using PhoneBookAssessment.ContactAPI.Repositories.Common;

namespace PhoneBookAssessment.ContactAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactDbContext _dbContext;
        private PersonRepository _personRepository;

        public UnitOfWork(ContactDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IPersonRepository PersonRepository => _personRepository = _personRepository ?? new PersonRepository(_dbContext);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}