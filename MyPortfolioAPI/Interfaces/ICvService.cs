using MyPortfolioAPI.Models.Entities;
using System.Xml.Linq;

namespace MyPortfolioAPI.Interfaces
{
    public interface ICvService
    {
        Task<byte[]> GetCvFileAsync(int id);
        Task<Cv> GetCvDetailsAsync(int id);
    }
}
