namespace BudgetTracker.Core.Models;

public class Transaction
{
    public int Id { get; set; } = 0;
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
    public Guid CategoryId { get; set; }
    public TransactionCategory Category { get; set; } = new TransactionCategory();
    public Guid UserId { get; set; }
    public User User { get; set; } = new User();
    public Guid PaidById { get; set; }
    public PaidBy PaidBy { get; set; } = new PaidBy();
}
