using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Labb3.Models
{
    public class Person
    {
        //[Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; } = string.Empty;
        public string? Lastname { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }

        //Navigation
        [JsonIgnore]
        public ICollection<PersonInterest>? PersonInterests { get; set; }

    }
}
