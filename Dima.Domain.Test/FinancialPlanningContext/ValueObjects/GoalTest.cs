using Dima.Domain.FinancialPlanningContext.ValueObjects;
using Dima.Domain.FinancialPlanningContext.ValueObjects.Exceptions;

namespace Dima.Domain.Test.FinancialPlanningContext.ValueObjects;

public class GoalTest
{
    #region Private Members

    private const string Description = "Viagem internacional";
    private const decimal TargetAmount = 100m;
    private const decimal CurrentAmount = 50m;

    #endregion

    #region Public Members

    public static IEnumerable<object[]> NegativeAmounts =>
        new List<object[]>
        {
            new object[] { 0m },
            new object[] { -1m },
            new object[] { -100m }
        };

    #endregion

    #region Tests

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ShouldFailIfDescriptionIsInvalid(string description)
    {
        Assert.Throws<InvalidGoalDescriptionException>(() =>
        {
            Goal.Create(description, TargetAmount, CurrentAmount);
        });
    }

    [Theory]
    [MemberData(nameof(NegativeAmounts))]
    public void ShouldFailIfTargetAmountIsLowerThanZero(decimal targetAmount)
    {
        Assert.Throws<InvalidGoalTargetAmountException>(() =>
        {
            Goal.Create(Description, targetAmount, CurrentAmount);
        });
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    [InlineData(-100)]
    public void ShouldFailIfCurrentAmountIsLowerThanZero(double currentAmount)
    {
        Assert.Throws<InvalidGoalCurrentAmountException>(() =>
        {
            Goal.Create(Description, TargetAmount, (decimal)currentAmount);
        });
    }

    [Fact]
    public void ShouldCreateGoal()
    {
        var goal = Goal.Create(Description, TargetAmount, CurrentAmount);
        Assert.Equal(Description, goal.Description);
        Assert.Equal(TargetAmount, goal.TargetAmount);
        Assert.Equal(CurrentAmount, goal.CurrentAmount);
    }

    #endregion
}
