using Microsoft.EntityFrameworkCore;
using TravelAgency.Context;

namespace TravelAgency.Service.Configuration;

public static class DbContextConfiguration
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TravelAgencyDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }

    public static IApplicationBuilder UseDataBase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TravelAgencyDbContext>();

        // применяет последние миграции и создаёт БД, если её ещё нет
        context.Database.Migrate();

        return app;
    }
}
