using Dima.Domain.FinancialPlanningContext.ValueObjects.Errors;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;

public class InvalidTargetEndDateException(string message = TargetErrorMessages.InvalidEndDateErrorMessage)
    : Exception(message);
