using HouseholdExpenses.Domain.Categories.Enums;

namespace HouseholdExpenses.Domain.Categories;

public sealed class Category
{
    public uint Id { get; private set; }

    public string Description { get; private set; } = string.Empty;

    public CategoryPurpose Purpose { get; private set; }

    private Category() { }

    private Category(string description, CategoryPurpose purpose)
    {
        Description = description;
        Purpose = purpose;
    }

    public static Category Create(string description, CategoryPurpose purpose)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new Exception("Description is required.");
        }

        if (description.Length > 400)
        {
            throw new Exception("Description max length is 400.");
        }

        return new Category(description, purpose);
    }
}
