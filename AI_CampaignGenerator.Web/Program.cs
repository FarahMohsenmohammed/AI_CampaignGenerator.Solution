
using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Presistence.Data.DataSeed;
using AI_CampaignGenerator.Presistence.Data.DbContexts;
using AI_CampaignGenerator.Presistence.Data.Repositories;
using AI_CampaignGenerator.Services;
using AI_CampaignGenerator.ServicesAbstraction;
using AI_CampaignGenerator.Web.Extentions;
using Microsoft.EntityFrameworkCore;

namespace AI_CampaignGenerator.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AICampaignGeneratorDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDataInitializer, DataInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(ServicesAssemplyReference));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IImageStorageService, ImageStorageService>();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IAIGeneratedContentService, AIGeneratedContentService>();


            var app = builder.Build();
            #region Dataseed
            //you can call the seed from the return of the migrate (app)

            await app.MigrateDatabaseAsync();
            await app.SeedDatabaseAsync();

            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            

            app.UseHttpsRedirection();
            //images
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
