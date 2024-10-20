namespace Dima.Domain.FinancialPlanningContext.ValueObjects.Errors;

public static class GoalErrorMessage
{
    public const string DefaultErrorMessage = "Descrição inválida";
    public const string InvalidDescriptionErrorMessage = "Descrição inválida";
    public const string InvalidTargetAmountErrorMessage = "O objetivo tem que ser maior que zero";
    public const string InvalidCurrentAmountErrorMessage = "O valor atual do objetivo tem que ser maior que zero";
}
