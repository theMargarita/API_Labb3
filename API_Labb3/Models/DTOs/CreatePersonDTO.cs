using API_Labb3.Models;
using System.Text.Json.Serialization;

namespace API_Labb3.Models.DTOs
{
    public class CreatePersonDTO
    {
        //public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public ICollection<PersonInterest>? PersonInterests { get; set; }
    }
}
