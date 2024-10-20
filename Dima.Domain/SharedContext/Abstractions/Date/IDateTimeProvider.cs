namespace Dima.Domain.SharedContext.Abstractions.Date;

public interface IDateTimeProvider
{
    #region Properties

    public DateTime UtcNow { get; }

    #endregion
}
