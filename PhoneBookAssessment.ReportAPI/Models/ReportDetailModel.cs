using System;
using PhoneBookAssessment.ReportAPI.Models.Enums;

namespace PhoneBookAssessment.ReportAPI.Models
{
	public class ReportDetailModel : BaseModel
	{
        public string? Location { get; set; }

        public int PersonsCount { get; set; }

        public int PhoneNumbersCount { get; set; } 
    }
}

