using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class InvalidVerificationCodeException(string message) : DomainException(message);