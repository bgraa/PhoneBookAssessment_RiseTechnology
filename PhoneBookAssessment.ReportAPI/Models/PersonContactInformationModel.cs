namespace PhoneBookAssessment.ReportAPI.Models
{
    public class PersonContactInformationModel : BaseModel
    { 
        public string? InformationContent { get; set; }

        public string? InformationTypeDescription { get; set; }

        public Guid PersonId { get; set; }
    }
}