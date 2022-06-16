using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PhoneBookAssessment.ReportAPI.Data.Entities;
using PhoneBookAssessment.ReportAPI.Models;
using PhoneBookAssessment.ReportAPI.Models.Enums;
using PhoneBookAssessment.ReportAPI.Repositories.Common;
using PhoneBookAssessment.ReportAPI.Services.Common;

namespace PhoneBookAssessment.ReportAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<Settings> _settings;
        private readonly IMessageService _messageService;

        public ReportService(IUnitOfWork unitOfWork,
                             IMapper mapper,
                             IHttpClientFactory httpClientFactory,
                             IOptions<Settings> settings,
                             IMessageService messageService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }

        public async Task<Guid> CreateReport()
        {
            try
            {
                var report = new Report
                {
                    RequestedDate = DateTime.UtcNow,
                    ReportStatus = ReportStatusType.Preparing
                };

                await _unitOfWork.ReportRepository.AddAsync(report);

                await _unitOfWork.SaveAsync();

                var enqueueMessage = _messageService.EnqueueMessage(report.Id.ToString());
                if (!enqueueMessage)
                {
                    throw new ArgumentException("The message could not be written to queue.");
                }



                return report.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task GenerateReportResponse(Guid id)
        {
            try
            {
                var report = await _unitOfWork.ReportRepository.GetByIdAsync(id);

                if (report == null)
                {
                    throw new ArgumentNullException("Report not found.");
                }

                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_settings.Value.ContactAPIUrl}/contact-informations");
                var responseRequest = await client.SendAsync(request);

                var responseStream = await responseRequest.Content.ReadAsStringAsync();
                var personContactInformations = JsonConvert.DeserializeObject<IEnumerable<PersonContactInformationModel>>(responseStream);
                 
                var reportDetail = personContactInformations?.Where(x => x.InformationTypeDescription == InformationTypes.Location.ToString()).Select(x => x.InformationContent).Distinct().Select(x => new ReportDetail
                {
                    ReportId = report.Id,
                    Location = x,
                    PersonsCount = personContactInformations.Where(y => y.InformationTypeDescription == InformationTypes.Location.ToString() && y.InformationContent == x).Count(),
                    PhoneNumbersCount = personContactInformations.Where(y => y.InformationTypeDescription == InformationTypes.Location.ToString() && personContactInformations.Where(y => y.InformationTypeDescription == InformationTypes.Phone.ToString() && y.InformationContent == x).Select(x => x.PersonId).Contains(y.PersonId)).Count()
                });
                 
                report.ReportStatus = ReportStatusType.Completed;

                await _unitOfWork.ReportDetailRepository.AddRangeAsync(reportDetail);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IReadOnlyList<ReportModel>> GetAllReports()
        {
            var reports = await _unitOfWork.ReportRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<ReportModel>>(reports);
        }

        public async Task<ReportResponseModel> GetReportDetail(Guid reportId)
        {
            try
            {

                var response = new ReportResponseModel();

                var report = await _unitOfWork.ReportRepository.GetByIdAsync(reportId);
                if (report != null)
                {
                    response.Report = _mapper.Map<ReportModel>(report);

                    var reportDetail = await _unitOfWork.ReportDetailRepository.FindAsync(x => x.ReportId == reportId);
                    if (reportDetail?.Count() > 0)
                    {
                        response.ReportDetailModels = new List<ReportDetailModel>();
                        response.ReportDetailModels.AddRange(_mapper.Map<IReadOnlyList<ReportDetailModel>>(reportDetail));
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}

