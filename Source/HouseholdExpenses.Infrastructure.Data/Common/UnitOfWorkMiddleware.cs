using Microsoft.AspNetCore.Http;

namespace HouseholdExpenses.Infrastructure.Data.Common;

public class UnitOfWorkMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
    {
        await next(context);

        await unitOfWork.Complete();
    }
}
