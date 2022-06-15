namespace PhoneBookAssessment.ReportAPI.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
          IReportRepository ReportRepository { get; } 
          IReportDetailRepository ReportDetailRepository { get; }
        Task SaveAsync();
    }
}