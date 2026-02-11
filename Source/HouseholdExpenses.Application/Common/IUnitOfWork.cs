namespace HouseholdExpenses.Application.Common;

public interface IUnitOfWork : IDisposable
{
    Task Start(CancellationToken cancellationToken = default);

    Task Complete(CancellationToken cancellationToken = default);
}
