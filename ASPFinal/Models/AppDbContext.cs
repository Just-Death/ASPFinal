using ASPFinal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<BankProduct> BankProducts { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BankProduct>()
                .HasKey(b => b.ProductId)
                .HasName("PK_ProductId");
            modelBuilder.Entity<BankProduct>()
                .HasOne(a => a.ProductType)
                .WithOne(b => b.BankProduct)
                .HasForeignKey<ProductType>(b => b.BankProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductType>()
                .HasKey(b => b.ProductTypeId)
                .HasName("PK_ProductTypeId");

            modelBuilder.Entity<Transaction>()
                .HasKey(b => b.TransactionId)
                .HasName("PK_TransactionId");

            modelBuilder.Entity<User>()
                .HasMany(c => c.Transactions)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
