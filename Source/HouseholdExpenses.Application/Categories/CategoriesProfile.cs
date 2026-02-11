using AutoMapper;
using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Domain.Categories;

namespace HouseholdExpenses.Application.Categories;

public sealed class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();
    }
}
