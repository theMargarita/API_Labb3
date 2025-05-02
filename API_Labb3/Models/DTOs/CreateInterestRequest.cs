namespace API_Labb3.Models.DTOs
{
    public class CreateInterestRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
