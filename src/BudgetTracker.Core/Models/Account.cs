using System.Text.Json.Serialization;

namespace BudgetTracker.Core.Models;

/// <summary>
/// Konto i "Kontoplanen" <br /><br />
/// 
/// Account in the “Chart of Accounts”
/// </summary>
/// <remarks>
/// En grundläggande “Chart of Accounts” bör innehålla följande fem kategorier: <br />
/// 1. Tillgångar (Assets) <br />
/// 2. Skulder (Liabilities) <br />
/// 3. Eget kapital (Equity) <br />
/// 4. Intäkter (Revenue) <br />
/// 5. Kostnader (Expenses)
/// </remarks>
public class Account
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Number { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Balance { get; set; } = 0;
    public bool IsUsed { get; set; } = true;
    public Guid CategoryId { get; set; }
    public Guid CreatedByUserId { get; set; }
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    [JsonIgnore]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
