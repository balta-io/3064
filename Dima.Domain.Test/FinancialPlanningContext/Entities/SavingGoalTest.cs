using Dima.Domain.FinancialPlanningContext.Entities;
using Dima.Domain.SharedContext.Abstractions.Date;
using Dima.Domain.Test.SharedContext.Mocks;

namespace Dima.Domain.Test.FinancialPlanningContext.Entities;

public class SavingGoalTest
{
    #region Constants

    private const string Description = "Férias de verão";
    private const decimal TargetAmount = 30_000m;
    private const decimal CurrenAmount = 1_500m;
    private const bool IsNotificationsEnabled = true;

    #endregion

    #region Private Members

    private readonly Guid _user;
    private readonly DateTime _startDateUtc;
    private readonly DateTime _endDateUtc;
    private readonly Category _category;
    private readonly Guid _userId;
    private readonly IDateTimeProvider _dateTimeProvider;

    #endregion

    #region Constructor

    public SavingGoalTest()
    {
        var provider = new DateTimeProvider();

        _user = Guid.NewGuid();
        _startDateUtc = provider.UtcNow;
        _endDateUtc = provider.UtcNow.AddMonths(1);
        _category = Category.Create("Viagens", _user);
        _userId = Guid.NewGuid();
        _dateTimeProvider = provider;
    }

    #endregion

    #region Tests

    [Fact]
    public void ShouldCreateSavingGoal()
    {
        var savingGoal = SavingGoal.Create(
            Description,
            TargetAmount,
            CurrenAmount,
            _startDateUtc,
            _endDateUtc,
            _category,
            IsNotificationsEnabled,
            _userId,
            _dateTimeProvider);
    }

    #endregion
}