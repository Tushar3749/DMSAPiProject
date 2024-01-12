using System;
using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.CreditNote
{
    public partial class CreditNoteContext : CreditNoteContext_ModelClasses
    {
        private readonly IConfiguration Config;

        public CreditNoteContext(IConfiguration config)
        {
            this.Config = config;
        }

        public virtual DbSet<CreditNoteAdjustment> CreditNoteAdjustments { get; set; }
        public virtual DbSet<CreditNoteAdjustmentDetail> CreditNoteAdjustmentDetails { get; set; }
        public virtual DbSet<CreditNoteChemistPayable> CreditNoteChemistPayables { get; set; }
        public virtual DbSet<CreditNoteDueAdjustment> CreditNoteDueAdjustments { get; set; }
        public virtual DbSet<CreditNoteDueAdjustmentDetail> CreditNoteDueAdjustmentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.GetConnectionString("CreditNote"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CreditNoteAdjustment>(entity =>
            {
                entity.HasKey(e => e.AdjustmentCode);

                entity.ToTable("CreditNoteAdjustment");

                entity.Property(e => e.AdjustmentCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ChemistCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InvoiceCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CreditNoteAdjustmentDetail>(entity =>
            {
                entity.HasKey(e => new { e.AdjustmentCode, e.CreditNoteCode, e.IsActive });

                entity.Property(e => e.AdjustmentCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreditNoteCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<CreditNoteChemistPayable>(entity =>
            {
                entity.HasKey(e => new { e.CreditNoteCode, e.ProductType, e.ChemistCode })
                    .HasName("PK_CreditNoteValueForAdjust");

                entity.ToTable("CreditNoteChemistPayable");

                entity.Property(e => e.CreditNoteCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Good/Damage");

                entity.Property(e => e.ChemistCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AdjustedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AdjustedByID");

                entity.Property(e => e.AdjustedOn).HasColumnType("datetime");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CreditNoteDueAdjustment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CreditNoteDueAdjustment");

                entity.Property(e => e.AdjustmentCode)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.ChemistCode)
                    .IsRequired()
                    .HasMaxLength(15)
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

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CreditNoteDueAdjustmentDetail>(entity =>
            {
                entity.HasKey(e => new { e.AdjustmentCode, e.InvoiceCode, e.CreditNoteCode })
                    .HasName("PK_CreditNoteAdjustmentDetail");

                entity.ToTable("CreditNoteDueAdjustmentDetail");

                entity.Property(e => e.AdjustmentCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.CreditNoteCode)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.AdjustedAmount).HasColumnType("decimal(18, 2)");

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

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
