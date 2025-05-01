using System.ComponentModel.DataAnnotations;

namespace API_Labb3.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string URL { get; set; } = string.Empty;

        public int PersonInterestId { get; set; }

        //foreign key 
        /*understand now (also knew it with sql)
        that you need both keys to connect, not only one key from the many to many table  */
        //public int PerInt_ID { get; set; } //personintrest id
        //public int IntPer_ID { get; set; } //intrest person id


        //navigation properties
        public PersonInterest? PersonInterests { get; set; }

    }
}
