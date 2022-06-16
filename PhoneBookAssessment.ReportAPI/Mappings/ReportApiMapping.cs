using AutoMapper;
using PhoneBookAssessment.ReportAPI.Data.Entities;
using PhoneBookAssessment.ReportAPI.Models;

namespace PhoneBookAssessment.ContactAPI.Mappings
{
    public class ReportApiMapping : Profile
    {
        public ReportApiMapping()
        { 
            CreateMap<Report, ReportModel>()
            .ForMember(dst => dst.ReportStatusDescription, opt => opt.MapFrom(src => src.ReportStatus.ToString()))
            .ReverseMap();

            CreateMap<ReportDetail, ReportDetailModel>(); 
        }
    }
}