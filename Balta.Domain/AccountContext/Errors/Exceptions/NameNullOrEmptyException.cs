using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class NameNullOrEmptyException(string message) : DomainException(message);