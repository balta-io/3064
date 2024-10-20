using Dima.Domain.FinancialPlanningContext.ValueObjects;
using Dima.Domain.SharedContext.Abstractions.Date;
using Dima.Domain.Test.SharedContext.Mocks;

namespace Dima.Domain.Test.FinancialPlanningContext.ValueObjects;

public class TrackTest
{
    #region Private Properties

    private readonly IDateTimeProvider _dateTimeProvider = new DateTimeProvider();

    #endregion

    #region Tests

    [Fact]
    public void ShouldCreateTrackWithCurrentDateTimeAsCreatedAt()
    {
        var track = Track.Create(_dateTimeProvider);
        Assert.Equal(_dateTimeProvider.UtcNow, track.CreatedAtUtc);
    }

    [Fact]
    public void ShouldCreateTrackWithCurrentDateTimeAsUpdatedAt()
    {
        var track = Track.Create(_dateTimeProvider);
        Assert.Equal(_dateTimeProvider.UtcNow, track.UpdatedAtUtc);
    }

    [Fact]
    public void ShouldCreateTrack()
    {
        var track = Track.Create(_dateTimeProvider);
        Assert.Equal(_dateTimeProvider.UtcNow, track.CreatedAtUtc);
        Assert.Equal(_dateTimeProvider.UtcNow, track.UpdatedAtUtc);
    }

    #endregion
}