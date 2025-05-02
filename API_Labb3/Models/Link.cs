using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }

        [Url]
        public string URL { get; set; } = string.Empty;

        public int PersonInterestId { get; set; }


        //navigation properties
        public PersonInterest? PersonInterests { get; set; }

    }
}
