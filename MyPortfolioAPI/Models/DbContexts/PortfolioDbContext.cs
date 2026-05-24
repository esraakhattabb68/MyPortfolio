using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.Models.Entities;

namespace MyPortfolioAPI.Models.DbContexts
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
            
        }

        #region DbSets

        public DbSet<Cv> Cvs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SocialMedia> SocilaMedias { get; set; }

        #endregion
    }
}
