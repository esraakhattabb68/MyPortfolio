using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.Interfaces;
using MyPortfolioAPI.Models.DbContexts;
using MyPortfolioAPI.Models.Entities;
using System.Xml.Linq;

namespace MyPortfolioAPI.Services
{
    public class CvService : ICvService
    {
        private readonly PortfolioDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CvService(PortfolioDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Cv> GetCvDetailsAsync(int id)
        {
            return await _context.Cvs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<byte[]> GetCvFileAsync(int id)
        {
            var cv = await GetCvDetailsAsync(id);
            if (cv == null) return null;

            string fileName = Path.GetFileName(cv.FilePath);
            string absolutePath = Path.Combine(_webHostEnvironment.WebRootPath, "CvData", fileName);

            if (!File.Exists(absolutePath))
                return null;

            return await File.ReadAllBytesAsync(absolutePath);
        }
    }
}
