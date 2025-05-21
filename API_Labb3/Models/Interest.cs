using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Labb3.Models
{
    public class Interest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }= string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }

        //Navigation 
        [JsonIgnore]
        public ICollection<PersonInterest>? PersonInterests { get; set; }
    }
}