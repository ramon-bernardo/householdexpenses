using AutoMapper;
using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Application.Categories.Queries;
using HouseholdExpenses.Application.Categories.Repositories;
using HouseholdExpenses.Application.Common;

namespace HouseholdExpenses.Application.Categories.QueryHandlers;

public sealed class GetCategoriesQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : ICommandHandler<GetCategoriesQuery, IEnumerable<CategoryDTO>>
{
    private readonly ICategoryRepository CategoryRepository = categoryRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<IEnumerable<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await CategoryRepository.GetAll();
        var mappedCategorys = Mapper.Map<IEnumerable<CategoryDTO>>(categories);
        return mappedCategorys;
    }
}
