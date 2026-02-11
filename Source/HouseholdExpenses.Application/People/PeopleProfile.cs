using AutoMapper;
using HouseholdExpenses.Application.People.DTOs;
using HouseholdExpenses.Domain.People.Entities;

namespace HouseholdExpenses.Application.People;

public sealed class PeopleProfile : Profile
{
    public PeopleProfile()
    {
        CreateMap<Person, PersonDTO>();
    }
}
