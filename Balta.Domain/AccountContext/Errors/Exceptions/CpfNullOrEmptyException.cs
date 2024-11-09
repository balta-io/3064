using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class CpfNullOrEmptyException(string message) : DomainException(message);