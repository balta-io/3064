using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class DocumentNullException(string message) : DomainException(message);