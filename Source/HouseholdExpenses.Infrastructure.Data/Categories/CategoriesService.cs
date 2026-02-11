using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HouseholdExpenses.Application.Categories.Repositories;
using HouseholdExpenses.Infrastructure.Data.Categories.Repositories;

namespace HouseholdExpenses.Infrastructure.Data.Categories;

public static class CategoriesService
{
    public static IServiceCollection AddCategoriesInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper((configuration) =>
        {
            configuration.AddProfile<CategoriesProfile>();
        });

        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
