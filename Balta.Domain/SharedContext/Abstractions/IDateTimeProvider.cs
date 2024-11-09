namespace Balta.Domain.SharedContext.Abstractions;

public interface IDateTimeProvider
{
    #region Properties

    DateTime UtcNow { get; }

    #endregion
}