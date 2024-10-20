using Dima.Domain.FinancialPlanningContext.ValueObjects;
using Dima.Domain.SharedContext.Abstractions.Date;
using Dima.Domain.SharedContext.Entities;

namespace Dima.Domain.FinancialPlanningContext.Entities;

/// <summary>
/// Representa uma meta financeira de economia
/// </summary>
public sealed class SavingGoal : Entity
{
    #region Constructors

    private SavingGoal(
        Goal goal, 
        Period period, 
        Category category, 
        bool isNotificationsEnabled, 
        Track track, 
        Guid userId)
    {
        Goal = goal;
        Period = period;
        Category = category;
        IsNotificationsEnabled = isNotificationsEnabled;
        Track = track;
        UserId = userId;
    }

    #endregion

    #region Factories

    public static SavingGoal Create(
        string description,
        decimal targetAmount,
        decimal currentAmount,
        DateTime startDateUtc, 
        DateTime endDateUtc,
        Category category,
        bool isNotificationsEnabled,
        Guid userId,
        IDateTimeProvider provider)
    {
        var goal = Goal.Create(description, targetAmount, currentAmount);
        var target = Period.Create(startDateUtc, endDateUtc, provider);
        var track = Track.Create(provider);
        
        return new SavingGoal(goal, target, category, isNotificationsEnabled, track, userId);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Define o objetivo da meta
    /// </summary>
    public Goal Goal { get;  }

    /// <summary>
    /// Período da Meta
    /// </summary>
    public Period Period { get;  }

    /// <summary>
    /// Categoria da meta
    /// </summary>
    public Category Category { get; }
    
    /// <summary>
    /// Define se o usuário optou por receber notificações sobre o progresso da meta de economia.
    /// </summary>
    public bool IsNotificationsEnabled { get; }

    /// <summary>
    /// Define a criação e última atualização da meta
    /// </summary>
    public Track Track { get;  }

    /// <summary>
    /// Define o identificador do usuário associado a essa meta de economia.
    /// </summary>
    public Guid UserId { get; }

    #endregion
}
