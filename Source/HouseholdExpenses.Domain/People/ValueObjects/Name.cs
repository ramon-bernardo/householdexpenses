using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Domain.People.ValueObjects;

public record Name
{
    public const int MAX_LENGTH = 200;

    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException.Validation("Name is required.");
        }

        if (value.Length > MAX_LENGTH)
        {
            throw new DomainException.Validation($"Name max length is {MAX_LENGTH}.");
        }

        return new Name(value);
    }

    public static implicit operator string(Name name)
    {
        return name.Value;
    }
}
