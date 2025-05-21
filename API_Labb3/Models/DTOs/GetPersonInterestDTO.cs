using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models.DTOs
{
    public class GetPersonInterestDTO
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<LinkDTO> URL { get; set; } = [];
        //public ICollection<InterestDTO> Interests { get; set; } = [];

    }
}
