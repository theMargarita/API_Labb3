using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Labb3.Models
{
    public class Link
    {
        //[Key]
        public int Id { get; set; }

        [Url]
        public string URL { get; set; } = string.Empty;

        public int PersonInterestId { get; set; }


        //navigation properties
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PersonInterest? PersonInterests { get; set; }

    }
}
