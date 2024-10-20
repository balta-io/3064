using Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;
using Dima.Domain.SharedContext.ValueObjects;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects;

/// <summary>
/// Define um objetivo financeiro
/// </summary>
public sealed record Goal : ValueObject
{
    #region Constructors

    private Goal(string description, decimal targetAmount, decimal currentAmount)
    {
        Description = description;
        TargetAmount = targetAmount;
        CurrentAmount = currentAmount;
    }

    #endregion

    #region Factories

    public static Goal Create(string description, decimal targetAmount, decimal currentAmount = 0)
    {
        if (string.IsNullOrEmpty(description))
            throw new InvalidGoalDescriptionException();

        if (string.IsNullOrWhiteSpace(description))
            throw new InvalidGoalDescriptionException();

        if (targetAmount <= 0)
            throw new InvalidGoalTargetAmountException();
        
        if (currentAmount <= 0)
            throw new InvalidGoalCurrentAmountException();

        return new Goal(description, targetAmount, currentAmount);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Descrição ou observação sobre a meta de economia
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Valor total que o usuário deseja economizar para esta meta.
    /// </summary>
    public decimal TargetAmount { get; }

    /// <summary>
    /// Valor já economizado até o momento.
    /// </summary>
    public decimal CurrentAmount { get; }

    #endregion

    #region Computed Properties

    /// <summary>
    /// Valor que indica se a meta já foi alcançada.
    /// </summary>
    public bool IsAchieved() => CurrentAmount >= TargetAmount;

    #endregion
}
