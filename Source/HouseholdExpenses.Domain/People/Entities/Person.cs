namespace HouseholdExpenses.Domain.People.Entities;

public sealed class Person
{
    public uint Id { get; private set; }

    public string Name { get; private set; }

    public uint Age { get; private set; }

    public bool Deleted { get; private set; }

#pragma warning disable CS8618
    // Required for Entity Framework Core materialization
    private Person() { }
#pragma warning restore CS8618

    private Person(string name, uint age)
    {
        Name = name;
        Age = age;
        Deleted = false;
    }

    public static Person Create(string name, uint age)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Name is required."); // DomainException
        }

        if (name.Length > 200)
        {
            throw new Exception("Name max length is 200.");
        }

        return new Person(name, age);
    }

    public void Update(string name, uint age)
    {
        if (Deleted)
        {
            throw new Exception("Cannot update a deleted person.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Name is required.");
        }

        if (name.Length > 200)
        {
            throw new Exception("Name max length is 200.");
        }

        Name = name;
        Age = age;
    }

    public void Delete()
    {
        if (Deleted)
        {
            throw new Exception("Already deleted.");
        }

        Deleted = true;
    }
}
