using System.Reflection;
using Microsoft.EntityFrameworkCore;
using HouseholdExpenses.Infrastructure.Data.Categories.Models;
using HouseholdExpenses.Infrastructure.Data.People.Models;
using HouseholdExpenses.Infrastructure.Data.Transactions.Models;

namespace HouseholdExpenses.Infrastructure.Data.Common;

public sealed class SqliteDbContext(DbContextOptions<SqliteDbContext> options) : DbContext(options)
{
    public DbSet<CategoryModel> Categories { get; init; }

    public DbSet<PersonModel> People { get; init; }

    public DbSet<TransactionModel> Transactions { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
