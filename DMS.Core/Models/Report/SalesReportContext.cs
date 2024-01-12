using System;
using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class SalesReportContext : SalesReportContext_SPModels
    {

        public IConfiguration Config { get; }
        public SalesReportContext(IConfiguration config)
        {
            this.Config = config;
        }

        //public SalesReportContext(DbContextOptions<SalesReportContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Chemist> Chemists { get; set; }
        public virtual DbSet<ChemistCredit> ChemistCredits { get; set; }
        public virtual DbSet<ChemistTerritory> ChemistTerritories { get; set; }
        public virtual DbSet<ChemistType> ChemistTypes { get; set; }
        public virtual DbSet<CollectionProcessDatum> CollectionProcessData { get; set; }
        public virtual DbSet<DailyDepotClosingStockStatement> DailyDepotClosingStockStatements { get; set; }
        public virtual DbSet<DayOpenAndCloseStatement> DayOpenAndCloseStatements { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DiscountCategory> DiscountCategories { get; set; }
        public virtual DbSet<DiscountDetail> DiscountDetails { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceAllocation> InvoiceAllocations { get; set; }
        public virtual DbSet<InvoiceAllocationDetail> InvoiceAllocationDetails { get; set; }
        public virtual DbSet<InvoiceAllocationRoute> InvoiceAllocationRoutes { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceProductBatchWise> InvoiceProductBatchWises { get; set; }
        public virtual DbSet<InvoiceReturnType> InvoiceReturnTypes { get; set; }
        public virtual DbSet<InvoiceWiseCollection> InvoiceWiseCollections { get; set; }
        public virtual DbSet<InvoiceWisePayment> InvoiceWisePayments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }
        public virtual DbSet<OutstandingProcessDatum> OutstandingProcessData { get; set; }
        public virtual DbSet<SalesProcessDatum> SalesProcessData { get; set; }
        public virtual DbSet<Summary> Summaries { get; set; }
        public virtual DbSet<SummaryCollection> SummaryCollections { get; set; }
        public virtual DbSet<SummaryCollectionDetail> SummaryCollectionDetails { get; set; }
        public virtual DbSet<SummaryCollectionInstrument> SummaryCollectionInstruments { get; set; }
        public virtual DbSet<SummaryInvoice> SummaryInvoices { get; set; }
        public virtual DbSet<SummaryInvoiceDetail> SummaryInvoiceDetails { get; set; }
        public virtual DbSet<SummaryInvoiceProductBatchWise> SummaryInvoiceProductBatchWises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.GetConnectionString("SalesReport"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chemist>(entity =>
            {
                entity.ToTable("Chemist");

                entity.Property(e => e.ChemistId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ChemistID");

                entity.Property(e => e.AddressDetail)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChemistName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ChemistTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DepoId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DepoID");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.House)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Road)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ChemistCredit>(entity =>
            {
                entity.HasKey(e => new { e.ChemistId, e.CreditType })
                    .HasName("PK_ChemistCredit_1");

                entity.ToTable("ChemistCredit");

                entity.Property(e => e.ChemistId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ChemistID");

                entity.Property(e => e.CreditType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ChemistTerritory>(entity =>
            {
                entity.ToTable("ChemistTerritory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChemistId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ChemistID");

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.TerritoryId)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("TerritoryID");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ChemistType>(entity =>
            {
                entity.ToTable("Chemist_Types");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CollectionProcessDatum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AllocationCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.AllocationDate).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AmountDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChemistCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dacode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DACode");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SummaryCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryDate).HasColumnType("datetime");

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TP");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Vat).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<DailyDepotClosingStockStatement>(entity =>
            {
                entity.ToTable("DailyDepotClosingStockStatement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DayOpenAndCloseStatement>(entity =>
            {
                entity.ToTable("DayOpenAndCloseStatement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DayClosedAt).HasColumnType("datetime");

                entity.Property(e => e.DayClosedByCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DayOpenAt).HasColumnType("datetime");

                entity.Property(e => e.DayOpenByCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ReopenedByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReopenedDate).HasColumnType("datetime");

                entity.Property(e => e.ReportDate).HasColumnType("date");

                entity.Property(e => e.UpdatedByCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasKey(e => e.DiscountCode);

                entity.ToTable("Discount");

                entity.HasIndex(e => new { e.DiscountCategoryCode, e.EffectiveFrom }, "NonClusteredIndex-20210827-121828");

                entity.Property(e => e.DiscountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChemistCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DepotCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountCategoryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EffectiveFrom).HasColumnType("date");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TransferredOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VerifiedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("VerifiedByID");

                entity.Property(e => e.VerifiedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<DiscountCategory>(entity =>
            {
                entity.ToTable("Discount_Categories");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountCategoryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<DiscountDetail>(entity =>
            {
                entity.ToTable("DiscountDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsTransferred).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumRange).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinimumInvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinimumRange).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.DiscountCodeNavigation)
                    .WithMany(p => p.DiscountDetails)
                    .HasForeignKey(d => d.DiscountCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiscountDetail_Discount");
            });

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

            modelBuilder.Entity<InvoiceReturnType>(entity =>
            {
                entity.ToTable("InvoiceReturnType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InvoiceWiseCollection>(entity =>
            {
                entity.ToTable("InvoiceWiseCollection");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChemistCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceAmountDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceTp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("InvoiceTP");

                entity.Property(e => e.InvoiceVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<InvoiceWisePayment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("InvoiceWisePayment");

                entity.Property(e => e.ChequeClearanceDate).HasColumnType("date");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(15)
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

            modelBuilder.Entity<OutstandingProcessDatum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AllocationCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.AllocationDate).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AmountDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChemistCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dacode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DACode");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SummaryCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryDate).HasColumnType("datetime");

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TP");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Vat).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SalesProcessDatum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AllocationCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.AllocationDate).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AmountDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChemistCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dacode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DACode");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SummaryCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryDate).HasColumnType("datetime");

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TP");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Vat).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Summary>(entity =>
            {
                entity.ToTable("Summary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AllocationCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.CanceledById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CanceledByID");

                entity.Property(e => e.CanceledOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dacode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DACode");

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

                entity.Property(e => e.ReasonToCancel)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SummaryCollection>(entity =>
            {
                entity.ToTable("SummaryCollection");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CollectionCode)
                    .IsRequired()
                    .HasMaxLength(20)
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

                entity.Property(e => e.ModuleVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SummaryCollectionDetail>(entity =>
            {
                entity.ToTable("SummaryCollectionDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AitdeductionAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("AITDeductionAmount");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CashCollectionAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChequeCollectionAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CollectionCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InstrumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsAitdocumentReceived).HasColumnName("IsAITDocumentReceived");

                entity.Property(e => e.ModuleVersion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SummaryCollectionInstrument>(entity =>
            {
                entity.ToTable("SummaryCollectionInstrument");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChemistCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CollectionCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InstrumentBank)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentDate).HasColumnType("datetime");

                entity.Property(e => e.InstrumentNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentType)
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

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SummaryInvoice>(entity =>
            {
                entity.ToTable("SummaryInvoice");

                entity.HasIndex(e => new { e.SummaryCode, e.InvoiceCode }, "NonClusteredIndex-20210830-213838");

                entity.HasIndex(e => new { e.InvoiceCode, e.IsActive }, "NonClusteredIndex-20210906-220622");

                entity.HasIndex(e => e.InvoiceCode, "NonClusteredIndex-20210906-220737");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
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

                entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NetAmountDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NetProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NetTp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("NetTP");

                entity.Property(e => e.NetVat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ReturnReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SummaryCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SummaryInvoiceDetail>(entity =>
            {
                entity.ToTable("SummaryInvoiceDetail");

                entity.HasIndex(e => new { e.InvoiceCode, e.ProductCode }, "NonClusteredIndex-20210829-215436");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
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
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductUnitDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalesCode)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Sps).HasColumnName("SPS");

                entity.Property(e => e.SummaryCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmountDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalProductDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalTp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TotalTP");

                entity.Property(e => e.TotalVat)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TotalVAT");

                entity.Property(e => e.Tp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("TP");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("VAT");
            });

            modelBuilder.Entity<SummaryInvoiceProductBatchWise>(entity =>
            {
                entity.ToTable("SummaryInvoiceProductBatchWise");

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

                entity.Property(e => e.SummaryCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
