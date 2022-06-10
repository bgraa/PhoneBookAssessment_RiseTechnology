using Microsoft.AspNetCore.Mvc;
using PhoneBookAssessment.ContactAPI.Repositories.Interfaces;

namespace PhoneBookAssessment.ContactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeoplesController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeoplesController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_peopleRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = _peopleRepository.Get(id);

            if (article is null)
                return NotFound();

            return Ok(article);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedId = _peopleRepository.Delete(id);

            if (deletedId == 0)
                return NotFound();

            return NoContent();
        }
    }
}