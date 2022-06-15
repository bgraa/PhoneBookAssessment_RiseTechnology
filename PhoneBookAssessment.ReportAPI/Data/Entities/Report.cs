using PhoneBookAssessment.ReportAPI.Models.Enums;

namespace PhoneBookAssessment.ReportAPI.Data.Entities
{
    public class Report : BaseEntity
    {
        public DateTime RequestedDate { get; set; }

        public ReportStatusType ReportStatus { get; set; }

        public virtual ICollection<ReportDetail>? ReportDetails { get; set; }
    }
}
