using Dima.Domain.SharedContext.Abstractions.Date;

namespace Dima.Domain.FinancialPlanningContext.ValueObjects;

/// <summary>
/// Define as propriedades para acompanhamento da entidade
/// </summary>
public class Track
{
    #region Constructors

    private Track(DateTime createdAtUtc, DateTime updatedAtUtc)
    {
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    #endregion

    #region Factories

    public static Track Create(IDateTimeProvider dateTimeProvider) 
        => new(dateTimeProvider.UtcNow, dateTimeProvider.UtcNow);

    #endregion

    #region Properties

    /// <summary>
    /// Data em que a meta de economia foi criada.
    /// </summary>
    public DateTime CreatedAtUtc { get; }

    /// <summary>
    /// Data da última atualização na meta de economia.
    /// </summary>
    public DateTime UpdatedAtUtc { get; }

    #endregion
}
