using System;
using PhoneBookAssessment.ReportAPI.Models.Enums;

namespace PhoneBookAssessment.ReportAPI.Models
{
	public class ReportModel : BaseModel
	{
		public DateTime RequestedDate { get; set; } 

        public string? ReportStatusDescription { get; set; }
    }
}

