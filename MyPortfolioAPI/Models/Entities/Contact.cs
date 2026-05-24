using MyPortfolioAPI.Enums;

namespace MyPortfolioAPI.Models.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? TimeLine { get; set; }
        public string? ProjectDetails { get; set; }
        public ContactUs.ServiceOfInterest ServiceOfInterest { get; set; }
    }
}
