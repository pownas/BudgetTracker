using System.Text.Json.Serialization;

namespace BudgetTracker.Core.Models;

public class TransactionCategory
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonIgnore]
    public virtual User User { get; set; } = new User();
    public Guid UserId { get; set; }

    [JsonIgnore]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
