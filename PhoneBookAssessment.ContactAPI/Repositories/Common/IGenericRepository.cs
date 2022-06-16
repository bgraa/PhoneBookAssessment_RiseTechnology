using System.Linq.Expressions;
using PhoneBookAssessment.ContactAPI.Data.Entities;

namespace PhoneBookAssessment.ContactAPI.Repositories.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}