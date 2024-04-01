using System.Text.Json.Serialization;

namespace BudgetTracker.Core.Models;

/// <summary>
/// Användare i systemet
/// </summary>
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary> Användarnamn - UserName </summary>
    /// <example>Username</example>
    public string UserName { get; set; } = string.Empty;

    /// <summary> Förnamn - Forename </summary>
    /// <example>Kalle</example>
    /// <value>Default: Kalle</value>
    public string NameFirst { get; set; } = "Kalle";

    /// <summary> Efternamn - Surname </summary>
    /// <example>Anka</example>
    /// <value>Default: Anka</value>
    public string NameLast { get; set; } = string.Empty;

    /// <summary> Fullständigt namn - Full name </summary>
    /// <example>Kalle Anka</example>
    /// <value>Default: Kalle Anka</value>
    public string NameFull { get { return $"{NameFirst} {NameLast}"; } }

    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    public string Password { get; set; } = string.Empty;

    [JsonIgnore]
    public string PasswordSalt { get; set; } = string.Empty;

    [JsonIgnore]
    public string PasswordHash { get; set; } = string.Empty;

    public string Role { get; set; } = "User";

    public Guid? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    [JsonIgnore]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    [JsonIgnore]
    public virtual ICollection<TransactionCategory> TransactionCategories { get; set; } = new List<TransactionCategory>();

    [JsonIgnore]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    
    [JsonIgnore]
    public virtual ICollection<PaidBy> PaidByGroups { get; set; } = new List<PaidBy>();
}
