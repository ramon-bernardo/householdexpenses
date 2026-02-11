using System.Text.Json.Serialization;

namespace HouseholdExpenses.Domain.Transactions.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionType
{
    Expense,
    Income
}
