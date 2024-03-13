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
            var person = new PersonDto
            {
                PersonId = 1,
                FirstName = "Simon",
                LastName = "Smith",
                Status = "A"
            };

            return Ok(person);
        }


        [HttpPut]
        public IActionResult PutPerson(PersonDto person)
        {
            person.FirstName = "Andrew";
            person.LastName = "Mayers";

            return Ok("Person updated successfully: " + person.FirstName + " " + person.LastName);
        }


        [HttpDelete]
        public IActionResult DeletePerson(int personId)
        {
            var activePerson = new PersonDto
            {
                PersonId = 2,
                FirstName = "Bradley",
                LastName = "Cooper",
                Status = "A"
            };

            activePerson.Status = "D";

            return Ok("Person: " + activePerson.FirstName + " " + activePerson.LastName + " was successfully deleted");
        }

        [HttpPost]
        public IActionResult PostPerson(PersonDto person)
        {
            var newPerson = new PersonDto
            {
                PersonId = 2,
                FirstName = "Brad",
                LastName = "Pitt",
                Status = "A"
            };
            return Ok("Person created successfully: " + newPerson.FirstName + " " + newPerson.LastName);
        }
    }
}