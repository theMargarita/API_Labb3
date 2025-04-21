namespace API_Labb3.Models
{
    public class PersonIntereset
    {
        public int PersonID { get; set; }
        public int InterestID { get; set; }

        //Reference navigation property
        public Person Persons { get; set; } = null!;
        public Interest Interests { get; set; } = null!;
    }
}
