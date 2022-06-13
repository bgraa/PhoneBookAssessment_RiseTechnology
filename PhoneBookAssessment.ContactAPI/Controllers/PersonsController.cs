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
        public PersonsController(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            var result = await _personService.GetAllPersonsAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonByIdWithDetail(Guid id)
        {
            var result = await _personService.GetPersonByIdWithDetailAsync(id);

            return Ok(result);
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
                await _personService.DeletePerson(id);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}