using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.DTOs;
using MyPortfolioAPI.Interfaces;
using MyPortfolioAPI.Models.DbContexts;

namespace MyPortfolioAPI.Services
{
    public class HireService : IHireService
    {
        private readonly PortfolioDbContext _context;

        public HireService(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<HireMeDto> GetWhatsAppLinkAsync()
        {
            var social = await _context.SocilaMedias.FirstOrDefaultAsync();

            if (social == null || string.IsNullOrEmpty(social.WhatsApp))
                return null;

            string number = social.WhatsApp;

            string cleanNumber = number.Replace(" ", "").Replace("+", "");

            string finalUrl = cleanNumber.StartsWith("http")
                ? cleanNumber
                : $"https://wa.me/{cleanNumber}";

            return new HireMeDto
            {
                WhatsApp = finalUrl
            };
        }
    }
}
