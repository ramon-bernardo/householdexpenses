using AutoMapper;
using HouseholdExpenses.Domain.People.Entities;
using HouseholdExpenses.Infrastructure.Data.People.Models;

namespace HouseholdExpenses.Infrastructure.Data.People;

public sealed class PeopleProfile : Profile
{
    public PeopleProfile()
    {
        CreateMap<Person, PersonModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value));

        CreateMap<PersonModel, Person>()
            .ConstructUsing((src, context) =>
            {
                return Person.Create(src.Name, src.Age);
            });
    }
}
