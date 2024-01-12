using System;
using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.Maintenance
{
    public partial class MaintenanceContext : Maintenance_ModelClasses
    {
        public IConfiguration Config { get; }


        public MaintenanceContext(IConfiguration config)
        {
            this.Config = config;
        }

        //public MaintenanceContext(DbContextOptions<MaintenanceContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.GetConnectionString("Maintenance"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepotCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionDetails)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ReportedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ReportedByID");

                entity.Property(e => e.Route)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
