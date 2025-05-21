using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Labb3.Models
{
    public class PersonInterest
    {
        //[Key]
        public int Id { get; set; }

        public int PersonID { get; set; }
        public Person Persons { get; set; } = null!;

        public int InterestID { get; set; }
        public Interest Interests { get; set; } = null!;


        //Reference navigation property and for the other obove 
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public ICollection<Link>? Links { get; set; }

    }
}
