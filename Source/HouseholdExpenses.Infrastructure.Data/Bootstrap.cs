using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HouseholdExpenses.Infrastructure.Data.Common;
using HouseholdExpenses.Infrastructure.Data.Categories;
using HouseholdExpenses.Infrastructure.Data.People;

namespace HouseholdExpenses.Infrastructure.Data;

public static class Bootstrap
{
    public static IApplicationBuilder UseUnitOfWork(this IApplicationBuilder app)
    {
        return app.UseMiddleware<UnitOfWorkMiddleware>();
    }

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<SqliteDbContext>((options) =>
        {
            var connectionString = configuration.GetConnectionString("SqliteConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'SqliteConnection' not found.");
            }

            options.UseSqlite(connectionString);
        });

        services.AddMediatR((configuration) =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Bootstrap).Assembly);
        });

        services
            .AddCategoriesInfrastructure()
            .AddPeopleInfrastructure();

        return services;
    }
}
