using PhoneBookAssessment.ReportAPI.Models;

namespace PhoneBookAssessment.ReportAPI.Services.Common
{
    public interface IReportService
	{
        Task<Guid> CreateReport();
        Task GenerateReportResponse(Guid id);
        Task<IReadOnlyList<ReportModel>> GetAllReports();
        Task<ReportResponseModel> GetReportDetail(Guid reportId);
    }
}
	
