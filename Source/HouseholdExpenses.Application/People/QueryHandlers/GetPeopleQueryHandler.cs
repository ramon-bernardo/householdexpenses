using MediatR;
using AutoMapper;
using HouseholdExpenses.Application.People.DTOs;
using HouseholdExpenses.Application.People.Queries;
using HouseholdExpenses.Application.People.Repositories;

namespace HouseholdExpenses.Application.People.QueryHandlers;

public sealed class GetPeopleQueryHandler(
    IPersonRepository personRepository,
    IMapper mapper
) : IRequestHandler<GetPeopleQuery, IEnumerable<PersonDTO>>
{
    private readonly IPersonRepository PersonRepository = personRepository;
    private readonly IMapper Mapper = mapper;

    public async Task<IEnumerable<PersonDTO>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        var peoples = await PersonRepository.GetAllActive();
        var mappedPeoples = Mapper.Map<IEnumerable<PersonDTO>>(peoples);
        return mappedPeoples;
    }
}
