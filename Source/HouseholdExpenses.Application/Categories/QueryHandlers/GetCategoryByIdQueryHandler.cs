using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Application.Categories.Repositories;

namespace HouseholdExpenses.Application.Categories.QueryHandlers;

public sealed class GetCategoryByIdQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : IRequestHandler<GetCategoryByIdQuery, CategoryDTO?>
{
    private readonly ICategoryRepository CategoryRepository = categoryRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<CategoryDTO?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await CategoryRepository.GetById(request.Id);
        var mappedCategory = Mapper.Map<CategoryDTO>(category);
        return mappedCategory;
    }
}
