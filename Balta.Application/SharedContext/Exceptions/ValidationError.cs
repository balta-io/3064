namespace Balta.Application.SharedContext.Exceptions;

public sealed record ValidationError(string PropertyName, string ErrorMessage);