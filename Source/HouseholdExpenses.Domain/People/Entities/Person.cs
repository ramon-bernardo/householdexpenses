using HouseholdExpenses.Domain.Common;
using HouseholdExpenses.Domain.People.ValueObjects;

namespace HouseholdExpenses.Domain.People.Entities;

public sealed class Person
{
    public uint Id { get; private set; }

    public Name Name { get; private set; }

    public uint Age { get; private set; }

    public bool Deleted { get; private set; }

#pragma warning disable CS8618
    // Required for Entity Framework Core materialization
    private Person() { }
#pragma warning restore CS8618

    private Person(Name name, uint age)
    {
        Name = name;
        Age = age;
        Deleted = false;
    }

    public static Person Create(string name, uint age)
    {
        var nameObject = Name.Create(name);

        return new Person(nameObject, age);
    }

    public void Update(string name, uint age)
    {
        if (Deleted)
        {
            throw new DomainException.Validation("Cannot update a deleted person.");
        }

        Name = Name.Create(name);
        Age = age;
    }

    public void Delete()
    {
        if (Deleted)
        {
            throw new DomainException.Validation("Already deleted.");
        }

        Deleted = true;
    }
}
