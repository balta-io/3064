using Balta.Application.SharedContext.Exceptions;
using Balta.Application.SharedContext.UseCases.Abstractions;
using FluentValidation;
using MediatR;
using ValidationException = Balta.Application.SharedContext.Exceptions.ValidationException;

namespace Balta.Application.SharedContext.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (validators.Any() == false)
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationErrors = validators
            .Select(x => x.Validate(context))
            .Where(x => x.Errors.Any())
            .SelectMany(x => x.Errors)
            .Select(x => new ValidationError(x.PropertyName, x.ErrorMessage))
            .ToList();

        if (validationErrors.Any())
            throw new ValidationException(validationErrors);

        return await next();
    }
}