using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AI_CampaignGenerator.Web.Extentions
{
    public static class WebApplicationRegistiration
    {
        //creatings two scopes achives thhe first solid priciple of single responsibility each method is reponciple of one task
        //and also acheives the second priciple of open closed principle if you added any thing new you can add newmethod cause the two methods are closed for modification
        public static async Task<WebApplication> MigrateDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();//async for the operations inside the scopeitself to not get blocked
            //to get the bending migration you need an objfrom dbcontext
            var dbContextservice = scope.ServiceProvider.GetRequiredService<AICampaignGeneratorDbContext>();
            var PendingMigrations = await dbContextservice.Database.GetPendingMigrationsAsync();
            if (PendingMigrations.Any())
                await dbContextservice.Database.MigrateAsync();

            return app;
        }
        public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var DataInitializerService = scope.ServiceProvider.GetRequiredService<IDataInitializer>();
            await DataInitializerService.InitializeAsync();
            return app;

        }
    }
}
