namespace HouseholdExpenses.Infrastructure.Data.Categories.Models;

public sealed class CategoryModel
{
    public uint Id { get; private set; }

    public string Description { get; private set; }

    public CategoryPurposeModel Purpose { get; private set; }

#pragma warning disable CS8618
    // Required for Entity Framework Core materialization
    private CategoryModel() { }
#pragma warning restore CS8618
}
