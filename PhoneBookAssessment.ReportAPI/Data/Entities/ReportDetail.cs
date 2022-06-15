namespace PhoneBookAssessment.ReportAPI.Data.Entities
{
    public class ReportDetail : BaseEntity
    {
        public string? Location { get; set; }
        public int PersonsCount { get; set; }
        public int PhoneNumbersCount { get; set; }
        public Guid ReportId { get; set; }
    }

}

