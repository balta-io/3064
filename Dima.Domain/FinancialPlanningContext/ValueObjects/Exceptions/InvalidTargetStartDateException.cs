using Dima.Domain.FinancialPlanningContext.ValueObjects.Errors;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;

public class InvalidTargetStartDateException(string message = TargetErrorMessages.InvalidStartDateErrorMessage) : Exception(message);
