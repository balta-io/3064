using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class InvalidCnpjLenghtException(string message) : DomainException(message);