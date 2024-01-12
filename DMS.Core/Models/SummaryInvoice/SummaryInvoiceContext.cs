using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.SummaryInvoice
{
    public partial class SummaryInvoiceContext : SummaryContext_ModelClasses
    {
        public IConfiguration Config { get; }


        public SummaryInvoiceContext(IConfiguration config)
        {
            this.Config = config;
        }

        //public SummaryInvoiceContext(DbContextOptions<SummaryInvoiceContext> options)
        //    : base(options)
        //{
        //}

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
                optionsBuilder.UseSqlServer(Config.GetConnectionString("Summary"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Summary>(entity =>
            {
                entity.ToTable("Summary");

                entity.HasIndex(e => e.SummaryCode, "IX_Summary")
                    .IsUnique();

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

                entity.HasIndex(e => e.CollectionCode, "IX_SummaryCollection")
                    .IsUnique();

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
                entity.HasKey(e => new { e.CollectionCode, e.InvoiceCode, e.PaymentMode });

                entity.ToTable("SummaryCollectionDetail");

                entity.Property(e => e.CollectionCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AitdeductionAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("AITDeductionAmount");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CashCollectionAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChequeCollectionAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CollectionType)
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

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InstrumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsAitdocumentReceived).HasColumnName("IsAITDocumentReceived");

                entity.Property(e => e.ModuleVersion)
                    .HasMaxLength(10)
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
                entity.HasKey(e => new { e.SummaryCode, e.InvoiceCode })
                    .HasName("PK_InvoiceSummary");

                entity.ToTable("SummaryInvoice");

                entity.HasIndex(e => new { e.SummaryCode, e.InvoiceCode }, "NonClusteredIndex-20210830-213838");

                entity.HasIndex(e => new { e.InvoiceCode, e.IsActive }, "NonClusteredIndex-20210906-220622");

                entity.HasIndex(e => e.InvoiceCode, "NonClusteredIndex-20210906-220737");

                entity.Property(e => e.SummaryCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceCode)
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

                entity.Property(e => e.DiscountCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountDetailId).HasColumnName("DiscountDetailID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

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

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SummaryInvoiceDetail>(entity =>
            {
                entity.HasKey(e => new { e.SummaryCode, e.InvoiceCode, e.ProductCode })
                    .HasName("PK_InvoiceDetailSummary");

                entity.ToTable("SummaryInvoiceDetail");

                entity.HasIndex(e => new { e.InvoiceCode, e.ProductCode }, "NonClusteredIndex-20210829-215436");

                entity.Property(e => e.SummaryCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

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

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

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

                entity.Property(e => e.ProductUnitDiscount).HasColumnType("decimal(18, 2)");

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
