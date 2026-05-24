using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MyPortfolioAPI.Data.DataSeeders
{
    public class DataSeeding
    {
        public static void SeedData<T>(DbContext context, string fileName) where T : class
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "JsonFiles", fileName);

            if (!File.Exists(filePath)) return;

            if (context.Set<T>().Any()) return;

            var jsonData = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<List<T>>(jsonData, options);

            if (data != null && data.Any())
            {
                context.Set<T>().AddRange(data);
                context.SaveChanges();
            }
        }
    }
}
