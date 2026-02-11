using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Application.Common;

namespace HouseholdExpenses.Application.Categories.Queries;

public sealed record GetCategoryByIdQuery(uint Id) :
    ICommand<CategoryDTO> 
{ }
