using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class VerificationCodeLenghtException(string message) : DomainException(message);