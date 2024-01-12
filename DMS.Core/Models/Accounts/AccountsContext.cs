using System;
using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.Accounts
{
    public partial class AccountsContext : AccountContext_ModelClasses
    {
        private readonly IConfiguration config;

        public AccountsContext(IConfiguration config)
        {
            this.config = config;
        }

        //public AccountsContext(DbContextOptions<AccountsContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }
        public virtual DbSet<DepositDetail> DepositDetails { get; set; }
        public virtual DbSet<DepositType> DepositTypes { get; set; }
        public virtual DbSet<MoneyReceipt> MoneyReceipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("Accounts"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.SourceId);

                entity.ToTable("Bank");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.Acode).HasColumnName("ACode");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Deposit>(entity =>
            {
                entity.ToTable("Deposit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BankCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CashReceivedByCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepositBranch)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DepositByCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepositCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.DepositDate).HasColumnType("datetime");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.ModuleVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NetDepositAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<DepositDetail>(entity =>
            {
                entity.ToTable("DepositDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CashReceiveByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CashReceiveByDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.ConfirmationRemarks)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmedByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepositAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DepositCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.DepositTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentBank)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentDate).HasColumnType("datetime");

                entity.Property(e => e.InstrumentNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<DepositType>(entity =>
            {
                entity.ToTable("DepositType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepositTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepositTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MoneyReceipt>(entity =>
            {
                entity.ToTable("MoneyReceipt");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CanceledById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CanceledByID");

                entity.Property(e => e.CanceledOn).HasColumnType("datetime");

                entity.Property(e => e.CashAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChequeAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CollectedFromCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.ModuleVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoneyReceiptCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoneyReceiptDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryCollectionCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
