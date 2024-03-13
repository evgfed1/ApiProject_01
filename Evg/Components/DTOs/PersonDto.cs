using System.ComponentModel.DataAnnotations;

namespace Evg.Components.DTOs
{
    public class PersonIdDto
    {
        [Required]
        public int? PersonId { get; set; }
    }

    public class PersonDto : PersonIdDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public required string Status { get; set; }
    }
}