using Dima.Domain.FinancialPlanningContext.ValueObjects.Errors;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;

public class InvalidTargetException(string message = TargetErrorMessages.DefaultErrorMessage) : Exception(message);
