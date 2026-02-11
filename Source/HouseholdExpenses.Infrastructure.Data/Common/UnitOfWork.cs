using Microsoft.EntityFrameworkCore.Storage;

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

    public async Task Complete(CancellationToken cancellationToken = default)
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