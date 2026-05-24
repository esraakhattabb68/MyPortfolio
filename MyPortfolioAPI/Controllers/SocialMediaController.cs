using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioAPI.Interfaces;

namespace MyPortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialService;

        public SocialMediaController(ISocialMediaService socialService)
        {
            _socialService = socialService;
        }

        [HttpGet("SocialMediaLinks")]
        public async Task<IActionResult> GetAllSocialLinks()
        {
            var links = await _socialService.GetSocialLinksAsync();

            if (links == null)
                return NotFound("No Social Media Links Found.");

            return Ok(links);
        }
    }
}
