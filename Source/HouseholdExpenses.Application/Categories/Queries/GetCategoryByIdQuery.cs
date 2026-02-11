using MediatR;
using HouseholdExpenses.Application.Categories.DTOs;

namespace HouseholdExpenses.Application.Categories.QueryHandlers;

public sealed record GetCategoryByIdQuery(uint Id) : IRequest<CategoryDTO?> { }
