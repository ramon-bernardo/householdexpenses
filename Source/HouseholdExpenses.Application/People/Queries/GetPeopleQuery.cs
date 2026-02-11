using HouseholdExpenses.Application.Common;
using HouseholdExpenses.Application.People.DTOs;

namespace HouseholdExpenses.Application.People.Queries;

public sealed record GetPeopleQuery :
    ICommand<IEnumerable<PersonDTO>> 
{ }
