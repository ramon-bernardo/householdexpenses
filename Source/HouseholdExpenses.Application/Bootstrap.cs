using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using HouseholdExpenses.Application.Categories;
using HouseholdExpenses.Application.People;

namespace HouseholdExpenses.Application;

public static class Bootstrap
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper((configuration) =>
        {
            configuration.AddProfile<CategoriesProfile>();
            configuration.AddProfile<PeopleProfile>();
        });

        services.AddMediatR((configuration) =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Bootstrap).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(Bootstrap).Assembly);

        return services;
    }
}
