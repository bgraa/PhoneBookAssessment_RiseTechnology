using System;
namespace PhoneBookAssessment.ReportAPI.Models
{
    public class ReportResponseModel
    {
        public ReportModel Report { get; set; }

        public List<ReportDetailModel> ReportDetailModels { get; set; }
    }
}

