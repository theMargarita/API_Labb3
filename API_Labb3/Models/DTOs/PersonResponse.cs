using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Labb3.Models.DTOs
{
    public class PersonResponse
    {
        public String FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public int Age { get; set; }

        [Phone]
        public int Phone { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<PersonInterest>? PersonInterests { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Link? Links { get; set; } 
    }
}
