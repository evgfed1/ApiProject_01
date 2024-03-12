using Evg.Components.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Evg.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPerson()
        {
            var PersonDto = new PersonDto
            {
                FirstName = "Simon",
                LastName = "Smith",
                PersonId = 1
            };

            return Ok(PersonDto);
        }



        [HttpPost]
        public IActionResult EditPerson()
        {
            var PersonDto = new PersonDto
            {
                FirstName = "",
                LastName = "",
                PersonId = null
            };

            return Ok(PersonDto);
        }
    }

}

