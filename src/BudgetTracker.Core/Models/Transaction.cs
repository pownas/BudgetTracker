using System.Text.Json.Serialization;

namespace BudgetTracker.Core.Models;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Amount { get; set; } = 0;

    /// <summary>
    /// Bokföringsdag - dagen transaktionen bokförs <br /><br />
    /// 
    /// Accounting day - the day the transaction is accounted for
    /// </summary>
    public DateTime DateAccounting { get; set; } = DateTime.Now;

    /// <summary>
    /// Transaktionsdag - dagen transaktionen utfördes <br /><br />
    /// 
    /// Transaction day - the day the transaction was made
    /// </summary>
    public DateTime DateTransaction { get; set; }

    /// <summary>
    /// Valutadag - dagen transaktionen valuteras <br /><br />
    /// 
    /// Currency day - the day the transaction is valued
    /// </summary>
    public DateTime DateCurrency { get; set; }

    [JsonIgnore]
    public virtual Account Account { get; set; } = new Account();
    public Guid AccountId { get; set; }

    [JsonIgnore]
    public virtual TransactionCategory TransactionCategory { get; set; } = new TransactionCategory();
    public Guid TransactionCategoryId { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; } = new User();
    public Guid UserId { get; set; }

    [JsonIgnore]
    public virtual PaidBy PaidBy { get; set; } = new PaidBy();
    public Guid PaidById { get; set; }
}
