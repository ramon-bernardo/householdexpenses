using AutoMapper;
using HouseholdExpenses.Application.People.DTOs;
using HouseholdExpenses.Domain.People.Entities;
using HouseholdExpenses.Domain.People.ValueObjects;

namespace HouseholdExpenses.Application.People;

public sealed class PeopleProfile : Profile
{
    public PeopleProfile()
    {
        CreateMap<Person, PersonDTO>();
        CreateMap<PersonDTO, Person>();

        CreateMap<Name, string>()
            .ConvertUsing(src => src.Value);
        CreateMap<string, Name>()
            .ConvertUsing(src => Name.Create(src));
    }
}
