using AutoMapper;
using HouseholdExpenses.Domain.People.Entities;
using HouseholdExpenses.Infrastructure.Data.People.Models;

namespace HouseholdExpenses.Infrastructure.Data.People;

public sealed class PeopleProfile : Profile
{
    public PeopleProfile()
    {
        CreateMap<Person, PersonModel>();
        CreateMap<PersonModel, Person>()
            .ConstructUsing((model, context) =>
            {
                return Person.Create(model.Name, model.Age);
            });
    }
}
