namespace MyPortfolioAPI.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Project> Projects { get; set; }
    }
}
