using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using HouseholdExpenses.Application.Categories;
using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.People;
using HouseholdExpenses.Application.Transactions;

namespace HouseholdExpenses.Application;

public static class Bootstrap
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper((configuration) =>
        {
            configuration.AddProfile<CategoriesProfile>();
            configuration.AddProfile<PeopleProfile>();
            configuration.AddProfile<TransactionsProfile>();
        });

        services.AddMediatR((configuration) =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Bootstrap).Assembly);

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(Bootstrap).Assembly);

        return services;
    }
}
