using MyPortfolioAPI.DTOs;

namespace MyPortfolioAPI.Interfaces
{
    public interface ISocialMediaService
    {
        Task<SocialLinksDto> GetSocialLinksAsync();

    }
}
