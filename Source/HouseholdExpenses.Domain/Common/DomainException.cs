namespace HouseholdExpenses.Domain.Common;

public abstract class DomainException(string message, string code) : Exception(message)
{
    public readonly string Code = code;

    public sealed class NotFound(string message) : DomainException(message, "RESOURCE_NOT_FOUND");
    public sealed class Validation(string message) : DomainException(message, "BUSINESS_RULE_VIOLATION");
}
