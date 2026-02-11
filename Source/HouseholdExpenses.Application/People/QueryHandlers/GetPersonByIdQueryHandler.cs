using AutoMapper;
using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.People.DTOs;
using HouseholdExpenses.Application.People.Queries;
using HouseholdExpenses.Application.People.Repositories;
using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Application.People.QueryHandlers;

public sealed class GetPersonByIdQueryHandler(
    IPersonRepository peopleRepository,
    IMapper mapper
) : ICommandHandler<GetPersonByIdQuery, PersonDTO>
{
    private readonly IPersonRepository PersonRepository = peopleRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var people = await PersonRepository.GetActiveById(request.Id);
        if (people is null)
        {
            throw new DomainException.NotFound("People not found.");
        }

        var mappedPeople = Mapper.Map<PersonDTO>(people);
        return mappedPeople;
    }
}
