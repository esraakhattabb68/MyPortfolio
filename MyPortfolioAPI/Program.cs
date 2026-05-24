
using Microsoft.EntityFrameworkCore;
using MyPortfolioAPI.Data.DataSeeders;
using MyPortfolioAPI.Interfaces;
using MyPortfolioAPI.Models.DbContexts;
using MyPortfolioAPI.Models.Entities;
using MyPortfolioAPI.Services;
using System.Xml.Linq;

namespace MyPortfolioAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<PortfolioDbContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            #endregion

            #region Dependency Injection

            builder.Services.AddScoped<ICvService, CvService>();


            #endregion

            #region CORS

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            #endregion

            var app = builder.Build();


           
            #region Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();


            #region Data Seeding

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PortfolioDbContext>();

                DataSeeding.SeedData<Cv>(context, "CvData.json");
                DataSeeding.SeedData<SocialMedia>(context, "SocialMedia.json");
                DataSeeding.SeedData<Category>(context, "Categories.json");
                DataSeeding.SeedData<Project>(context, "Projects.json");
                DataSeeding.SeedData<Review>(context, "Reviews.json");


            } 

            #endregion

            #endregion

            app.Run();
        }
    }
}
