using HouseholdExpenses.Domain.People.Entities;

namespace HouseholdExpenses.Application.People.Repositories;

public interface IPersonRepository
{
    Task<Person?> GetActiveById(uint id);

    Task<IReadOnlyCollection<Person>> GetAllActive();

    Task<Person> Add(Person person);

    Task Update(Person person);
}
