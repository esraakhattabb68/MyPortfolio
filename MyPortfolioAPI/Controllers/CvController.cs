using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioAPI.Interfaces;

namespace MyPortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ICvService _cvService;

        public CvController(ICvService cvService)
        {
            _cvService = cvService;
        }

        [HttpGet("DownloadCv/{id}")]
        public async Task<IActionResult> DownloadCv(int id)
        {
            var fileData = await _cvService.GetCvFileAsync(id);
            var metadata = await _cvService.GetCvDetailsAsync(id);

            if (fileData == null)
                return NotFound("CV file not found.");

            return File(fileData, "application/pdf", metadata.FileName);
        }
    }
}
