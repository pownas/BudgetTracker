﻿// <auto-generated />
using System;
using BudgetTracker.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetTracker.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240401181301_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BudgetTracker.Core.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.PaidBy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaidBy", (string)null);
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DateAccounting")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCurrency")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTransaction")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PaidById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TransactionCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PaidById");

                    b.HasIndex("TransactionCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.TransactionCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TransactionCategory", (string)null);
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFirst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLast")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("CategoryTransactionCategory", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TransactionCategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "TransactionCategoriesId");

                    b.HasIndex("TransactionCategoriesId");

                    b.ToTable("CategoryTransactionCategory", (string)null);
                });

            modelBuilder.Entity("PaidByUser", b =>
                {
                    b.Property<Guid>("PaidByGroupsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaidByGroupsId", "UsersGroupId");

                    b.HasIndex("UsersGroupId");

                    b.ToTable("PaidByUser", (string)null);
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.Category", b =>
                {
                    b.HasOne("BudgetTracker.Core.Models.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.Transaction", b =>
                {
                    b.HasOne("BudgetTracker.Core.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BudgetTracker.Core.Models.PaidBy", "PaidBy")
                        .WithMany("Transactions")
                        .HasForeignKey("PaidById")
                        .IsRequired();

                    b.HasOne("BudgetTracker.Core.Models.TransactionCategory", "TransactionCategory")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionCategoryId")
                        .IsRequired();

                    b.HasOne("BudgetTracker.Core.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("PaidBy");

                    b.Navigation("TransactionCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.TransactionCategory", b =>
                {
                    b.HasOne("BudgetTracker.Core.Models.User", "User")
                        .WithMany("TransactionCategories")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.User", b =>
                {
                    b.HasOne("BudgetTracker.Core.Models.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CategoryTransactionCategory", b =>
                {
                    b.HasOne("BudgetTracker.Core.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .IsRequired();

                    b.HasOne("BudgetTracker.Core.Models.TransactionCategory", null)
                        .WithMany()
                        .HasForeignKey("TransactionCategoriesId")
                        .IsRequired();
                });

            modelBuilder.Entity("PaidByUser", b =>
                {
                    b.HasOne("BudgetTracker.Core.Models.PaidBy", null)
                        .WithMany()
                        .HasForeignKey("PaidByGroupsId")
                        .IsRequired();

                    b.HasOne("BudgetTracker.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersGroupId")
                        .IsRequired();
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.Account", b =>
                {
                    b.Navigation("Transactions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.PaidBy", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.TransactionCategory", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BudgetTracker.Core.Models.User", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("TransactionCategories");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
