using Dima.Domain.FinancialPlanningContext.ValueObjects.Errors;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;

public class InvalidGoalCurrentAmountException(string message = GoalErrorMessage.InvalidCurrentAmountErrorMessage) : Exception(message);
