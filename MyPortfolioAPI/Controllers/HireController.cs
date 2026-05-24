using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioAPI.Interfaces;

namespace MyPortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HireMeController : ControllerBase
    {
        private readonly IHireService _hireService;

        public HireMeController(IHireService hireService)
        {
            _hireService = hireService;
        }

        [HttpGet("HireMe")]
        public async Task<IActionResult> GetWhatsAppUrl()
        {
            var result = await _hireService.GetWhatsAppLinkAsync();

            if (result == null)
                return NotFound(new { message = "WhatsApp Number Not Found." });

            return Ok(result);
        }
    }
}
