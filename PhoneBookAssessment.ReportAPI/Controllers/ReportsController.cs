using Microsoft.AspNetCore.Mvc;
using PhoneBookAssessment.ReportAPI.Services.Common;

namespace PhoneBookAssessment.ReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
         private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
        }
         

        [HttpPost] 
        public async Task<IActionResult> CreateReport()
        {
            try
            {
                var result = await _reportService.CreateReport();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllReports()
        {
            try
            { 
                var result = await _reportService.GetAllReports();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}/detail")] 
        public async Task<IActionResult> GetReportDetail(Guid id)
        {
            try
            { 
                var result = await _reportService.GetReportDetail(id);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}