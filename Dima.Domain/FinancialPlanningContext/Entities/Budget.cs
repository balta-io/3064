using Dima.Domain.SharedContext.Entities;

namespace Dima.Domain.FinancialPlanningContext.Entities;

/// <summary>
/// Representa um orçamento financeiro
/// </summary>
public class Budget : Entity
{
    /// <summary>
    /// Valor total do orçamento que o usuário pretende gastar ou economizar.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Quantia já alocada ou gasta dentro do orçamento.
    /// </summary>
    public decimal AllocatedAmount { get; set; }

    /// <summary>
    /// Saldo restante do orçamento (TotalAmount - AllocatedAmount).
    /// </summary>
    public decimal RemainingAmount { get; set; }

    /// <summary>
    /// Data de início do período do orçamento.
    /// </summary>
    public DateTime StartDateUtc { get; set; }

    /// <summary>
    /// Data de término do período do orçamento.
    /// </summary>
    public DateTime EndDateUtc { get; set; }

    /// <summary>
    /// Lista de categorias de despesas e receitas que fazem parte do orçamento.
    /// </summary>
    public List<Category> Categories { get; set; }

    /// <summary>
    /// Meta de economia associada a esse orçamento, se houver.
    /// </summary>
    public SavingGoal? SavingGoal { get; set; }

    /// <summary>
    /// Define se o usuário optou por receber notificações sobre o status do orçamento.
    /// </summary>
    public bool NotificationsEnabled { get; set; }

    /// <summary>
    /// Data em que o orçamento foi criado.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Data da última atualização no orçamento.
    /// </summary>
    public DateTime UpdatedAtUtc { get; set; }
    
    /// <summary>
    /// Obtém ou define o identificador do usuário ao qual o orçamento está associado.
    /// </summary>
    public Guid UserId { get; set; }
}
