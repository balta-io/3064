using Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;
using Dima.Domain.SharedContext.Abstractions.Date;
using Dima.Domain.SharedContext.ValueObjects;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects;

/// <summary>
/// Define quando algo começa e termina
/// </summary>
public sealed record Period : ValueObject
{
    #region Constructors

    private Period(DateTime startDateUtc, DateTime endDateUtc)
    {
        StartDateUtc = startDateUtc;
        EndDateUtc = endDateUtc;
    }

    #endregion

    #region Factories

    public static Period Create(DateTime startDateUtc, DateTime endDateUtc, IDateTimeProvider provider)
    {
        if (startDateUtc < provider.UtcNow)
            throw new InvalidTargetStartDateException();

        if (endDateUtc <= startDateUtc)
            throw new InvalidTargetEndDateException();

        return new Period(startDateUtc, endDateUtc);
    }

    #endregion
    
    #region Properties

    /// <summary>
    /// Data em que o usuário começou a economizar para esta meta.
    /// </summary>
    public DateTime StartDateUtc { get; }

    /// <summary>
    /// Data prevista para alcançar a meta de economia.
    /// </summary>
    public DateTime EndDateUtc { get; }

    #endregion
}
