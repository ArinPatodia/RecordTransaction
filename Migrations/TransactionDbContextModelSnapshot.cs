﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransactionRecord.Models;

namespace TransactionRecord.Migrations
{
    [DbContext(typeof(TransactionDbContext))]
    partial class TransactionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransactionRecord.Models.Company", b =>
                {
                    b.Property<int?>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TickerSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Address = "453 Bill Gates Way",
                            CompanyName = "Microsoft",
                            TickerSymbol = "MSFT"
                        },
                        new
                        {
                            CompanyId = 2,
                            Address = "123Google Way",
                            CompanyName = "Google",
                            TickerSymbol = "GOOG"
                        },
                        new
                        {
                            CompanyId = 3,
                            Address = "789 Walmart Way",
                            CompanyName = "Walmart",
                            TickerSymbol = "WLMT"
                        });
                });

            modelBuilder.Entity("TransactionRecord.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double?>("SharePrice")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("TransactionTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TransactionId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            CompanyId = 1,
                            Quantity = 100,
                            SharePrice = 123.45,
                            TransactionTypeId = "B"
                        },
                        new
                        {
                            TransactionId = 2,
                            CompanyId = 2,
                            Quantity = 100,
                            SharePrice = 2701.7600000000002,
                            TransactionTypeId = "S"
                        });
                });

            modelBuilder.Entity("TransactionRecord.Models.TransactionType", b =>
                {
                    b.Property<string>("TransactionTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("CommissionFee")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            TransactionTypeId = "B",
                            CommissionFee = 5.4000000000000004,
                            Name = "Buy"
                        },
                        new
                        {
                            TransactionTypeId = "S",
                            CommissionFee = 5.9900000000000002,
                            Name = "Sell"
                        });
                });

            modelBuilder.Entity("TransactionRecord.Models.Transaction", b =>
                {
                    b.HasOne("TransactionRecord.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransactionRecord.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("TransactionType");
                });
#pragma warning restore 612, 618
        }
    }
}
