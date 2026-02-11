using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HouseholdExpenses.Application.People.Repositories;
using HouseholdExpenses.Infrastructure.Data.Common;
using HouseholdExpenses.Infrastructure.Data.People.Models;
using HouseholdExpenses.Domain.People.Entities;

namespace HouseholdExpenses.Infrastructure.Data.People.Repositories;

public sealed class PersonRepository(
    SqliteDbContext dbContext,
    IMapper mapper
) : IPersonRepository
{
    private readonly SqliteDbContext DbContext = dbContext;
    private readonly IMapper Mapper = mapper;

    public async Task<Person> Add(Person person)
    {
        var personModel = Mapper.Map<PersonModel>(person);
        await DbContext.AddAsync(personModel);
        await DbContext.SaveChangesAsync();
        return Mapper.Map<Person>(personModel);
    }

    public Task Update(Person person)
    {
        var personModel = Mapper.Map<PersonModel>(person);
        DbContext.Update(personModel);
        return Task.CompletedTask;
    }

    public async Task<Person?> GetActiveById(uint id)
    {
        var personModel = await DbContext.People
            .Where((person) => person.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return Mapper.Map<Person>(personModel);
    }

    public async Task<IReadOnlyCollection<Person>> GetAllActive()
    {
        var personModels = await DbContext.People
            .AsNoTracking()
            .ToListAsync();

        return Mapper.Map<IReadOnlyCollection<Person>>(personModels);
    }
}
