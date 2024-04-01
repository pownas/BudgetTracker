namespace BudgetTracker.Core.Models;

/// <summary>
/// Budgetkategorier
/// </summary>
public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
