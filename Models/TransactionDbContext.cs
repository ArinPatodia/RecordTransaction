using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TransactionRecord.Models
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    TransactionId = 1,
                    CompanyId = 1,
                    SharePrice = 123.45,
                    Quantity = 100,
                    //TickerSymbol = "MSFT",
                    TransactionTypeId = "B",
                    //Address = "453 Bill Gates Way"

                },
                new Transaction
                {
                    TransactionId = 2,
                    CompanyId = 2,
                    SharePrice = 2701.76,
                    //TickerSymbol = "GOOG",
                    Quantity = 100,
                    TransactionTypeId = "S",
                    //Address = "123 Google Way"

                }
            );

            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType { TransactionTypeId = "B", Name = "Buy", CommissionFee = 5.40 },
                new TransactionType { TransactionTypeId = "S", Name = "Sell", CommissionFee = 5.99 }
            );
            modelBuilder.Entity<Company>().HasData(
                new Company {CompanyId = 1, CompanyName = "Microsoft", TickerSymbol="MSFT", Address= "453 Bill Gates Way" },
                new Company { CompanyId = 2, CompanyName = "Google", TickerSymbol = "GOOG", Address = "123 Google Way" }
                //new Company { CompanyId = 3, CompanyName = "Walmart", TickerSymbol = "WLMT", Address = "789 Walmart Way" }
            );
        }
    }
}
