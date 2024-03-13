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
        public IActionResult Get(PersonIdDto person)
        {
            if (person.PersonId <= 0)
            {
                ModelState.AddModelError("PersonId", "PersonId must be more than 0");
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

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
        public IActionResult Edit(PersonDto person)
        {
            if (!char.IsUpper(person.FirstName[0]) ||
                !char.IsUpper(person.LastName[0]) ||
                person.FirstName.Any(char.IsDigit) ||
                person.LastName.Any(char.IsDigit) ||
                person.FirstName.Any(c => !char.IsLetter(c)) ||
                person.LastName.Any(c => !char.IsLetter(c)) ||
                person.FirstName.Contains(" ") ||
                person.LastName.Contains(" "))
            {
                ModelState.AddModelError("", "First name and last name must start with a capital letter and should contain only letters.");
            }

            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            person.FirstName = "Andrew";
            person.LastName = "Mayers";

            return Ok("Person updated successfully: " + person.FirstName + " " + person.LastName);
        }


        [HttpPost]
        public IActionResult Delete([Required] PersonIdDto person)
        {
            if (person.PersonId <= 0)
            {
                ModelState.AddModelError("PersonId", "PersonId must be more than 0");
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            person.PersonId = 2;

            return Ok("PersonId: " + person.PersonId + " was successfully deleted");
        }
    }
}