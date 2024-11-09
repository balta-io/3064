using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class InvalidDocumentException(string message) : DomainException(message);