using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HouseholdExpenses.Application.Transactions.Repositories;
using HouseholdExpenses.Infrastructure.Data.Transactions.Repositories;

namespace HouseholdExpenses.Infrastructure.Data.Transactions;

public static class TransactionsService
{
    public static IServiceCollection AddTransactionsInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper((configuration) =>
        {
            configuration.AddProfile<TransactionsProfile>();
        });

        services.AddScoped<ITransactionRepository, TransactionRepository>();

        return services;
    }
}
