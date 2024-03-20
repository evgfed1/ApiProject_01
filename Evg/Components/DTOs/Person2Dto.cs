using System.ComponentModel.DataAnnotations;

namespace Evg.Components.DTOs
{
    public class Person2IdDto
    {
        [Required(ErrorMessage = "PersonId is required")]
        public int? PersonId { get; set; }
    }

    public class Person2Dto : Person2IdDto
    {
        [Required(ErrorMessage = "First name is required")]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "First name must start with a capital letter and contain only letters. First name should contain more than 1 letter.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "Last name must start with a capital letter and contain only letters. Last name should contain more than 1 letter.")]
        public string LastName { get; set; }

        [Required]
        public string Status { get; set; }
    }

}
