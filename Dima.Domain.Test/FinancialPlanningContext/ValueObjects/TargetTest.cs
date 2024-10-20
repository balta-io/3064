using Dima.Domain.FinancialPlanningContext.ValueObjects;
using Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;
using Dima.Domain.SharedContext.Abstractions.Date;
using Dima.Domain.Test.SharedContext.Mocks;

namespace Dima.Domain.Test.FinancialPlanningContext.ValueObjects;

public class TargetTest
{
    #region Private Members

    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly DateTime _now;
    private readonly DateTime _startDateUtc;
    private readonly DateTime _endDateUtc;

    #endregion

    #region Constructors

    public TargetTest()
    {
        var provider = new DateTimeProvider();

        _dateTimeProvider = provider;
        _now = provider.UtcNow;
        _startDateUtc = provider.UtcNow;
        _endDateUtc = provider.UtcNow.AddMonths(1);
    }

    #endregion

    #region Tests

    [Fact]
    public void ShouldFailIfStartDateIsLowerThanNow()
    {
        var startDate = _now.AddDays(-1);

        Assert.Throws<InvalidTargetStartDateException>(() =>
        {
            Target.Create(startDate, _endDateUtc, _dateTimeProvider);
        });
    }

    [Fact]
    public void ShouldFailIfEndDateIsLowerThanStartDate()
    {
        var endDate = _now.AddMonths(-2);

        Assert.Throws<InvalidTargetEndDateException>(() =>
        {
            Target.Create(_startDateUtc, endDate, _dateTimeProvider);
        });
    }

    [Fact]
    public void ShouldFailIfStartAndEndDatesAreEqual()
    {
        Assert.Throws<InvalidTargetEndDateException>(() => { Target.Create(_now, _now, _dateTimeProvider); });
    }

    [Fact]
    public void ShouldCreateTarget()
    {
        var target = Target.Create(_startDateUtc, _endDateUtc, _dateTimeProvider);
        Assert.Equal(_startDateUtc, target.StartDateUtc);
        Assert.Equal(_endDateUtc, target.EndDateUtc);
    }

    #endregion
}