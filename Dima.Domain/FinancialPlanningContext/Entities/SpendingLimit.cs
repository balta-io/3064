namespace Dima.Domain.FinancialPlanningContext.Entities;

/// <summary>
/// Representa um limite de gastos
/// </summary>
public class SpendingLimit
{
    /// <summary>
    /// Valor limite de gastos que o usuário pode gastar em uma determinada categoria ou período.
    /// </summary>
    public decimal LimitAmount { get; set; }

    /// <summary>
    /// Categoria de despesas à qual este limite de gastos está associado.
    /// </summary>
    public Category Category { get; set; }

    /// <summary>
    /// Data de início para o período de vigência do limite de gastos.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Data de término para o período de vigência do limite de gastos.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Define se notificações estão ativadas para alertar o usuário quando o limite de gastos for alcançado ou ultrapassado.
    /// </summary>
    public bool NotificationsEnabled { get; set; }

    /// <summary>
    /// Data em que o limite de gastos foi criado.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Obtém ou define a data da última atualização no limite de gastos.
    /// </summary>
    public DateTime LastUpdated { get; set; }

    /// <summary>
    /// Obtém ou define o identificador do usuário associado a esse limite de gastos.
    /// </summary>
    public Guid UserId { get; set; }
}
