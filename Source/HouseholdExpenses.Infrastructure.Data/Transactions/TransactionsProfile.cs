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
            .ForMember(model => model.CategoryId, opt => opt.MapFrom(transaction => transaction.Category.Id))
            .ForMember(model => model.PersonId, opt => opt.MapFrom(transaction => transaction.Person.Id));

        CreateMap<TransactionModel, Transaction>()
            .ConstructUsing((model, context) =>
            {
                var type = context.Mapper.Map<TransactionType>(model.Type);
                var category = context.Mapper.Map<Category>(model.Category);
                var person = context.Mapper.Map<Person>(model.Person);
                return Transaction.Create(
                    model.Description, 
                    model.Amount,
                    type,
                    category,
                    person
                );
            });

    }
}
