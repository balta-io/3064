using Dima.Domain.FinancialPlanningContext.ValueObjects.Errors;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;

public class InvalidGoalTargetAmountException(string message = GoalErrorMessage.InvalidDescriptionErrorMessage) : Exception(message);
