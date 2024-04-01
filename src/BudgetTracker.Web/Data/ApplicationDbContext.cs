using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Core.Models;

namespace BudgetTracker.Web.Data;

//public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Transaction> Transaction { get; set; } = default!;
    public DbSet<TransactionCategory> TransactionCategory { get; set; } = default!;
    public DbSet<Account> Account { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<PaidBy> PaidBy { get; set; } = default!;
    public DbSet<User> User { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.SeedDatabase();

        //Information om databasnycklar finns via: https://learn.microsoft.com/en-us/ef/core/change-tracking/relationship-changes


        //modelBuilder.Entity<Transaction>()
        //    .HasOne(e => e.PaidBy)
        //    .WithMany(e => e.Transactions)
        //    .HasForeignKey(e => e.PaidById)
        //    .OnDelete(DeleteBehavior.NoAction);

        //modelBuilder.Entity<Transaction>()
        //    .HasOne(e => e.User)
        //    .WithMany(e => e.Transactions)
        //    .HasForeignKey(e => e.UserId)
        //    .OnDelete(DeleteBehavior.NoAction);

        //modelBuilder.Entity<Transaction>()
        //    .HasOne(e => e.Account)
        //    .WithMany(e => e.Transactions)
        //    .HasForeignKey(e => e.AccountId)
        //    .OnDelete(DeleteBehavior.NoAction);

        //modelBuilder.Entity<Transaction>()
        //    .HasOne(e => e.TransactionCategory)
        //    .WithMany(e => e.Transactions)
        //    .HasForeignKey(e => e.TransactionCategoryId)
        //    .OnDelete(DeleteBehavior.NoAction);

        ////modelBuilder.Entity<Account>()
        ////    .HasOne(e => e.User)
        ////    .WithMany(e => e)
        ////    .HasForeignKey(e => e.UserId)
        ////    .OnDelete(DeleteBehavior.NoAction);

        //modelBuilder.Entity<PaidBy>()
        //    .HasMany(paidBy => paidBy.Transactions)
        //    .WithOne(t => t.PaidBy)
        //    .HasForeignKey(t => t.PaidById)
        //    .OnDelete(DeleteBehavior.NoAction);



    }
}


