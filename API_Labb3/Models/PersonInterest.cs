using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models
{
    public class PersonInterest
    {
        [Key]
        public int Id { get; set; }

        public int PersonID { get; set; }
        public Person Persons { get; set; } = null!;

        public int InterestID { get; set; }
        public Interest Interests { get; set; } = null!;


        //Reference navigation property and fro the other obove 
        public ICollection<Link>? Links { get; set; }

    }
}
