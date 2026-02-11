using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Domain.Categories.Enums;

namespace HouseholdExpenses.Application.Categories.Commands;

public sealed record CreateCategoryCommand(
    string Description,
    CategoryPurpose Purpose
) : 
    ICommand<CategoryDTO>
{ }
