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
            if (!char.IsUpper(person.FirstName[0]) ||
                !char.IsUpper(person.LastName[0]) ||
                person.FirstName.Any(char.IsDigit) ||
                person.LastName.Any(char.IsDigit) ||
                person.FirstName.Any(c => !char.IsLetter(c)) ||
                person.LastName.Any(c => !char.IsLetter(c)) ||
                person.FirstName.Contains(" ") ||
                person.LastName.Contains(" ") ||
                person.FirstName.Length < 2 ||
                person.LastName.Length < 2)
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
        public IActionResult Edit3(Person2Dto person)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { Property = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) })
                    .ToList();

                return BadRequest(errors);
            }

            person.FirstName = "Andrew";
            person.LastName = "Mayers";

            return Ok("Person updated successfully: " + person.FirstName + " " + person.LastName);
        }




        [HttpPost]
        public IActionResult Edit2(Person2Dto person)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            person.FirstName = "Andrew";
            person.LastName = "Mayers";

            return Ok("Person updated successfully: " + person.FirstName + " " + person.LastName);
        }




        [HttpPost]
        public IActionResult Edit1(PersonDto person)
        {
            if (!char.IsUpper(person.FirstName[0]))
            {
                ModelState.AddModelError("FirstName", "First name must start with a capital letter.");
            }

            if (!char.IsUpper(person.LastName[0]))
            {
                ModelState.AddModelError("LastName", "Last name must start with a capital letter.");
            }

            if (Regex.IsMatch(person.FirstName, @"[A-Z]{2,}"))
            {
                ModelState.AddModelError("FirstName", "First name should not contain two or more capital letters.");
            }

            if (Regex.IsMatch(person.LastName, @"[A-Z]{2,}"))
            {
                ModelState.AddModelError("LastName", "Last name should not contain two or more capital letters.");
            }

            if (person.FirstName.Any(char.IsDigit))
            {
                ModelState.AddModelError("FirstName", "First name should not contain numbers.");
            }

            if (person.LastName.Any(char.IsDigit))
            {
                ModelState.AddModelError("LastName", "Last name should not contain numbers.");
            }

            if (person.FirstName.Any(c => !char.IsLetter(c)))
            {
                ModelState.AddModelError("FirstName", "First name should contain only letters..");
            }

            if (person.LastName.Any(c => !char.IsLetter(c)))
            {
                ModelState.AddModelError("LastName", "Last name should contain only letters..");
            }

            if (person.FirstName.Contains(" "))
            {
                ModelState.AddModelError("FirstName", "First name should not contain spaces.");
            }

            if (person.LastName.Contains(" "))
            {
                ModelState.AddModelError("LastName", "Last name should not contain spaces.");
            }

            if (person.FirstName.Length < 2)
            {
                ModelState.AddModelError("FirstName", "First name should contain 2 or more letters.");
            }

            if (person.LastName.Length < 2)
            {
                ModelState.AddModelError("LastName", "Last name should contain 2 or more letters..");
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





        [HttpPost]
        public IActionResult Edit4(PersonDto person)
        {
            ValidateName(person.FirstName, "FirstName");
            ValidateName(person.LastName, "LastName");

            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            person.FirstName = "Andrew";
            person.LastName = "Mayers";

            return Ok("Person updated successfully: " + person.FirstName + " " + person.LastName);
        }


        private void ValidateName(string name, string propertyName)
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