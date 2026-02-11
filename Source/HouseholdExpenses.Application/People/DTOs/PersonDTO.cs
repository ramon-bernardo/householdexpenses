namespace HouseholdExpenses.Application.People.DTOs;

public sealed record PersonDTO(
    uint Id,
    string Name,
    uint Age
) { }
