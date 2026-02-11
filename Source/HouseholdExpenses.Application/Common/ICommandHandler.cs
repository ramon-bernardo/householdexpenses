using MediatR;

namespace HouseholdExpenses.Application.Common;

public interface ICommandHandler<TRequest, TResponse> :
    IRequestHandler<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
        where TResponse : notnull
{ }

public interface ICommandHandler<TRequest> :
    IRequestHandler<TRequest>
        where TRequest : ICommand
{ }
