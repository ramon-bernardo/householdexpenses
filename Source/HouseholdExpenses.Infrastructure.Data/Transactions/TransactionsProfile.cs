using AutoMapper;
using HouseholdExpenses.Domain.Categories;
using HouseholdExpenses.Domain.People.Entities;
using HouseholdExpenses.Domain.Transactions.Entities;
using HouseholdExpenses.Domain.Transactions.Enums;
using HouseholdExpenses.Infrastructure.Data.Transactions.Models;

namespace HouseholdExpenses.Infrastructure.Data.Transactions;

public sealed class TransactionsProfile : Profile
{
    public TransactionsProfile()
    {
        CreateMap<TransactionType, TransactionTypeModel>();
        CreateMap<TransactionTypeModel, TransactionType>();

        CreateMap<Transaction, TransactionModel>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Id));

        CreateMap<TransactionModel, Transaction>()
            .ConstructUsing((src, context) =>
            {
                var type = context.Mapper.Map<TransactionType>(src.Type);
                var category = context.Mapper.Map<Category>(src.Category);
                var person = context.Mapper.Map<Person>(src.Person);
                return Transaction.Create(
                    src.Description,
                    src.Amount,
                    type,
                    category,
                    person
                );
            });

    }
}
