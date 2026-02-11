using MediatR;

namespace HouseholdExpenses.Application.Common;

public sealed class TransactionBehavior<TRequest, TResponse>(
    IUnitOfWork unitOfWork
) :
    IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IQuery<TResponse>)
        {
            return await next(cancellationToken);
        }

        if (request is ICommand<TResponse>)
        {
            await unitOfWork.Start(cancellationToken);
            var response = await next(cancellationToken);
            await unitOfWork.Complete(cancellationToken);
            return response;
        }

        throw new NotImplementedException();
    }
}
