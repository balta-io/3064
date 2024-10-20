using Dima.Domain.SharedContext.Abstractions.Date;

namespace Dima.Domain.Test.SharedContext.Mocks;

public class DateTimeProvider : IDateTimeProvider
{
    #region Properties

    public DateTime UtcNow { get; } = new(2024, 10, 20, 10, 55, 11);

    #endregion
}