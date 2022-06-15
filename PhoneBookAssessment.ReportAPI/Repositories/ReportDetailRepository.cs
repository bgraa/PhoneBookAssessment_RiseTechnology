using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ReportAPI.Data.Context;
using PhoneBookAssessment.ReportAPI.Data.Entities;
using PhoneBookAssessment.ReportAPI.Repositories.Common;

namespace PhoneBookAssessment.ReportAPI.Repositories
{
    public class ReportDetailRepository : GenericRepository<ReportDetail>, IReportDetailRepository
    {
        public ReportDetailRepository(ReportDbContext dbContext) : base(dbContext)
        {
        } 
    }
}