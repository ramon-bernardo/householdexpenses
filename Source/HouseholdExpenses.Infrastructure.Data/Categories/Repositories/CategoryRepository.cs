using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HouseholdExpenses.Application.Categories.Repositories;
using HouseholdExpenses.Infrastructure.Data.Common;
using HouseholdExpenses.Infrastructure.Data.Categories.Models;
using HouseholdExpenses.Domain.Categories;

namespace HouseholdExpenses.Infrastructure.Data.Categories.Repositories;

public sealed class CategoryRepository(
    SqliteDbContext dbContext,
    IMapper mapper
) : ICategoryRepository
{
    private readonly SqliteDbContext DbContext = dbContext;
    private readonly IMapper Mapper = mapper;

    public async Task<Category> Add(Category category)
    {
        var categoryModel = Mapper.Map<CategoryModel>(category);
        await DbContext.AddAsync(categoryModel);
        await DbContext.SaveChangesAsync();
        return Mapper.Map<Category>(categoryModel);
    }

    public async Task<Category?> GetById(uint id)
    {
        var categoryModel = await DbContext.Categories
            .Where((category) => category.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return Mapper.Map<Category>(categoryModel);
    }

    public async Task<IReadOnlyCollection<Category>> GetAll()
    {
        var categoryModels = await DbContext.Categories
            .AsNoTracking()
            .ToListAsync();

        return Mapper.Map<IReadOnlyCollection<Category>>(categoryModels);
    }
}
