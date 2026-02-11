using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HouseholdExpenses.Application.Transactions.Repositories;
using HouseholdExpenses.Infrastructure.Data.Common;
using HouseholdExpenses.Infrastructure.Data.Transactions.Models;
using HouseholdExpenses.Domain.Transactions.Entities;

namespace HouseholdExpenses.Infrastructure.Data.Transactions.Repositories;

public sealed class TransactionRepository(
    SqliteDbContext dbContext,
    IMapper mapper
) : ITransactionRepository
{
    private readonly SqliteDbContext DbContext = dbContext;
    private readonly IMapper Mapper = mapper;

    public async Task<Transaction> Add(Transaction transaction)
    {
        var transactionModel = Mapper.Map<TransactionModel>(transaction);
        await DbContext.AddAsync(transactionModel);
        await DbContext.SaveChangesAsync();
        return Mapper.Map<Transaction>(transactionModel);
    }

    public async Task<Transaction?> GetById(uint id)
    {
        var transactionModel = await DbContext.Transactions
            .Where((transaction) => transaction.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return Mapper.Map<Transaction>(transactionModel);
    }

    public async Task<IReadOnlyCollection<Transaction>> GetAll()
    {
        var transactionModels = await DbContext.Transactions
            .AsNoTracking()
            .ToListAsync();

        return Mapper.Map<IReadOnlyCollection<Transaction>>(transactionModels);
    }
}
