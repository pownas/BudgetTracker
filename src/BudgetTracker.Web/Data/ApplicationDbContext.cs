using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Core.Models;

namespace BudgetTracker.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<BudgetTracker.Core.Models.Transaction> Transaction { get; set; } = default!;
        public DbSet<BudgetTracker.Core.Models.TransactionCategory> TransactionCategory { get; set; } = default!;
        public DbSet<BudgetTracker.Core.Models.Account> Account { get; set; } = default!;
        public DbSet<BudgetTracker.Core.Models.Category> Category { get; set; } = default!;
        public DbSet<BudgetTracker.Core.Models.PaidBy> PaidBy { get; set; } = default!;
        public DbSet<BudgetTracker.Core.Models.User> User { get; set; } = default!;
    }
}
