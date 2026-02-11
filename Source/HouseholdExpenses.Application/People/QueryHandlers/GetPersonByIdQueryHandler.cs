using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.People.DTOs;
using HouseholdExpenses.Application.People.Queries;
using HouseholdExpenses.Application.People.Repositories;

namespace HouseholdExpenses.Application.People.QueryHandlers;

public sealed class GetPersonByIdQueryHandler(
    IPersonRepository peopleRepository,
    IMapper mapper
) : IRequestHandler<GetPersonByIdQuery, PersonDTO?>
{
    private readonly IPersonRepository PersonRepository = peopleRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<PersonDTO?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var people = await PersonRepository.GetActiveById(request.Id);
        var mappedPeople = Mapper.Map<PersonDTO>(people);
        return mappedPeople;
    }
}
