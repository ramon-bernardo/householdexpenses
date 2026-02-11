using HouseholdExpenses.Domain.Categories.Enums;

namespace HouseholdExpenses.Application.Categories.DTOs;

public sealed record CategoryDTO(
    uint Id,
    string Description,
    CategoryPurpose Purpose
) { }
