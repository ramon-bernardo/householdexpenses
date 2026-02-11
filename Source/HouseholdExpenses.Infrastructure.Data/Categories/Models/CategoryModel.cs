namespace HouseholdExpenses.Infrastructure.Data.Categories.Models;

public sealed class CategoryModel
{
    public uint Id { get; private set; }

    public string Description { get; private set; } = string.Empty;

    public CategoryPurposeModel Purpose { get; private set; }

    private CategoryModel() { }
}
