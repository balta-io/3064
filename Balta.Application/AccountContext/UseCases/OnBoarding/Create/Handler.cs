using Balta.Domain.SharedContext.Results;
using Balta.Application.SharedContext.UseCases.Abstractions;
using Balta.Domain.AccountContext.Entities;
using Balta.Domain.AccountContext.Enums;
using Balta.Domain.AccountContext.Errors;
using Balta.Domain.AccountContext.Repositories.Abstractions;
using Balta.Domain.AccountContext.ValueObjects;
using Balta.Domain.SharedContext.Abstractions;
using Balta.Domain.SharedContext.Data.Abstractions;

namespace Balta.Application.AccountContext.UseCases.OnBoarding.Create;

public sealed class Handler(
    IDateTimeProvider dateTimeProvider,
    IAccountRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        // TODO: Verificar este código com erro
        // Verifica se o E-mail já está cadastrado
        var emailExists = await repository.ExistsAsync(request.Email, cancellationToken);
        if (emailExists)
            return Result.Failure<Response>(DomainErrors.Account.EmailInUse);

        // Gera os VOs
        var name = CompositeName.Create(request.FirstName, null, request.LastName);
        var email = Email.Create(request.Email);
        var password = Password.Create(request.Password);
        var cpf = Cpf.Create(request.Cpf);

        // Gera a entidade
        var account = request.Type == EAccountType.Professor
            ? Account.CreateProfessor(name, email, password, cpf, dateTimeProvider)
            : Account.CreateStudent(name, email, password, cpf, dateTimeProvider);

        // Persiste os dados
        await repository.SaveAsync(account, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        var response = new Response(account.Id, account.Name, account.Email);
        return Result.Success(response);
    }
}