using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BudgetTracker.Core.Models;

namespace BudgetTracker.Web.Data;

//public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; } = default!;
    public virtual DbSet<Category> Categories { get; set; } = default!;
    public virtual DbSet<PaidBy> PaidBies { get; set; } = default!;
    public virtual DbSet<Transaction> Transactions { get; set; } = default!;
    public virtual DbSet<TransactionCategory> TransactionCategories { get; set; } = default!;
    public virtual DbSet<User> Users { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.SeedDatabase();

        //Information om databasnycklar finns via: https://learn.microsoft.com/en-us/ef/core/change-tracking/relationship-changes

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Categories).HasForeignKey(d => d.UserId);

            entity.HasMany(d => d.TransactionCategories).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryTransactionCategory",
                    r => r.HasOne<TransactionCategory>().WithMany()
                        .HasForeignKey("TransactionCategoriesId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("CategoriesId", "TransactionCategoriesId");
                        j.ToTable("CategoryTransactionCategory");
                    });
        });

        modelBuilder.Entity<PaidBy>(entity =>
        {
            entity.ToTable("PaidBy");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasMany(d => d.UsersGroups).WithMany(p => p.PaidByGroups)
                .UsingEntity<Dictionary<string, object>>(
                    "PaidByUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UsersGroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<PaidBy>().WithMany()
                        .HasForeignKey("PaidByGroupsId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("PaidByGroupsId", "UsersGroupId");
                        j.ToTable("PaidByUser");
                    });
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PaidBy).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PaidById)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TransactionCategory).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TransactionCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TransactionCategory>(entity =>
        {
            entity.ToTable("TransactionCategory");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.TransactionCategories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Account).WithMany(p => p.Users).HasForeignKey(d => d.AccountId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}