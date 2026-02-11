using AutoMapper;
using HouseholdExpenses.Domain.Categories;
using HouseholdExpenses.Domain.Categories.Enums;
using HouseholdExpenses.Infrastructure.Data.Categories.Models;

namespace HouseholdExpenses.Infrastructure.Data.Categories;

public sealed class CategoriesProfile : Profile
{
    public CategoriesProfile()
    {
        CreateMap<CategoryPurpose, CategoryPurposeModel>();
        CreateMap<CategoryPurposeModel, CategoryPurpose>();

        CreateMap<Category, CategoryModel>();
        CreateMap<CategoryModel, Category>()
            .ConstructUsing((src, context) =>
            {
                var purpose = context.Mapper.Map<CategoryPurpose>(src.Purpose);
                return Category.Create(
                    src.Description,
                    purpose
                );
            });

    }
}
