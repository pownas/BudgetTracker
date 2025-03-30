namespace BudgetTracker.Shared.DTO;

/// <summary>
/// Struktur för att hantera import av transaktioner från ICAs CSV-fil
/// </summary>
public class TransactionIca
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Datum { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Typ { get; set; } = string.Empty;
    public string Budgetgrupp { get; set; } = string.Empty;
    public decimal Belopp { get; set; } = 0;
    public decimal Saldo { get; set; } = 0;
}
