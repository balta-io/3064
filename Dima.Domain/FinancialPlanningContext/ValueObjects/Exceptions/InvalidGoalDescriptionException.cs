using Dima.Domain.FinancialPlanningContext.ValueObjects.Errors;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;

public class InvalidGoalDescriptionException(string message = GoalErrorMessage.InvalidTargetAmountErrorMessage)
    : Exception(message);
