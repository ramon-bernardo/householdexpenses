using HouseholdExpenses.Domain.Categories;
using HouseholdExpenses.Domain.Categories.Enums;
using HouseholdExpenses.Domain.Common;
using HouseholdExpenses.Domain.People.Entities;
using HouseholdExpenses.Domain.Transactions.Enums;

namespace HouseholdExpenses.Domain.Transactions.Entities;

public sealed class Transaction
{
    public uint Id { get; private set; }

    public string Description { get; private set; }

    public decimal Amount { get; private set; }

    public TransactionType Type { get; private set; }

    public Category Category { get; private set; }

    public Person Person { get; private set; }

    public bool Deleted { get; private set; }

#pragma warning disable CS8618
    // Required for Entity Framework Core materialization
    private Transaction() { }
#pragma warning restore CS8618

    private Transaction(string description, decimal amount, TransactionType type, Category category, Person person)
    {
        Description = description;
        Amount = amount;
        Type = type;
        Category = category;
        Person = person;
    }

    public static Transaction Create(string description, decimal amount, TransactionType type, Category category, Person person)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new DomainException.Validation("Description is required.");
        }

        if (description.Length > 400)
        {
            throw new DomainException.Validation("Description max length is 400.");
        }

        if (amount <= 0)
        {
            throw new DomainException.Validation("Amount must be a positive value.");
        }

        switch (category.Purpose)
        {
            case CategoryPurpose.Expense:
                if (person.Age < 18)
                {
                    throw new DomainException.Validation("Minor aged people can only have expense transactions.");
                }

                if (type == TransactionType.Income)
                {
                    throw new DomainException.Validation("The selected category is restricted to expenses only.");
                }
                break;

            case CategoryPurpose.Income:
                if (type == TransactionType.Expense)
                {
                    throw new DomainException.Validation("The selected category is restricted to income only.");
                }
                break;
        }

        return new Transaction(description, amount, type, category, person);
    }

    public void Delete()
    {
        if (Deleted)
        {
            throw new DomainException.Validation("Already deleted.");
        }

        Deleted = true;
    }
}
