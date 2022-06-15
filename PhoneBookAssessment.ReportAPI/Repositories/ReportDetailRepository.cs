using Microsoft.EntityFrameworkCore;
using PhoneBookAssessment.ReportAPI.Data.Context;
using PhoneBookAssessment.ReportAPI.Data.Entities;
using PhoneBookAssessment.ReportAPI.Repositories.Common;

namespace PhoneBookAssessment.ReportAPI.Repositories
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        public ReportRepository(ReportDbContext dbContext) : base(dbContext)
        {
        } 
    }
}