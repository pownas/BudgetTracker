namespace BudgetTracker.Core.Models;

/// <summary>
/// Vem som betalade transaktionen
/// </summary>
/// <remarks>Används för att hålla koll på vem som betalade vad.</remarks>
public class PaidBy
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<User> UsersGroup { get; set; } = new List<User>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
