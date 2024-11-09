using Balta.Domain.SharedContext.Abstractions;

namespace Balta.Domain.SharedContext.Common;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow { get; } = DateTime.UtcNow;
}