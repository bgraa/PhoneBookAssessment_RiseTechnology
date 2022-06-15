using Microsoft.AspNetCore.Mvc;
using PhoneBookAssessment.ContactAPI.Models;
using PhoneBookAssessment.ContactAPI.Repositories.Common;
using PhoneBookAssessment.ContactAPI.Services.Common;

namespace PhoneBookAssessment.ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IPersonContactInformationService _personContactInformationService;

        public ReportController(IPersonService personService,
                                 IPersonContactInformationService personContactInformationService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _personContactInformationService = personContactInformationService ?? throw new ArgumentNullException(nameof(personContactInformationService));
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            var result = await _personService.GetPersonByIdAsync(id);

            if (!result.IsValid)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

         
    }
}