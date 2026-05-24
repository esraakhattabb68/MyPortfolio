namespace MyPortfolioAPI.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property
        public Category Category { get; set; }
    }
}
