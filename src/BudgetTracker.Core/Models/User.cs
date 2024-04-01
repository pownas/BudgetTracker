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
    [JsonIgnore]
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    [JsonIgnore]
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    [JsonIgnore]
    public ICollection<PaidBy> PaidByGroups { get; set; } = new List<PaidBy>();
}
