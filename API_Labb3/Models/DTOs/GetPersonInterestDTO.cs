using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models.DTOs
{
    public class GetPersonInterestDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }

        public ICollection<InterestDTO> Interests { get; set; } = [];
        public IEnumerable<LinkDTO> LinkPerson { get; set; }

    }
}
