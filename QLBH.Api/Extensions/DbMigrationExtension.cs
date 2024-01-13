using Microsoft.EntityFrameworkCore;
using QLBH.Models;
using QLBH.Models.Seeding;

namespace QLBH.Api.Extensions
{
    public static class DbMigrationExtension
    {
        public static void UserMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
        }
        public static void UserDataSeeding(this IApplicationBuilder app, bool isDevelopment = false)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                var config = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                DataSeeding.DevelopementSeeding(context, config);
            }
        }
    }
}
