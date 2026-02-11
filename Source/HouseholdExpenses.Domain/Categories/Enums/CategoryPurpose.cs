using System.Text.Json.Serialization;

namespace HouseholdExpenses.Domain.Categories.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CategoryPurpose
{
    Both,
    Expense,
    Income
}
