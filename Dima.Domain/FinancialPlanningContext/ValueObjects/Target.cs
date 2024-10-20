using Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;
using Dima.Domain.SharedContext.Abstractions.Date;
using Dima.Domain.SharedContext.ValueObjects;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects;

/// <summary>
/// Define quando uma meta começa e termina
/// </summary>
public sealed record Target : ValueObject
{
    #region Constructors

    private Target(DateTime startDateUtc, DateTime endDateUtc)
    {
        StartDateUtc = startDateUtc;
        EndDateUtc = endDateUtc;
    }

    #endregion

    #region Factories

    public static Target Create(DateTime startDateUtc, DateTime endDateUtc, IDateTimeProvider provider)
    {
        if (startDateUtc < provider.UtcNow)
            throw new InvalidTargetStartDateException();

        if (endDateUtc <= startDateUtc)
            throw new InvalidTargetEndDateException();

        return new Target(startDateUtc, endDateUtc);
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
