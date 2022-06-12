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

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonModel person)
        {
            try
            {
                var response = await _personService.CreatePersonAsync(person).ConfigureAwait(false);
                if(!response.IsValid)
                {
                    return BadRequest(response.Message);
                }

                return Ok(response.Data);
            }
            catch (Exception)
            {   
                throw;
            } 
        }
    }
}