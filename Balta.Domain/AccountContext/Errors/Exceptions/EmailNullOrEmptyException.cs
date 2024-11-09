using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class EmailNullOrEmptyException(string message) : DomainException(message);