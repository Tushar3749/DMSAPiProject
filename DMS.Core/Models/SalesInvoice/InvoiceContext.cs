using System;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.PartyCode;
using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.SalesInvoice
{
    public partial class InvoiceContext : InvoiceContext_SPModels
    {
        public IConfiguration Config { get; }


        public InvoiceContext(IConfiguration config)
        {
            this.Config = config;
        }

        //public InvoiceContext(DbContextOptions<InvoiceContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<ChemistInvoiceAllowedDuration> chemistInvoiceAllowedDuration { get; set; }
        public virtual DbSet<InvoiceAllocation> InvoiceAllocations { get; set; }
        public virtual DbSet<InvoiceAllocationDetail> InvoiceAllocationDetails { get; set; }
        public virtual DbSet<InvoiceAllocationRoute> InvoiceAllocationRoutes { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceProductBatchWise> InvoiceProductBatchWises { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }
        public virtual DbSet<ValidateCurrentDateInvoiceDto> ValidateCurrentDateInvoiceDto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.GetConnectionString("Invoice"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.HasIndex(e => e.InvoiceCode, "NonClusteredIndex-20210830-214004");

                entity.HasIndex(e => new { e.InvoiceCode, e.IsActive }, "NonClusteredIndex-20210906-220901");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChemistCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.DeliveryTime)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountDetailId).HasColumnName("DiscountDetailID");

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

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

                entity.Property(e => e.Mpocode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MPOCode");

                entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NetAmountDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NetProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NetTp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("NetTP");

                entity.Property(e => e.NetVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoiceAllocation>(entity =>
            {
                entity.ToTable("InvoiceAllocation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllocationCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.AllocationDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dacode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DACode");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DispatchedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DispatchedByID");

                entity.Property(e => e.DispatchedOn).HasColumnType("datetime");

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

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoiceAllocationDetail>(entity =>
            {
                entity.ToTable("InvoiceAllocationDetail");

                entity.HasIndex(e => e.InvoiceCode, "NonClusteredIndex-20210906-221121");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllocationCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
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

            modelBuilder.Entity<InvoiceAllocationRoute>(entity =>
            {
                entity.ToTable("InvoiceAllocationRoute");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllocationCode)
                    .IsRequired()
                    .HasMaxLength(17)
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

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.RouteCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("InvoiceDetail");

                entity.HasIndex(e => new { e.InvoiceCode, e.ProductCode }, "NonClusteredIndex-20210829-215722");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountDetailId).HasColumnName("DiscountDetailID");

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.PackSize)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalesCode)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Sps).HasColumnName("SPS");

                entity.Property(e => e.TotalAmountDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalTp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TotalTP");

                entity.Property(e => e.TotalVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TP");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Vat).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<InvoiceProductBatchWise>(entity =>
            {
                entity.ToTable("InvoiceProductBatchWise");

                entity.HasIndex(e => new { e.InvoiceCode, e.ProductCode }, "NonClusteredIndex-20210829-215335");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CancelledById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CancelledByID");

                entity.Property(e => e.CancelledOn).HasColumnType("datetime");

                entity.Property(e => e.ChemistCode)
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

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.DeliveryTime)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LabaidEmployeeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.Mpocode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MPOCode");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderMedia)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonToCancel)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrdersDetail>(entity =>
            {
                entity.ToTable("OrdersDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

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

                entity.Property(e => e.MachineId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MachineID");

                entity.Property(e => e.OrderCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
