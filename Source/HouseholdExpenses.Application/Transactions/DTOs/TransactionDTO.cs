using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Application.People.DTOs;
using HouseholdExpenses.Domain.Transactions.Enums;

namespace HouseholdExpenses.Application.Transactions.DTOs;

public sealed record TransactionDTO(
    uint Id,
    string Description,
    decimal Amount,
    TransactionType Type,
    CategoryDTO Category,
    PersonDTO Person
) { }
