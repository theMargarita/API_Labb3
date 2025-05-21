using API_Labb3.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Labb3.Models.DTOs
{
    public class PersonDTO
    {
        //public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        //public string Firstname { get; internal set; }
        public string? LastName { get; set; }
        //public string? Lastname { get; internal set; }
        public int Age { get; set; }

        [Phone]
        public int Phone { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public ICollection<PersonInterest>? PersonInterests { get; set; }
    }
}
