using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Api.Common.Extensions;

internal static class DomainExceptionExtensions
{
    internal static int MapToStatusCode(this DomainException ex)
    {
        return ex switch
        {
            DomainException.NotFound => StatusCodes.Status404NotFound,
            DomainException.Validation => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status400BadRequest,
        };
    }
}
