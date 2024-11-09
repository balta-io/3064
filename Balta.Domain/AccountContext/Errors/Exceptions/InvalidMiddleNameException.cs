using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.AccountContext.Errors.Exceptions;

public class InvalidMiddleNameException(string message) : DomainException(message);