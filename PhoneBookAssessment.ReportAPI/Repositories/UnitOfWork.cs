using PhoneBookAssessment.ReportAPI.Data.Context;
using PhoneBookAssessment.ReportAPI.Repositories.Common;

namespace PhoneBookAssessment.ReportAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportDbContext _dbContext;
        private ReportRepository _reportRepository;  
        private ReportDetailRepository _reportDetailRepository;

        public UnitOfWork(ReportDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IReportRepository ReportRepository => _reportRepository = _reportRepository ?? new ReportRepository(_dbContext);
        public IReportDetailRepository ReportDetailRepository => _reportDetailRepository = _reportDetailRepository ?? new ReportDetailRepository(_dbContext);

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