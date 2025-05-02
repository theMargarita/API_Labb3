namespace API_Labb3.Models.DTOs
{
    public class CreatePersonRequest
    {
        //way of sending data between server
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public int Age { get; set; }
        public int MyProperty { get; set; }
        public int Phone { get; set; }

        //
        public int[]? PersonInterestsIds { get; set; }

        //no navigation property
    }
}
