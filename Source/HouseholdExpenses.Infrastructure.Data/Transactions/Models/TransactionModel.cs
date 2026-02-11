using HouseholdExpenses.Infrastructure.Data.Categories.Models;
using HouseholdExpenses.Infrastructure.Data.People.Models;

namespace HouseholdExpenses.Infrastructure.Data.Transactions.Models;

public sealed class TransactionModel
{
    public uint Id { get; private set; }

    public string Description { get; private set; }

    public decimal Amount { get; private set; }

    public TransactionTypeModel Type { get; private set; }

    public uint CategoryId { get; private set; }
    public CategoryModel Category { get; private set; }

    public uint PersonId { get; private set; }
    public PersonModel Person { get; private set; }

    public bool Deleted { get; private set; }

#pragma warning disable CS8618
    // Required for Entity Framework Core materialization
    private TransactionModel() { }
#pragma warning restore CS8618
}
