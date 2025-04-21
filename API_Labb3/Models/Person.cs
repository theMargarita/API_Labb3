using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; } = string.Empty;
        public string? Lastname { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }

        //Foreign key
        public int InterestID { get; set; }

        //Navigation
        public ICollection<PersonIntereset>? PersonInterests { get; set; }

    }
}
