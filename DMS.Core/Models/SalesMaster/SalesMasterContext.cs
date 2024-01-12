using System;
using DMS.Core.DTO.Chemist;
using DMS.Core.Models.PartyCode;
using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.SalesMaster
{
    public partial class SalesMasterContext : SalesMasterContext_ModelClasses
    {
        public IConfiguration Config { get; }


        public SalesMasterContext(IConfiguration config)
        {
            this.Config = config;
        }


        public virtual DbSet<Chemist> Chemists { get; set; }
        public virtual DbSet<ChemistCredit> ChemistCredits { get; set; }
        public virtual DbSet<ChemistTerritory> ChemistTerritories { get; set; }
        public virtual DbSet<ChemistType> ChemistTypes { get; set; }
        public virtual DbSet<Market> Markets { get; set; }
        public virtual DbSet<MarketChemist> MarketChemists { get; set; }
        public virtual DbSet<TerritoryMarket> TerritoryMarkets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.GetConnectionString("SalesMaster"));
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

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

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

            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasKey(e => e.MarketCode);

                entity.ToTable("Market");

                entity.Property(e => e.MarketCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MarketName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ThanaId).HasColumnName("ThanaID");

                entity.Property(e => e.UpazilaId).HasColumnName("UpazilaID");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MarketChemist>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

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

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MarketCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TerritoryMarket>(entity =>
            {
                entity.ToTable("TerritoryMarket");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MarketCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TerritoryCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
