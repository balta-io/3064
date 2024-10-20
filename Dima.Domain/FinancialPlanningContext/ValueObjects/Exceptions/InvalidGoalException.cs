using Dima.Domain.FinancialPlanningContext.ValueObjects.Errors;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;

public class InvalidGoalException(string message = GoalErrorMessage.DefaultErrorMessage) : Exception(message);
