using MediatR;

namespace HouseholdExpenses.Application.Common;

public interface IQuery : IAppRequest, IRequest { }

public interface IQuery<out TResponse> : IAppRequest, IRequest { }
