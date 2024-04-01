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
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public Guid UserId { get; set; }
    public User User { get; set; } = new User();
}
