namespace HouseholdExpenses.Infrastructure.Data.Common;

public interface IUnitOfWork : IDisposable
{
    Task Complete(CancellationToken cancellationToken = default);
}
