using System.Text.Json.Serialization;

namespace BudgetTracker.Core.Models;

public class TransactionCategory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; } = new User();
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    [JsonIgnore]
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
