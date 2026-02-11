using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HouseholdExpenses.Application.People.Repositories;
using HouseholdExpenses.Infrastructure.Data.People.Repositories;

namespace HouseholdExpenses.Infrastructure.Data.People;

public static class PeopleService
{
    public static IServiceCollection AddPeopleInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper((configuration) =>
        {
            configuration.AddProfile<PeopleProfile>();
        });

        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }
}
