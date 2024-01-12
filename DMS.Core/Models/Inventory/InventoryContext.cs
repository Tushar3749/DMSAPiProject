using System;
using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.Inventory
{
    public partial class InventoryContext : InventoryContext_ModelClasses
    {
        private readonly IConfiguration config;

        public InventoryContext(IConfiguration config)
        {
            this.config = config;
        }

        public virtual DbSet<DepotAvailableStock> DepotAvailableStocks { get; set; }
        public virtual DbSet<IssueType> IssueTypes { get; set; }
        public virtual DbSet<StockIssue> StockIssues { get; set; }
        public virtual DbSet<StockIssueDetail> StockIssueDetails { get; set; }
        public virtual DbSet<StockReceive> StockReceives { get; set; }
        public virtual DbSet<StockReceiveDetail> StockReceiveDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("Inventory"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DepotAvailableStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DepotAvailableStock");

                entity.Property(e => e.BatchNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IssueType>(entity =>
            {
                entity.ToTable("IssueType");

                entity.Property(e => e.CreatedByCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedByCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<StockIssue>(entity =>
            {
                entity.ToTable("StockIssue");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DispatchByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DispatchedDate).HasColumnType("datetime");

                entity.Property(e => e.FromWarehouse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IssueCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.IssueType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.ModuleVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitionCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.ToWarehouse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<StockIssueDetail>(entity =>
            {
                entity.ToTable("StockIssueDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
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

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IssueCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<StockReceive>(entity =>
            {
                entity.ToTable("StockReceive");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovalRemarks)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.ChallanApprovedByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ChallanApprovedByName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ChallanCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.ChallanDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FromWarehouse)
                    .IsRequired()
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

                entity.Property(e => e.ReceiveCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiveType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitionCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.ToWarehouse)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VatChallanNo)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.VehicleNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StockReceiveDetail>(entity =>
            {
                entity.ToTable("StockReceiveDetail");

                entity.HasIndex(e => e.ProductCode, "NonClusteredIndex-20210829-215050");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
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

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.ManufacturingDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiveCode)
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
