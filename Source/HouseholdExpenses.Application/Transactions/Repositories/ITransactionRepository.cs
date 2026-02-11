using HouseholdExpenses.Domain.Transactions.Entities;

namespace HouseholdExpenses.Application.Transactions.Repositories;

public interface ITransactionRepository
{
    Task<Transaction?> GetById(uint id);

    Task<IReadOnlyCollection<Transaction>> GetAll();

    Task<Transaction> Add(Transaction transaction);
}
