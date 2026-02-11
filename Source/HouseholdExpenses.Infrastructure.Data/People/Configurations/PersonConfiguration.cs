using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HouseholdExpenses.Infrastructure.Data.People.Models;

namespace HouseholdExpenses.Infrastructure.Data.People.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<PersonModel>
{
    public void Configure(EntityTypeBuilder<PersonModel> builder)
    {
        builder.ToTable("person");

        builder.HasKey(model => model.Id);

        builder.Property(model => model.Id)
            .HasColumnName("id")
            .HasConversion<long>()
            .ValueGeneratedOnAdd();

        builder.Property(model => model.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(model => model.Age)
            .HasColumnName("age")
            .IsRequired()
            .HasConversion<long>();

        builder.Property(model => model.Deleted)
            .HasColumnName("deleted")
            .HasDefaultValue(false);

        builder.HasQueryFilter(model => !model.Deleted);

        builder.HasIndex(model => model.Deleted)
            .HasDatabaseName("IX_person_deleted");
    }
}
