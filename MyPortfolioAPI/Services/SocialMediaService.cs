using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.DTOs;
using MyPortfolioAPI.Interfaces;
using MyPortfolioAPI.Models.DbContexts;

namespace MyPortfolioAPI.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly PortfolioDbContext _context;

        public SocialMediaService(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<SocialLinksDto> GetSocialLinksAsync()
        {
            var social = await _context.SocilaMedias.FirstOrDefaultAsync();

            if (social == null) return null;

            return new SocialLinksDto
            {
                Facebook = social.Facebook,
                Instagram = social.Instagram,
                LinkedIn = social.LinkedIn,
                GitHub = social.GitHub
            };
        }
    }
}
