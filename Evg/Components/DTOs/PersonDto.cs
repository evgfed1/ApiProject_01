namespace Evg.Components.DTOs
{
    public class PersonIdDto
    {
        public int PersonId { get; set; }
    }

    public class PersonDto : PersonIdDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public required string Status { get; set; }
    }
}