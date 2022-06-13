using Microsoft.AspNetCore.Mvc;
using PhoneBookAssessment.ReportAPI.Interface;

namespace PhoneBookAssessment.ReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
         private readonly IMessageService _messageService;

        public ReportsController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult CreateReport()
        {
            try
            {
                var response = _messageService.EnqueueMessage("test");

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}