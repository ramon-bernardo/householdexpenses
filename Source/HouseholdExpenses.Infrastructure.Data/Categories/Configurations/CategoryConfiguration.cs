using HouseholdExpenses.Infrastructure.Data.Categories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseholdExpenses.Infrastructure.Data.Categories.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
{
    public void Configure(EntityTypeBuilder<CategoryModel> builder)
    {
        builder.ToTable("category");

        builder.HasKey(model => model.Id);

        builder.Property(model => model.Id)
            .HasColumnName("id")
            .HasConversion<long>()
            .ValueGeneratedOnAdd();

        builder.Property(model => model.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(400);

        builder.Property(model => model.Purpose)
            .HasColumnName("purpose")
            .IsRequired()
            .HasConversion(
                model => model.ToString().ToUpper(),
                text => Enum.Parse<CategoryPurposeModel>(text, true)
            )
            .HasMaxLength(8);
    }
}