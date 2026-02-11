using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HouseholdExpenses.Infrastructure.Data.Transactions.Models;

namespace HouseholdExpenses.Infrastructure.Data.Transactions.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<TransactionModel>
{
    public void Configure(EntityTypeBuilder<TransactionModel> builder)
    {
        builder.ToTable("transaction");

        builder.HasKey(model => model.Id);

        builder.Property(model => model.Id)
            .HasColumnName("id")
            .HasConversion<long>()
            .ValueGeneratedOnAdd();

        builder.Property(model => model.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(400);

        builder.Property(model => model.Amount)
            .HasColumnName("amount")
            .IsRequired()
            .HasPrecision(18, 2)
            .HasConversion<double>();

        builder.Property(model => model.Type)
            .HasColumnName("type")
            .IsRequired()
            .HasConversion(
                model => model.ToString().ToUpper(),
                text => Enum.Parse<TransactionTypeModel>(text, true)
            )
            .HasMaxLength(8);

        builder.Property(model => model.PersonId)
            .HasColumnName("person_id")
            .HasConversion<long>();

        builder.HasOne(model => model.Person)
            .WithMany(model => model.Transactions)
            .HasForeignKey(model => model.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(model => model.CategoryId)
            .HasColumnName("category_id")
            .HasConversion<long>();

        builder.HasOne(model => model.Category)
            .WithMany()
            .HasForeignKey(model => model.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(model => model.Deleted)
            .HasColumnName("deleted")
            .HasDefaultValue(false);

        builder.HasQueryFilter(model => !model.Deleted);

        builder.HasIndex(model => model.Deleted)
            .HasDatabaseName("IX_transaction_deleted");
    }
}
