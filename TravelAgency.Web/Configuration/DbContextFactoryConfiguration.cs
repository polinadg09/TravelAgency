using Microsoft.EntityFrameworkCore;
using TravelAgency.Infrastructure.Data;

namespace TravelAgency.Web.Configuration;

public static class DbContextFactoryConfiguration
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<TravelAgencyDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped);

        return services;
    }

    public static IApplicationBuilder UseDataBase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<TravelAgencyDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); // применяет последние миграции и создаёт БД, если её нет

        return app;
    }
}
