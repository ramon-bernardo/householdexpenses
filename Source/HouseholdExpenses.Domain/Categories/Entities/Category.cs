using HouseholdExpenses.Domain.Categories.Enums;
using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Domain.Categories;

public sealed class Category
{
    public uint Id { get; private set; }

    public string Description { get; private set; }

    public CategoryPurpose Purpose { get; private set; }

#pragma warning disable CS8618
    // Required for Entity Framework Core materialization
    private Category() { }
#pragma warning restore CS8618

    private Category(string description, CategoryPurpose purpose)
    {
        Description = description;
        Purpose = purpose;
    }

    public static Category Create(string description, CategoryPurpose purpose)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new DomainException.Validation("Description is required.");
        }

        if (description.Length > 400)
        {
            throw new DomainException.Validation("Description max length is 400.");
        }

        return new Category(description, purpose);
    }
}
