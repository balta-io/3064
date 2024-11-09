using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class CnpjNullOrEmptyException(string message) : DomainException(message);