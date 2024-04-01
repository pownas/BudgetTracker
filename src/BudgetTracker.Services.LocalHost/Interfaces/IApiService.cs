using BudgetTracker.Core.Models;

namespace BudgetTracker.Services.LocalHost.Interfaces;

public interface IApiService
{
    /// <summary>
    /// Get transactions
    /// </summary>
    abstract Task<IEnumerable<Transaction>> GetTransactionsAsync();
}
