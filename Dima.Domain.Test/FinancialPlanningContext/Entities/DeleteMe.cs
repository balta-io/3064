using Dima.Domain.FinancialPlanningContext.Entities;
using Dima.Domain.Test.SharedContext.Mocks;

namespace Dima.Domain.Test.FinancialPlanningContext.Entities;

public class DeleteMe
{
    // Criar categoria
    // Criar limite de gastos para categoria
    // Criar metas financeiras
    
    public DeleteMe()
    {
        var provider = new DateTimeProvider();
        var user = Guid.NewGuid();
        
        // Cria uma categoria
        var category = Category.Create("Viagens", user);
        
        // Define um limite de gastos para categoria de 50K
        var spendingLimit = SpendingLimit.Create(50_000m, DateTime.Now, DateTime.Now.AddYears(1), category, provider);
        
        // Define uma meta financeira
        var travel = SavingGoal.Create("Férias na Itália", 60_000m, 1_500M, DateTime.Now, DateTime.Now.AddYears(1),
            category, true, user, provider);
    }
}