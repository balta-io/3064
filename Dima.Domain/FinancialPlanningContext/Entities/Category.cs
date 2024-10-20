using Dima.Domain.SharedContext.Entities;

namespace Dima.Domain.FinancialPlanningContext.Entities;

public sealed class Category : Entity
{
    #region Constructors

    private Category(string title, Guid userId, string? description)
    {
        Title = title;
        UserId = userId;
        Description = description;
    }

    #endregion

    #region Factories

    public static Category Create(string title, Guid userId, string description = "")
    {
        return new Category(title, userId, description);
    }

    #endregion

    #region Properties

    public string Title { get; }
    public string? Description { get; }

    /// <summary>
    /// Obtém ou define o identificador do usuário associado a esse limite de gastos.
    /// </summary>
    public Guid UserId { get; }

    #endregion
}