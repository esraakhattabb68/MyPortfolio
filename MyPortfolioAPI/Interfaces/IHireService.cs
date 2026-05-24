using MyPortfolioAPI.DTOs;

namespace MyPortfolioAPI.Interfaces
{
    public interface IHireService
    {
        Task<HireMeDto> GetWhatsAppLinkAsync();
    }
}
