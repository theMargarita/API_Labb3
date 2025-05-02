using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models.DTOs
{
    public class CreateLinkDTO
    {
        public int PersonInterestId { get; set; }

        [Url]
        public string? URL { get; set; }

        //navigation prop
        public PersonInterest? PersonInterest { get; set; } 
    }
}
