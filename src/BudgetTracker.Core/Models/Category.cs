using System.Text.Json.Serialization;

namespace BudgetTracker.Core.Models;

/// <summary>
/// Budgetkategorier
/// </summary>
public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid? UserId { get; set; }

    public virtual User? User { get; set; }

    [JsonIgnore]
    public virtual ICollection<TransactionCategory> TransactionCategories { get; set; } = new List<TransactionCategory>();
}
