using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using HouseholdExpenses.Application.Categories;

namespace HouseholdExpenses.Application;

public static class Bootstrap
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper((configuration) =>
        {
            configuration.AddProfile<CategoriesProfile>();
        });

        services.AddMediatR((configuration) =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Bootstrap).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(Bootstrap).Assembly);

        return services;
    }
}
