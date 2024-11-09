using Balta.Domain.SharedContext.Abstractions;
using Balta.Domain.SharedContext.Exceptions;

namespace Balta.Domain.SharedContext.ValueObjects;

public sealed record Tracker : ValueObject
{
    #region Constructors

    private Tracker()
    {
    }

    private Tracker(DateTime createdAtUtc, DateTime cpdatedAtUtc)
    {
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = cpdatedAtUtc;
    }

    #endregion

    #region Factories

    public static Tracker Create()
        => new(DateTime.UtcNow, DateTime.UtcNow);

    public static Tracker Create(IDateTimeProvider dateTimeProvider)
        => new(dateTimeProvider.UtcNow, dateTimeProvider.UtcNow);

    #endregion

    #region Properties

    public DateTime CreatedAtUtc { get; }
    public DateTime UpdatedAtUtc { get; private set; }

    #endregion

    #region Public Methods

    public void Update(IDateTimeProvider dateTimeProvider)
    {
        if (dateTimeProvider.UtcNow < CreatedAtUtc)
            throw new InvalidDateTimeProviderIsExpired("");
        
        UpdatedAtUtc = dateTimeProvider.UtcNow;
    }

    #endregion
}