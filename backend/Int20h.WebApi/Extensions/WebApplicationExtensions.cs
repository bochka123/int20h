using Int20h.DAL.Interfaces;

namespace Int20h.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static void SeedDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var migrationHelper = scope.ServiceProvider.GetRequiredService<IMigrationHelper>();
            migrationHelper.Migrate();
        }
    }
}
