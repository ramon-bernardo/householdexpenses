using AutoMapper;
using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Application.Categories.Queries;
using HouseholdExpenses.Application.Categories.Repositories;
using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Application.Categories.QueryHandlers;

public sealed class GetCategoryByIdQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : ICommandHandler<GetCategoryByIdQuery, CategoryDTO>
{
    private readonly ICategoryRepository CategoryRepository = categoryRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<CategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await CategoryRepository.GetById(request.Id);
        if (category is null)
        {
            throw new DomainException.NotFound("Category not found.");
        }

        var mappedCategory = Mapper.Map<CategoryDTO>(category);
        return mappedCategory;
    }
}
