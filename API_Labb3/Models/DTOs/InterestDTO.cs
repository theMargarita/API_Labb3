using API_Labb3.Models;
using System.Text.Json.Serialization;

namespace API_Labb3.Models.DTOs
{
    public class InterestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public ICollection<PersonInterest>? PersonInterests { get; set; }
        public List<string>? Link { get; set; } = new List<string>();
        public ICollection<LinkDTO> LinkDTO { get; set; } = [];
    }
}
