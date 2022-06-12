using Microsoft.AspNetCore.Mvc;
using PhoneBookAssessment.ContactAPI.Repositories.Common;

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
    }
}