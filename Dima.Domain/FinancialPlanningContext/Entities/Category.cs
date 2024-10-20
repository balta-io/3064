using Dima.Domain.SharedContext.Entities;

namespace Dima.Domain.FinancialPlanningContext.Entities;

public class Category : Entity
{
    private Category(string title, string description, SpendingLimit? spendingLimit)
    {
        Title = title;
        Description = description;
        SpendingLimit = spendingLimit;
    }

    public static Category Create(string title, string description = "", SpendingLimit? spendingLimit = null)
    {
        return new Category(title, description, spendingLimit);
    }

    public string Title { get; }
    public string? Description { get; }
    public SpendingLimit? SpendingLimit { get; }
}