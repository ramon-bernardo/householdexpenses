using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.Categories.DTOs;
using HouseholdExpenses.Application.Categories.Commands;
using HouseholdExpenses.Application.Categories.Repositories;
using HouseholdExpenses.Domain.Categories;

namespace HouseholdExpenses.Application.Categories.CommandHandlers;

public sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : IRequestHandler<CreateCategoryCommand, CategoryDTO>
{
    private readonly ICategoryRepository CategoryRepository = categoryRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<CategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Description, request.Purpose);

        var persistedCategory = await CategoryRepository.Add(category);

        return Mapper.Map<CategoryDTO>(persistedCategory);
    }
}
