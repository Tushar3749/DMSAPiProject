using System;
using DMS.Core.Models_StoredProcedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DMS.Core.Models.SystemManager
{
    public partial class SystemManagerContext : SystemManagerContext_ModelClasses
    {
        public IConfiguration Config { get; }


        public SystemManagerContext(IConfiguration config)
        {
            this.Config = config;
        }

        //public SystemManagerContext(DbContextOptions<SystemManagerContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<DmsMenu> DmsMenus { get; set; }
        public virtual DbSet<DmsUserPrivilege> DmsUserPrivileges { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.GetConnectionString("SystemManager"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DmsMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__DMS_Menus__C99ED25009ABB2EE");

                entity.ToTable("DMS_Menus");

                entity.HasIndex(e => e.MenuName, "UQ__DMS_Menus__B42383E47490409D")
                    .IsUnique();

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsNonPrivilegedMenu).HasDefaultValueSql("((0))");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.Route)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("date");
            });

            modelBuilder.Entity<DmsUserPrivilege>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeCode, e.MenuId })
                    .HasName("PK_DM_UserPrivilege");

                entity.ToTable("DMS_UserPrivilege");

                entity.Property(e => e.EmployeeCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.HasDelete).HasDefaultValueSql("((1))");

                entity.Property(e => e.HasFullAccess).HasDefaultValueSql("((1))");

                entity.Property(e => e.HasInsert).HasDefaultValueSql("((1))");

                entity.Property(e => e.HasPrint).HasDefaultValueSql("((1))");

                entity.Property(e => e.HasUpdate).HasDefaultValueSql("((1))");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("UserAccount");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordInPlainText)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
