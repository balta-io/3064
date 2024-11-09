using Balta.Domain.SharedContext.Results;
using MediatR;

namespace Balta.Application.SharedContext.UseCases.Abstractions;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TResult> : IRequest<Result<TResult>>, IBaseCommand where TResult : ICommandResponse;

public interface IBaseCommand
{
}