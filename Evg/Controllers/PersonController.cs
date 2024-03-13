using Evg.Components.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evg.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get([Required] PersonIdDto person)
        {
            person = new PersonDto
            {
                PersonId = 1,
                FirstName = "Simon",
                LastName = "Smith",
                Status = "A"
            };

            return Ok(person);
        }


        [HttpPost]
        public IActionResult Edit([Required] PersonDto person)
        {
            person.FirstName = "Andrew";
            person.LastName = "Mayers";

            return Ok("Person updated successfully: " + person.FirstName + " " + person.LastName);
        }


        [HttpPost]
        public IActionResult Delete([Required] PersonIdDto person)
        {
            person.PersonId = 2;
          

            return Ok("PersonId: " + person.PersonId + " was successfully deleted");
        }

        [HttpPost]
        public IActionResult Post([Required] PersonDto person)
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