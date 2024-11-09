using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class InvalidEmailException(string message) : DomainException(message);