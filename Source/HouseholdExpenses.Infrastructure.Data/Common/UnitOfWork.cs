using Microsoft.EntityFrameworkCore.Storage;
using HouseholdExpenses.Application.Common;

namespace HouseholdExpenses.Infrastructure.Data.Common;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly SqliteDbContext DbContext;

    private IDbContextTransaction? CurrentTransaction;

    private bool Disposed;

    public UnitOfWork(SqliteDbContext dbContext)
    {
        DbContext = dbContext;

        CurrentTransaction = DbContext.Database.BeginTransaction();
    }
    public async Task Start(CancellationToken cancellationToken)
    {
        if (CurrentTransaction is not null)
        {
            return;
        }

        CurrentTransaction = await DbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task Complete(CancellationToken cancellationToken)
    {
        if (CurrentTransaction is null)
        {
            return;
        }

        try
        {
            await DbContext.SaveChangesAsync(cancellationToken);
            await CurrentTransaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await CurrentTransaction.RollbackAsync(cancellationToken);
            throw;
        }
        finally
        {
            CurrentTransaction.Dispose();
            CurrentTransaction = null;
        }
    }

    public void Dispose()
    {
        if (!Disposed)
        {
            CurrentTransaction?.Dispose();
            Disposed = true;
        }


        GC.SuppressFinalize(this);
    }
}
