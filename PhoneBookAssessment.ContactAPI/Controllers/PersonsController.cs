using Microsoft.AspNetCore.Mvc;
using PhoneBookAssessment.ContactAPI.Models;
using PhoneBookAssessment.ContactAPI.Repositories.Common;
using PhoneBookAssessment.ContactAPI.Services.Common;

namespace PhoneBookAssessment.ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IPersonContactInformationService _personContactInformationService;

        public PersonsController(IPersonService personService,
                                 IPersonContactInformationService personContactInformationService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _personContactInformationService = personContactInformationService ?? throw new ArgumentNullException(nameof(personContactInformationService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var result = await _personService.GetAllPersonsAsync();

            return Ok(result);
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

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetPersonByIdWithDetail(Guid id)
        {
            var result = await _personService.GetPersonByIdWithDetailAsync(id);

            return Ok(result.Data);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonModel person)
        {
            try
            {
                var response = await _personService.CreatePersonAsync(person);
                if (!response.IsValid)
                {
                    return BadRequest(response.Message);
                }

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonById(Guid id)
        {
            try
            {
                var response = await _personService.DeletePerson(id);
                if (!response.IsValid)
                {
                    return BadRequest(response.Message);
                }
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost("{personId}/contact-information")]
        public async Task<IActionResult> AddContactInformation([FromRoute] Guid personId, [FromBody] CreatePersonContactInformationModel contactInformationModel)
        {
            try
            {
                var result = await _personContactInformationService.AddContactInformation(personId, contactInformationModel);

                if (!result.IsValid)
                {
                    return BadRequest(result.Message);
                }

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("contact-informations/{id}")]
        public async Task<IActionResult> DeleteContactInformation([FromRoute] Guid id)
        {
            var result = await _personContactInformationService.DeleteContactInformation(id);

            if (!result.IsValid)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [HttpGet("contact-informations")]
        public async Task<IActionResult> GetAllContactInformations()
        {
            var result = await _personContactInformationService.GetAllContactInformations();

            if(!result.IsValid)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
    }
}