using Evg.Components.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Evg.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private string _propertyName;

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
            validateName(person.FirstName, nameof(person.FirstName));
            validateName(person.LastName, nameof(person.LastName));

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
                _propertyName = nameof(person.PersonId);
                ModelState.AddModelError(_propertyName, $"{_propertyName} must be more than 0");
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            person.PersonId = 2;

            return Ok("PersonId: " + person.PersonId + " was successfully deleted");
        }


        private void validateName(string name, string propertyName)
        {
            if (!char.IsUpper(name[0]))
            {
                ModelState.AddModelError(propertyName, $"{propertyName} must start with a capital letter.");
            }

            if (Regex.IsMatch(name, @"[A-Z]{2,}"))
            {
                ModelState.AddModelError(propertyName, $"{propertyName} should not contain two or more capital letters.");
            }

            if (name.Any(char.IsDigit))
            {
                ModelState.AddModelError(propertyName, $"{propertyName} should not contain numbers.");
            }

            if (name.Any(c => !char.IsLetter(c)))
            {
                ModelState.AddModelError(propertyName, $"{propertyName} should contain only letters.");
            }

            if (name.Contains(" "))
            {
                ModelState.AddModelError(propertyName, $"{propertyName} should not contain spaces.");
            }

            if (name.Length < 2)
            {
                ModelState.AddModelError(propertyName, $"{propertyName} should contain 2 or more letters.");
            }
        }
    }
}