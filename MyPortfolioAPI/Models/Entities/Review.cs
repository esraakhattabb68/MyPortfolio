namespace MyPortfolioAPI.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string? ImageUrl { get; set; }
    }
}
