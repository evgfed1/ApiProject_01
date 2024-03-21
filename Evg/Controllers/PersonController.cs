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
        private string propertyName;

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
                propertyName = nameof(person.PersonId);
                ModelState.AddModelError(propertyName, $"{propertyName} must be more than 0");
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            person.PersonId = 2;

            return Ok("PersonId: " + person.PersonId + " was successfully deleted");
        }


        private void validateName(string _name, string _propertyName)
        {
            if (!char.IsUpper(_name[0]))
            {
                ModelState.AddModelError(_propertyName, $"{_propertyName} must start with a capital letter.");
            }

            if (Regex.IsMatch(_name, @"[A-Z]{2,}"))
            {
                ModelState.AddModelError(_propertyName, $"{_propertyName} should not contain two or more capital letters.");
            }

            if (_name.Any(char.IsDigit))
            {
                ModelState.AddModelError(_propertyName, $"{_propertyName} should not contain numbers.");
            }

            if (_name.Any(c => !char.IsLetter(c)))
            {
                ModelState.AddModelError(_propertyName, $"{_propertyName} should contain only letters.");
            }

            if (_name.Contains(" "))
            {
                ModelState.AddModelError(_propertyName, $"{_propertyName} should not contain spaces.");
            }

            if (_name.Length < 2)
            {
                ModelState.AddModelError(_propertyName, $"{_propertyName} should contain 2 or more letters.");
            }
        }
    }
}