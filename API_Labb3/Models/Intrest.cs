using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models
{
    public class Intrest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }= string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }

        //Foreign key
        //public int PersonID { get; set; }

        //Navigation 
        public ICollection<PersonIntreset>? PersonIntrests { get; set; }
    }
}