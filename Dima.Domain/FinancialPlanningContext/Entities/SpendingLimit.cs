using Dima.Domain.FinancialPlanningContext.ValueObjects;
using Dima.Domain.SharedContext.Abstractions.Date;
using Dima.Domain.SharedContext.Entities;

namespace Dima.Domain.FinancialPlanningContext.Entities;

/// <summary>
/// Representa um limite de gastos
/// </summary>
public sealed class SpendingLimit : Entity
{
    private SpendingLimit(decimal limitAmount, Category category, Period period, Track track)
    {
        LimitAmount = limitAmount;
        Category = category;
        Period = period;
        Track = track;
    }

    public static SpendingLimit Create(decimal limitAmount, DateTime startDateUtc, DateTime endDateUtc,
        Category category, IDateTimeProvider dateTimeProvider)
    {
        var track = Track.Create(dateTimeProvider);
        var period = Period.Create(startDateUtc, endDateUtc, dateTimeProvider);

        return new SpendingLimit(limitAmount, category, period, track);
    }


    /// <summary>
    /// Valor limite de gastos que o usuário pode gastar em uma determinada categoria ou período.
    /// </summary>
    public decimal LimitAmount { get; }

    /// <summary>
    /// Categoria de despesas à qual este limite de gastos está associado.
    /// </summary>
    public Category Category { get; }

    /// <summary>
    /// Período de vigência do limite de gastos.
    /// </summary>
    public Period Period { get; }

    /// <summary>
    /// Data em que o limite de gastos foi criado.
    /// </summary>
    public Track Track { get; }
}