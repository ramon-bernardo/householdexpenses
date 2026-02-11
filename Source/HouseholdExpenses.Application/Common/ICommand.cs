using MediatR;

namespace HouseholdExpenses.Application.Common;

public interface ICommand :
    IAppRequest,
    IRequest
{ }

public interface ICommand<out TResponse> :
    IAppRequest,
    IRequest<TResponse>
{ }
