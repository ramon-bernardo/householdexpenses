using HouseholdExpenses.Infrastructure.Data.Transactions.Models;

namespace HouseholdExpenses.Infrastructure.Data.People.Models;

public sealed class PersonModel
{
    public uint Id { get; private set; }

    public string Name { get; private set; }

    public uint Age { get; private set; }

    public ICollection<TransactionModel> Transactions { get; private set; }

    public bool Deleted { get; private set; }

#pragma warning disable CS8618
    // Required for Entity Framework Core materialization
    private PersonModel() { }
#pragma warning restore CS8618
}
