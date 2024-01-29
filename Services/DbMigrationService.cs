using Microsoft.EntityFrameworkCore;
using Survey.Api.Cloud.Core.DataBase.DBContext;

namespace Survey.Api.Cloud.Core.Services
{
    public static class DbMigrationService
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                SurveyDBContext dbContext = scope.ServiceProvider.GetRequiredService<SurveyDBContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
